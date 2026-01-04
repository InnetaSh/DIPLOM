using Globals.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using OfferApiService.Models;
using OfferApiService.Models.View;
using OfferApiService.Service;
using OfferApiService.Service.Interface;
using OfferApiService.View;
using System.Net.Http.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OfferApiService.Services
{
    public class OfferService : TableServiceBase<Offer, OfferContext>, IOfferService
    {


        public override async Task<Offer> GetEntityAsync(int id, params string[] includeProperties)
        {
            using var db = new OfferContext();

            return await db.Offers
                .Include(o => o.OfferOrderLinks)
                .Include(o => o.BookedDates)
                .Include(o => o.RentObj)
                    .ThenInclude(ro => ro.Images)
                .Include(o => o.RentObj)
                    .ThenInclude(ro => ro.ParamValues)
                .FirstOrDefaultAsync(o => o.id == id);
        }

        public override async Task<List<Offer>> GetEntitiesAsync(params string[] includeProperties)
        {
            using var db = new OfferContext();

            return await db.Offers
                .Include(o => o.OfferOrderLinks)
                .Include(o => o.BookedDates)
                .Include(o => o.RentObj)
                    .ThenInclude(ro => ro.Images)
                .Include(o => o.RentObj)
                    .ThenInclude(ro => ro.ParamValues)
                .ToListAsync();
        }

        //==================================================================================================================

        public async Task<List<int>> GetOrdersIdLinkToOffer(int offerId)
        {
            await using var db = new OfferContext();

            var client = await db.Offers
                .FirstOrDefaultAsync(x => x.id == offerId);

            if (client == null)
                return null;


            var existsList =  db.OfferOrderLinks
                .Where(x => x.OfferId == offerId).Select(x=>x.OrderId).ToList();
            return existsList;
        }

        //==================================================================================================================

        public async Task<bool> AddOrderLinkToOffer(int offerId, int orderId)
        {
            await using var db = new OfferContext();

            var client = await db.Offers
                .FirstOrDefaultAsync(x => x.id == offerId);

            if (client == null)
                return false;


            var exists = await db.OfferOrderLinks
                .AnyAsync(x => x.OfferId == offerId && x.OrderId == orderId);

            if (exists)
                return false;

            var offerOrder = new OfferOrderLink
            {
                OfferId = offerId,
                OrderId = orderId
            };

            db.OfferOrderLinks.Add(offerOrder);
            await db.SaveChangesAsync();

            return true;
        }


        //==================================================================================================================
        public async Task<List<Offer>> SearchAvailableOffersAsync([FromQuery] OfferMainSearchRequest request)
        {
            if (request.StartDate >= request.EndDate)
                throw new ArgumentException("Invalid date range");

            var fitOffers = new List<Offer>();
            try
            {
                using var db = new OfferContext();

                 fitOffers = await db.Offers
                    .Include(o => o.OfferOrderLinks)
                    .Include(o => o.BookedDates)
                    .Include(o => o.RentObj)       
                         .ThenInclude(ro => ro.Images)
                    .Include(o => o.RentObj)
                         .ThenInclude(ro => ro.ParamValues)
                    .Where(o => o.RentObj.CityId == request.CityId)
                    .Where(o => o.MaxGuests >= request.Guests)
                    //.Where(o =>
                    //    !o.BookedDates.Any(d =>
                    //        d.Start < request.EndDate &&
                    //        d.End > request.StartDate))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                //throw new Exception("An error occurred while retrieving offers", ex);
            }
            return fitOffers;
        }
        //==================================================================================================================
    }
}
