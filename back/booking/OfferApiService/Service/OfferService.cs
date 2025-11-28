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
        //private readonly IHttpClientFactory _clientFactory;
        //private readonly IRentObjServiceClient _rentObjClient;

        //public OfferService(IHttpClientFactory clientFactory, IRentObjServiceClient rentObjClient)
        //{
        //    _clientFactory = clientFactory;
        //    _rentObjClient = rentObjClient;
        //}


        //public override async Task<bool> AddEntityAsync(Offer offer)
        //{

        //    var userTask = ValidateUserAsync(offer.OwnerId);
        //    var rentObjTask = ValidateRentObjectAsync(offer.RentObjId);

        //    await Task.WhenAll(userTask, rentObjTask);

        //    if (!userTask.Result)
        //        throw new Exception("Owner does not exist");
        //    if (!rentObjTask.Result)
        //        throw new Exception("Rent object does not exist");


        //    return await base.AddEntityAsync(offer);
        //}


        public async Task<List<Offer>> GetMainAvailableOffers([FromQuery] OfferMainSearchRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.City))
                throw new ArgumentException("City is required", nameof(request.City));
            if (request.StartDate >= request.EndDate)
                throw new ArgumentException("Invalid date range");

            var fitOffers = new List<Offer>();
            try
            {
                using (var db = new OfferContext())
                {
                    var rentObjsIDs = db.RentObjects
                        .Include(ro => ro.City)
                        .Where(ro => ro.City.Title == request.City)
                        .Where(ro => ro.BedroomsCount >= request.BedroomsCount)
                        .Select(ro => ro.id)
                        .ToList();

                    var offers = db.Offers.ToList();

                    fitOffers = offers
                        .Where(x => !x.BookedDates.Any(d => d.Start < request.EndDate && d.End > request.StartDate)
                                    && rentObjsIDs.Contains(x.RentObjId))
                        .ToList();
                }
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
