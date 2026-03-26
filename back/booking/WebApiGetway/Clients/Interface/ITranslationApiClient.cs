using LocationContracts;
using TranslationContracts;
using WebApiGetway.View;

namespace WebApiGetway.Clients.Interface
{
    public interface ITranslationApiClient
    {
        //=============================================================================
        //      locations
        //=============================================================================

        Task<TranslationResponse> GetCityTranslationByIdAsync(int cityId, string lang);
        Task<IEnumerable<TranslationResponse>> GetAllCitiesTranslationsAsync(string lang);
        //-------------------------------------------------------------------------------------
        Task<TranslationResponse> GetRegionTranslationByIdAsync(int regionId, string lang);
        Task<IEnumerable<TranslationResponse>> GetAllRegionsTranslationsAsync(string lang);

        //-------------------------------------------------------------------------------------
        Task<TranslationResponse> GetCountryTranslationByIdAsync(int countryId, string lang);
        Task<IEnumerable<TranslationResponse>> GetAllCountriesTranslationsAsync(string lang);

        //-------------------------------------------------------------------------------------
        Task<TranslationResponse> GetDistrictyTranslationByIdAsync(int countryId, string lang);
        Task<IEnumerable<TranslationResponse>> GetAllDistrictTranslationsAsync(string lang);


        //===============================================================================================================
        //  attraction  translation
        //===============================================================================================================

        Task<TranslationResponse?> GetAttractionTranslationByIdAsync(int attractionId, string lang);
        Task<IEnumerable<TranslationResponse>> GetAllAttractionsTranslationsAsync(string lang);
        //=============================================================================
        //    offer translation
        //=============================================================================

        Task<IEnumerable<TranslationResponse>> GetParamsCategotiesTranslationAsync(string lang);
        Task<IEnumerable<TranslationResponse>> GetParamsItemTranslationAsync(string lang);
        //-------------------------------------------------------------------------------------
        Task<IEnumerable<TranslationResponse>> GetAllOffersTranslationAsync(string lang);
        Task<TranslationResponse> GetOfferTranslationByIdAsync(int offerId,string lang);

        Task<TranslationResponse> AddOfferTranslationAsync(TranslationRequest translated, string lang);


        //===============================================================================================================
        //   review  translation
        //===============================================================================================================
        Task<TranslationResponse> AddReviewTranslationAsync(TranslationRequest translated, string lang);
        Task<TranslationResponse> UpdateReviewTranslationAsync(TranslationRequest translated, string lang);
        Task<TranslationResponse> DeleteReviewTranslationAsync(int reviewI);

        Task<TranslationResponse?> GetReviewTranslationByIdAsync(int reviewId, string lang);
        Task<IEnumerable<TranslationResponse>> GetAllReviewsTranslationsAsync(string lang);
    }

}
