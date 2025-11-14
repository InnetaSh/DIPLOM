using Globals.Sevices;
using OfferApiService.Models;
using OfferApiService.Service.Interface;
using System.Net.Http.Json;

namespace OfferApiService.Services
{
    public class OfferService : TableServiceBase<Offer, OfferContext>, IOfferService
    {
        private readonly IHttpClientFactory _clientFactory;

        public OfferService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        
        public override async Task<bool> AddEntityAsync(Offer offer)
        {
           
            var userExists = await ValidateUserAsync(offer.OwnerId);
            if (!userExists)
                throw new Exception("Owner does not exist");

           
            var rentObjExists = await ValidateRentObjectAsync(offer.RentObjId);
            if (!rentObjExists)
                throw new Exception("Rent object does not exist");

            return await base.AddEntityAsync(offer);
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
    }
}
