using Globals.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Service.Interface;
using OfferApiService.Services.Interfaces.RentObj;
using OfferContracts;

namespace OfferApiService.Services
{
    public class OfferService : TableServiceBaseNew<Offer, OfferContext>, IOfferService
    {
        private readonly IWebHostEnvironment _env;

        public OfferService(
            OfferContext context,
            ILogger<OfferService> logger,
            IWebHostEnvironment env) : base(context, logger)
        {
            _env = env;
        }
        //public OfferService(IWebHostEnvironment env)
        //{
        //    _env = env;
        //}
        //==================================================================================================================


        public async Task<Offer> GetOnlyOfferAsync(int id, params string[] includeProperties)
        {
            _logger.LogInformation("Fetching offer with id {OfferId}", id);
            var offer = await _context.Offers
                .AsNoTracking()
                .Include(o => o.RentObj)
                    .ThenInclude(ro => ro.Images)
                .Include(o => o.RentObj)
                    .ThenInclude(ro => ro.ParamValues)
                .FirstOrDefaultAsync(o => o.id == id);

            if (offer == null)
                _logger.LogWarning("Offer with id {OfferId} not found", id);
            else
                _logger.LogInformation("Offer with id {OfferId} retrieved successfully", id);

            return offer;
        }


        public override async Task<Offer> GetEntityAsync(int id, Predicate<Offer>? additional = null, params string[] includeProperties)
        {
            _logger.LogInformation("Fetching offer with RentObject details for id {OfferId}", id);

            var offer = await _context.Offers
                .AsNoTracking()
                .Include(o => o.RentObj)
                    .ThenInclude(ro => ro.Images)
                .Include(o => o.RentObj)
                    .ThenInclude(ro => ro.ParamValues)
                .FirstOrDefaultAsync(o => o.id == id);

            if (offer == null)
                _logger.LogWarning("Offer {OfferId} not found", id);
            else
                _logger.LogInformation("Offer {OfferId} successfully retrieved", id);

            return offer;
        }

        public override async Task<List<Offer>> GetEntitiesAsync(Predicate<Offer>? additional = null, params string[] includeProperties)
        {
            _logger.LogInformation("Fetching all offers with RentObject details");

            var offers = await _context.Offers
                 .AsNoTracking()
                .Include(o => o.RentObj)
                    .ThenInclude(ro => ro.Images)
                .Include(o => o.RentObj)
                    .ThenInclude(ro => ro.ParamValues)
                .ToListAsync();

            _logger.LogInformation("Retrieved {Count} offers", offers.Count);

            return offers;
        }


        public async Task<int> AddOfferWithRentObjAndParamValuesAsync(Offer offer)
        {
            _logger.LogInformation("Adding new offer for owner {OwnerId}", offer.OwnerId);
            if (offer.RentObj?.ParamValues != null)
            {
                _logger.LogInformation("Normalizing {Count} param values", offer.RentObj.ParamValues.Count);
                foreach (var param in offer.RentObj.ParamValues)
                {
                    param.ValueString ??= string.Empty;
                }
            }

            _context.Offers.Add(offer);
            _logger.LogInformation("Saving offer to database");
            await _context.SaveChangesAsync();

            _logger.LogInformation("Offer added successfully with id {OfferId}", offer.id);


            return offer.id;
        }


        public async Task<int> UpdateOfferWithRentObjAndParamValuesAsyn(Offer offer)
        {
            _logger.LogInformation("Updating offer with id {OfferId}", offer.id);

            var existingOffer = await _context.Offers
                .Include(o => o.RentObj)
                    .ThenInclude(r => r.ParamValues)
                .Include(o => o.RentObj)
                    .ThenInclude(r => r.Images)
                .FirstOrDefaultAsync(o => o.id == offer.id);

            if (existingOffer == null)
            {
                _logger.LogWarning("Offer with id {OfferId} not found for update", offer.id);
                throw new Exception($"Offer with id={offer.id} not found");
            }

            else
            {
                _logger.LogInformation("Updating RentObject for offer {OfferId}", offer.id);

                _context.Entry(existingOffer.RentObj)
                    .CurrentValues
                    .SetValues(offer.RentObj);
            }


            // =======================
            // 4. ParamValues
            // =======================

            var existingParams = existingOffer.RentObj.ParamValues ?? new List<RentObjParamValue>();
            var newParams = offer.RentObj.ParamValues ?? new List<RentObjParamValue>();
            _logger.LogInformation("Processing ParamValues. Existing: {Existing}, Incoming: {Incoming}",
               existingParams.Count, newParams.Count);

            foreach (var existing in existingParams.ToList())
            {
                if (!newParams.Any(p => p.id != 0 && p.id == existing.id))
                {
                    _logger.LogInformation("Removing param value {ParamId}", existing.id);
                    _context.RentObjParamValues.Remove(existing);
                }
            }
            foreach (var param in newParams)
            {
                if (param.id == 0)
                {
                    _logger.LogInformation("Adding new param value to RentObject {RentObjId}", existingOffer.RentObj.id);

                    param.RentObjId = existingOffer.RentObj.id;
                    existingParams.Add(param);
                }
                else
                {
                    var existing = existingParams.FirstOrDefault(p => p.id == param.id);
                    if (existing != null)
                    {
                        _logger.LogInformation("Updating param value {ParamId}", param.id);
                        _context.Entry(existing).CurrentValues.SetValues(param);
                    }
                }
            }


            // =======================
            // 5. Images
            // =======================

            var existingImages = existingOffer.RentObj.Images ?? new List<RentObjImage>();

            var incomingImages = offer.RentObj.Images ?? new List<RentObjImage>();

            _logger.LogInformation("Processing images. Existing: {Existing}, Incoming: {Incoming}",
               existingImages.Count, incomingImages.Count);

            var incomingIds = incomingImages
                .Where(i => i.id != 0)
                .Select(i => i.id)
                .ToHashSet();

            foreach (var existing in existingImages.ToList())
            {
                if (!incomingIds.Contains(existing.id))
                {
                    _logger.LogInformation("Deleting image {ImageId} for offer {OfferId}", existing.id, offer.id);

                    var relativePath = existing.Url.TrimStart('/');
                    var fullPath = Path.Combine(_env.WebRootPath,
                        relativePath.Replace("/", Path.DirectorySeparatorChar.ToString()));

                   if (File.Exists(fullPath))
                    {
                        _logger.LogInformation("Deleting physical file {Path}", fullPath);
                        File.Delete(fullPath);
                    }

                    _context.RentObjImages.Remove(existing);
                }
            }


            _logger.LogInformation("Saving updated offer {OfferId}", offer.id);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Offer with id {OfferId} updated successfully", offer.id);
            return offer.id;
        }


        //==================================================================================================================

        public async Task<List<int>> GetOrdersIdLinkToOffer(int offerId)
        {
            _logger.LogInformation("Fetching linked order IDs for offer {OfferId}", offerId);

            var offer = await _context.Offers
                 .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == offerId);

            if (offer == null)
            {
                _logger.LogWarning("Offer {OfferId} not found", offerId);
                return null;
            }


            var existsList = await _context.OfferOrderLinks
                .AsNoTracking()
                .Where(x => x.OfferId == offerId)
                .Select(x => x.OrderId)
                .ToListAsync();

            _logger.LogInformation("Found {Count} linked orders for offer {OfferId}", existsList.Count, offerId);

            return existsList;
        }

        //==================================================================================================================

        public async Task<bool> AddOrderLinkToOffer(int offerId, int orderId)
        {
            _logger.LogInformation("Adding order link: offer {OfferId} -> order {OrderId}", offerId, orderId);


            var client = await _context.Offers
                .FirstOrDefaultAsync(x => x.id == offerId);

            if (client == null)
            {
                _logger.LogWarning("Offer {OfferId} not found", offerId);
                return false;
            }


            var exists = await _context.OfferOrderLinks
                .AnyAsync(x => x.OfferId == offerId && x.OrderId == orderId);

            if (exists)
            {
                _logger.LogWarning("Order link already exists: offer {OfferId}, order {OrderId}", offerId, orderId);
                return false;
            }


            var offerOrder = new OfferOrderLink
            {
                OfferId = offerId,
                OrderId = orderId
            };

            _context.OfferOrderLinks.Add(offerOrder);
            _logger.LogInformation("Saving order link");

            await _context.SaveChangesAsync();

            _logger.LogInformation("Order link saved successfully");

            return true;
        }


        //==================================================================================================================
        public async Task<List<Offer>> SearchOffersFromRegion([FromQuery] OfferSearchRequestByRegionAndCountGuest request)
        {
            _logger.LogInformation("Searching offers in region {RegionId} for {Adults} adults and {Children} children",
             request.RegionId, request.Adults, request.Children);

            var totalGuests = request.Adults + request.Children;
            var offers  =  await _context.Offers
                .AsNoTracking()
                .Include(o => o.RentObj)
                    .ThenInclude(ro => ro.Images)
                .Include(o => o.RentObj)
                    .ThenInclude(ro => ro.ParamValues)
                .Where(o => o.RentObj != null &&
                            o.RentObj.RegionId == request.RegionId &&
                            o.MaxGuests >= totalGuests)
                .ToListAsync();

            _logger.LogInformation("Found {Count} offers in region {RegionId}", offers.Count, request.RegionId);

            return offers;
        }

        //==================================================================================================================
        public async Task<List<Offer>> SearchOffersFromCountry([FromQuery] OfferSearchRequestByCountryAndCountGuest request)
        {
            _logger.LogInformation("Searching offers in country {CountryId} for {Adults} adults and {Children} children",
               request.CountryId, request.Adults, request.Children);

           
            var totalGuests = request.Adults + request.Children;
            var offers  = await _context.Offers
                     .AsNoTracking()
                   .Include(o => o.RentObj)
                       .ThenInclude(ro => ro.Images)
                   .Include(o => o.RentObj)
                       .ThenInclude(ro => ro.ParamValues)
                   .Where(o => o.RentObj != null &&
                               o.RentObj.CountryId == request.CountryId &&
                               o.MaxGuests >= totalGuests)
                   .ToListAsync();
            
           _logger.LogInformation("Found {Count} offers in country {CountryId}", offers.Count, request.CountryId);

            return offers;
        }
        //==================================================================================================================
        public async Task<List<Offer>> SearchOffersAsync([FromQuery] OfferSearchRequestByCityAndCountGuest request)
        {
            _logger.LogInformation("Searching offers in city {CityId} for {Adults} adults and {Children} children",
              request.CityId, request.Adults, request.Children);

            var totalGuests = request.Adults + request.Children;
           
                var fitOffers = await _context.Offers
                     .AsNoTracking()
                    .Include(o => o.RentObj)
                        .ThenInclude(ro => ro.Images)
                    .Include(o => o.RentObj)
                        .ThenInclude(ro => ro.ParamValues)
                    .Where(o => o.RentObj != null &&
                                o.RentObj.CityId == request.CityId &&
                                o.MaxGuests >= totalGuests)
                    .ToListAsync();
           
            return fitOffers;
        }

        //==================================================================================================================

        public async Task<List<Offer>> GetOffersByOwnerIdAsync(int ownerId)
        {
            _logger.LogInformation("Fetching offers for owner {OwnerId}", ownerId);
            var offers = await _context.Offers
                    .AsNoTracking()
                   .Include(o => o.RentObj)
                        .ThenInclude(ro => ro.Images)
                   .Include(o => o.RentObj)
                        .ThenInclude(ro => ro.ParamValues)
                   .Where(o => o.OwnerId == ownerId)
                   .ToListAsync();
            
             _logger.LogInformation("Owner {OwnerId} has {Count} offers", ownerId, offers.Count);

            return offers;
        }

        //public async Task<List<Offer>> GetOffersByIdAsync(List<int> ids)
        //{
        //    var fitOffers = new List<Offer>();
        //    try
        //    {
        //        using var db = new OfferContext();
        //        fitOffers = await db.Offers
        //           //.Include(o => o.OfferOrderLinks)
        //           //.Include(o => o.BookedDates)
        //           .Include(o => o.RentObj)
        //                .ThenInclude(ro => ro.Images)
        //           .Include(o => o.RentObj)
        //                .ThenInclude(ro => ro.ParamValues)
        //           .Where(o => o.id == ids)
        //           .ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (not implemented here)
        //        //throw new Exception("An error occurred while retrieving offers", ex);
        //    }
        //    return fitOffers;
        //}
        //==================================================================================================================

        public async Task<List<Offer>> GetOffersByOwnerIdAndCityAsync(int ownerId, int cityId)
        {
            _logger.LogInformation("Fetching offers for owner {OwnerId} in city {CityId}", ownerId, cityId);

            var offers = await _context.Offers
                .AsNoTracking()
                .Include(o => o.RentObj)
                    .ThenInclude(ro => ro.Images)
                .Include(o => o.RentObj)
                    .ThenInclude(ro => ro.ParamValues)
                .Where(o => o.OwnerId == ownerId && o.RentObj.CityId == cityId)
                .ToListAsync();

            _logger.LogInformation(
                "Found {Count} offers for owner {OwnerId} in city {CityId}",
                offers.Count,
                ownerId,
                cityId);

            return offers;
        }


        //==================================================================================================================

        public async Task<List<Offer>> GetOffersByOwnerIdAndCountryAsync(int ownerId, int countryId)
        {

            _logger.LogInformation("Fetching offers for owner {OwnerId} in country {CountryId}", ownerId, countryId);


            var  offers = await _context.Offers
                  .AsNoTracking()
                   .Include(o => o.RentObj)
                        .ThenInclude(ro => ro.Images)
                   .Include(o => o.RentObj)
                        .ThenInclude(ro => ro.ParamValues)
                   .Where(o => o.RentObj.CountryId == countryId)
                   .Where(o => o.OwnerId == ownerId)
                   .ToListAsync();
            _logger.LogInformation(
            "Found {Count} offers for owner {OwnerId} in country {countryId}",
                 offers.Count,
                 ownerId,
                 countryId);

            return offers;
        }
    }
}
