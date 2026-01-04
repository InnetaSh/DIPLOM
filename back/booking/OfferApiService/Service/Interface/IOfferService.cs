using Globals.Abstractions;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models;
using OfferApiService.View;

namespace OfferApiService.Service.Interface
{
    public interface IOfferService : IServiceBase<Offer>
    {
        Task<bool> AddOrderLinkToOffer(int offerId, int orderId);
        Task<List<int>> GetOrdersIdLinkToOffer(int offerId);
        Task<List<Offer>> SearchOffersAsync([FromQuery] OfferSearchRequestByCityAndCountGuest request);
    }
}
