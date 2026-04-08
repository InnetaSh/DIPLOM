using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using OfferContracts;
using OfferContracts.RentObj;
using ReviewContracts;
using System.Threading.Tasks;
using TranslationContracts;
using UserContracts;

namespace WebApiGetway.Service.Interfase
{
    public interface IOfferBffService
    {
        //=============================================================================
        //      PARAMS
        //=============================================================================
        Task<IEnumerable<ParamsCategoryResponse>> GetAllParamCategoryWithParamsAndTranslations(string lang);
        Task<IEnumerable<ParamItemResponse>> GetMainParamItem(string lang);

        //=============================================================================
        //      OFFERS
        //=============================================================================
        Task<IEnumerable<OfferResponse>> GetAllOffers(string lang,string accessToken);
        Task<IEnumerable<OfferShortResponse>> GetOffersBySearchCriteria(
           int? userId,
           decimal userDiscountPercent,
           string lang,
           int? cityId,
           int? regionId,
           int? countryId,
           DateOnly? startDate = null,
           DateOnly? endDate = null,
           int adults = 1,
           int children = 0,
           int rooms = 1,
           string? paramItemFilters = null);

        Task<OfferResponse?> GetFullOfferById(
         string? accessToken,
         int userId,
         int offerId,
         string lang,
         DateOnly? startDate = null,
         DateOnly? endDate = null,
         int adults = 1,
         int children = 0,
         int rooms = 1,
         decimal userDiscountPercent = 0);

        Task<OfferResponse> GetOfferByIdForOrderHistory(
             int offerId,
             int orderId,
             string lang);

        //===============================================================================================================
        //Task<IEnumerable<ReviewResponse>> GetReviewsByOfferId(
        //   int offerId,
        //   string lang);

      
        //===============================================================================================================

        Task<int> CreateOffer(
            int userId,
            OfferRequest offer,
            string lang,
            string accessToken);

        //===============================================================================================================

        Task<OfferResponse> UpdateOffer(
              int offerId,
              OfferRequest offer,
              string lang,
              string accessToken);

        Task<int> UpdateOfferPrice(
            int offerId,
            UpdateOfferPriceRequest updateOfferPriceRequest,
            string lang,
            string accessToken);
        Task<int> UpdateTextOffer(
            TranslationRequest request,
            string lang,
            string accessToken);

        //===============================================================================================================

        Task<IEnumerable<string>> AddImageOffer(
          int offerId,
          List<IFormFile> files,
          string accessToken);
        Task<UpdateImageOfferResponse> UpdateImageOffer(
            int offerId,
            int imageId,
            IFormFile file,
            string accessToken);
        
        Task<bool> DeleteImageOffer(
            int offerId,
            int imageId,
          string accessToken);
   
        //===============================================================================================================
        Task<bool> SetOfferBlockStatus(int offerId, bool block, string accessToken);
        //===============================================================================================================
        Task<IEnumerable<OfferResponseForPupularList>> GetPopularTopOffer(
            string period,
            int limit,
            string lang);
    }
}
