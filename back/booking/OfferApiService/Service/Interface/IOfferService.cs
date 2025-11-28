using Globals.Abstractions;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models;
using OfferApiService.Models.View;
using OfferApiService.View;

namespace OfferApiService.Service.Interface
{
    public interface IOfferService : IServiceBase<Offer>
    {
        Task<List<Offer>> GetMainAvailableOffers([FromQuery] OfferMainSearchRequest request);
    }
}
