using Globals.Abstractions;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models;
using OfferContracts;

namespace OfferApiService.Service.Interface
{
    public interface IOfferService : IServiceBaseNew<Offer>
    {
        Task<Offer> GetOnlyOfferAsync(int id, params string[] includeProperties);

        Task<int> AddOfferWithRentObjAndParamValuesAsync(Offer offer);
        Task<int> UpdateOfferWithRentObjAndParamValuesAsyn(Offer offer);
        Task<bool> AddOrderLinkToOffer(int offerId, int orderId);
        Task<List<int>> GetOrdersIdLinkToOffer(int offerId);
        Task<List<Offer>> GetOffersByOwnerIdAsync(int ownerId);
        //Task<List<Offer>> GetOffersByIdAsync(List<int> ids);
        Task<List<Offer>> GetOffersByOwnerIdAndCityAsync(int ownerId, int cityId);
        Task<List<Offer>> GetOffersByOwnerIdAndCountryAsync(int ownerId, int countryId);
        Task<List<Offer>> SearchOffersAsync([FromQuery] OfferSearchRequestByCityAndCountGuest request);
        Task<List<Offer>> SearchOffersFromRegion([FromQuery] OfferSearchRequestByRegionAndCountGuest request);

        Task<List<Offer>> SearchOffersFromCountry([FromQuery] OfferSearchRequestByCountryAndCountGuest request);
    }
}
