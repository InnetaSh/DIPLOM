using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using OfferContracts;
using OfferContracts.RentObj;

namespace WebApiGetway.Clients.Interface
{
    public interface IOfferApiClient
    {
        Task<IEnumerable<ParamsCategoryResponse>> GetAllParamCategoryWithParams();
        Task<IEnumerable<ParamItemResponse>> GetAllParamsItems();
        //-------------------------------------------------------------------------------------
        Task<IEnumerable<OfferResponse>> GetAllOffers(string accessToken);

        //-------------------------------------------------------------------------------------
        Task<IEnumerable<OfferResponse>> GetOffersByCityAsync(
            int cityId,
            DateTime start,
            DateTime end,
            int adults,
            int children,
            int rooms,
            int totalGuests,
            decimal userDiscountPercent);

        Task<IEnumerable<OfferResponse>> GetOffersByRegionAsync(
            int regionId,
            DateTime start,
            DateTime end,
            int adults,
            int children,
            int rooms,
            int totalGuests,
            decimal userDiscountPercent);

        Task<IEnumerable<OfferResponse>> GetOffersByCountryAsync(
            int countryId,
            DateTime start,
            DateTime end,
            int adults,
            int children,
            int rooms,
            int totalGuests,
            decimal userDiscountPercent);
        //-------------------------------------------------------------------------------------
        Task<OfferResponse> GetFullOfferById(
         int id,
         string? startDate,
         string? endDate,
         int adults,
         int children,
         int rooms,
         decimal userDiscountPercent);

        //-------------------------------------------------------------------------------------
        Task<OfferResponse> GetOfferById(int id);
        Task<IEnumerable<OfferResponse>> GetOfferByOwnerId(int ownerId);
        Task<IEnumerable<OfferResponse>> GetOfferByOwnerIdAndCityId(int ownerId, int cityId);
        Task<IEnumerable<OfferResponse>> GetOfferByOwnerIdAndCountryId(int ownerId, int countryId);
        Task<int> GetRentObjIdByOfferId(int offerId);

        //-------------------------------------------------------------------------------------

        Task<int> CreateOffer(OfferRequest offer);
        Task<OfferResponse?> UpdateOffer(int offerId, OfferRequest offer);
        Task<OfferResponse> UpdateOfferPrice(
            int offerId,
            UpdateOfferPriceRequest updateOfferPriceRequest);
        Task<string> AddImageOffer(int rentObjId, IFormFile file);
        Task<bool> UpdateImageAsync(int imageId, IFormFile file);
        Task<bool> DeleteImageOffer(int imageId);
        Task<bool> BlockOffer(int offerId);
        Task<bool> UnBlockOffer(int offerId);
        Task<bool> AddOrderToOffersOrderList(int offerId, int orderId);

        Task<IEnumerable<OfferResponseForPupularList>> GetPopularsOffersAsync(List<int> idList);
    };
}
