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
        
        public async Task<List<Offer>> GetMainAvailableOffers([FromQuery] OfferMainSearchRequest request)
        {
            if (request.StartDate >= request.EndDate)
                throw new ArgumentException("Invalid date range");

            var fitOffers = new List<Offer>();
            try
            {
                using var db = new OfferContext();

                 fitOffers = await db.Offers
                    .Include(o => o.BookedDates)
                    .Include(o => o.RentObj)       
                         .ThenInclude(ro => ro.Images)
                    .Where(o => o.RentObj.CityId == request.CityId)
                    .Where(o => o.RentObj.BedroomsCount >= request.BedroomsCount)
                    .Where(o =>
                        !o.BookedDates.Any(d =>
                            d.Start < request.EndDate &&
                            d.End > request.StartDate))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                //throw new Exception("An error occurred while retrieving offers", ex);
            }
            return fitOffers;
        }
    }
}
