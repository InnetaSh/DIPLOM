using Globals.Sevices;
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
        private readonly IHttpClientFactory _clientFactory;
        private readonly IRentObjServiceClient _rentObjClient;

        public OfferService(IHttpClientFactory clientFactory, IRentObjServiceClient rentObjClient)
        {
            _clientFactory = clientFactory;
            _rentObjClient = rentObjClient;
        }

        
        public override async Task<bool> AddEntityAsync(Offer offer)
        {

            var userTask = ValidateUserAsync(offer.OwnerId);
            var rentObjTask = ValidateRentObjectAsync(offer.RentObjId);

            await Task.WhenAll(userTask, rentObjTask);

            if (!userTask.Result)
                throw new Exception("Owner does not exist");
            if (!rentObjTask.Result)
                throw new Exception("Rent object does not exist");


            return await base.AddEntityAsync(offer);
        }


        public async Task<List<Offer>> GetMainAvailableOffers(
            string cityTitle, DateTime startDate, DateTime endDate, int bedroomsCount)
        {

            if (string.IsNullOrWhiteSpace(cityTitle))
                throw new ArgumentException("City is required", nameof(cityTitle));
            if (startDate >= endDate)
                throw new ArgumentException("Invalid date range");

            using (var db = (OfferContext)Activator.CreateInstance(typeof(OfferContext)))
            {
                var rentObjsIDs = db.RentObjects
                    .Include(ro => ro.City)
                    .Where(ro => ro.City.Title == cityTitle)
                    .Where(ro => ro.BedroomsCount >= bedroomsCount)
                    .Select(ro => ro.id)
                    .ToList();
                var fitOffers = db.Offers.Where(x => x.BookedDates.Any(d => d.Start >= startDate && d.End <= endDate) == false && rentObjsIDs.Any(r => r == x.RentObjId)).ToList();


                //var client = _clientFactory.CreateClient("RentObjApiService");
                //var rez = await client.GetAsync($"/api/rentobj/by-city?city={cityTitle}");
                //if (!rez.IsSuccessStatusCode) return new List<RentObjResponse>();

                //var rez = await _rentObjClient.GetByCityAsync(cityTitle);
                //if (!rez.IsSuccessStatusCode) return new List<OfferResponse>();
                //var con = rez.Content;
                //return new List<OfferResponse>();

                //var rentObjs = await rez.Content.ReadFromJsonAsync<List<RentObjResponse>>();


                if (fitOffers == null || fitOffers.Count == 0) return new List<Offer>();
                return fitOffers;
            }
        }



        private async Task<bool> ValidateUserAsync(int ownerId)
        {
            var client = _clientFactory.CreateClient("UserApiService");

            var resp = await client.GetAsync($"/api/users/{ownerId}");
            return resp.IsSuccessStatusCode;
        }

     
        private async Task<bool> ValidateRentObjectAsync(int rentObjId)
        {
            var client = _clientFactory.CreateClient("RentObjApiService");

            var resp = await client.GetAsync($"/api/rentobj/{rentObjId}");
            return resp.IsSuccessStatusCode;
        }

        Task<List<OfferResponse>> IOfferService.GetMainAvailableOffers(string cityTitle, DateTime startDate, DateTime endDate, int bedroomsCount)
        {
            throw new NotImplementedException();
        }
    }
}
