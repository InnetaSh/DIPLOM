using Globals.Clients;
using LocationContracts;
using TranslationContracts;
using WebApiGetway.Clients.Interface;
using WebApiGetway.Service.Interfase;
using WebApiGetway.View;

namespace WebApiGetway.Clients
{
    public class TranslationApiClient : BaseApiClient, ITranslationApiClient
    {
        public TranslationApiClient(HttpClient client, ILogger<TranslationApiClient> logger)
            : base(client, logger) { }
     
        //===============================================================================================================
        //     CITY  translation
        //===============================================================================================================

        public Task<TranslationResponse?> GetCityTranslationByIdAsync(int cityId, string lang)
        {
            return GetAsync<TranslationResponse>(
                $"/api/cityTranslation/get-translation-byId/{cityId}/{lang}");
        }
        
    
        public async Task<IEnumerable<TranslationResponse>> GetAllCitiesTranslationsAsync(string lang)
        {
            var result = await GetAsync<IEnumerable<TranslationResponse>>(
                $"/api/cityTranslation/get-all-translations/{lang}");

            return result ?? Enumerable.Empty<TranslationResponse>();
        }
        //===============================================================================================================
        //    DISTICT  translation
        //===============================================================================================================

        public Task<TranslationResponse?> GetDistrictyTranslationByIdAsync(int districtId, string lang)
        {
            return GetAsync<TranslationResponse>(
                $"/api/districtTranslation/get-translation-byId/{districtId}/{lang}");
        }


        public async Task<IEnumerable<TranslationResponse>> GetAllDistrictTranslationsAsync(string lang)
        {
            var result = await GetAsync<IEnumerable<TranslationResponse>>(
                $"/api/districtTranslation/get-all-translations/{lang}");

            return result ?? Enumerable.Empty<TranslationResponse>();
        }


        //===============================================================================================================
        //    REGION  translation
        //===============================================================================================================

        public Task<TranslationResponse?> GetRegionTranslationByIdAsync(int regionId, string lang)
        {
            return GetAsync<TranslationResponse>(
                $"/api/regionTranslation/get-translation-byId/{regionId}/{lang}");
        }

        //---------------------------------------------------------------------------------------------------------------

        public async Task<IEnumerable<TranslationResponse>> GetAllRegionsTranslationsAsync(string lang)
        {
            var result = await GetAsync<IEnumerable<TranslationResponse>>(
                $"/api/regionTranslation/get-all-translations/{lang}");

            return result ?? Enumerable.Empty<TranslationResponse>();
        }


        //===============================================================================================================
        //   COUNTRY  translation
        //===============================================================================================================

        public Task<TranslationResponse?> GetCountryTranslationByIdAsync(int countryId, string lang)
        {
            return GetAsync<TranslationResponse>(
                $"/api/countryTranslation/get-translation-byId/{countryId}/{lang}");
        }

        //---------------------------------------------------------------------------------------------------------------

        public async Task<IEnumerable<TranslationResponse>> GetAllCountriesTranslationsAsync(string lang)
        {
            var result = await GetAsync<IEnumerable<TranslationResponse>>(
                $"/api/countryTranslation/get-all-translations/{lang}");

            return result ?? Enumerable.Empty<TranslationResponse>();
        }



        //===============================================================================================================
        //    ATTRACTIONS  translation
        //===============================================================================================================

        public Task<TranslationResponse?> GetAttractionTranslationByIdAsync(int attractionId, string lang)
        {
            return GetAsync<TranslationResponse>(
                $"/api/attractionTranslation/get-translation-byId/{attractionId}/{lang}");
        }

        //---------------------------------------------------------------------------------------------------------------

        public async Task<IEnumerable<TranslationResponse>> GetAllAttractionsTranslationsAsync(string lang)
        {
            var result = await GetAsync<IEnumerable<TranslationResponse>>(
                $"/api/attractionTranslation/get-all-translations/{lang}");

            return result ?? Enumerable.Empty<TranslationResponse>();
        }


        //===============================================================================================================
        //     OFFER  translation
        //===============================================================================================================

        public async Task<IEnumerable<TranslationResponse>> GetParamsCategotiesTranslationAsync(string lang)
        {
            var result = await GetAsync<IEnumerable<TranslationResponse>>(
                $"/api/ParamsCategoryTranslation/get-all-translations/{lang}");

            return result ?? Enumerable.Empty<TranslationResponse>();
        }

        //---------------------------------------------------------------------------------------------------------------

        public async Task<IEnumerable<TranslationResponse>> GetParamsItemTranslationAsync(string lang)
        {
            var result = await GetAsync<IEnumerable<TranslationResponse>>(
                $"/api/ParamItemTranslation/get-all-translations/{lang}");

            return result ?? Enumerable.Empty<TranslationResponse>();
        }
        //---------------------------------------------------------------------------------------------------------------
        public async Task<IEnumerable<TranslationResponse>> GetAllOffersTranslationAsync(string lang)
        {
            var result = await GetAsync<IEnumerable<TranslationResponse>>(
                $"/api/offerTranslation/get-all-translations/{lang}");

            return result ?? Enumerable.Empty<TranslationResponse>();
        }

        //---------------------------------------------------------------------------------------------------------------
        public async Task<TranslationResponse>AddOfferTranslationAsync(TranslationRequest translated, string lang)
        {
            var result = await PostAsync<TranslationResponse>(
                $"/api/offerTranslation/create-translations/{lang}", translated);

            return result ?? new TranslationResponse();
        }

        //---------------------------------------------------------------------------------------------------------------
        public async Task<TranslationResponse> GetOfferTranslationByIdAsync(int offerId, string lang)
        {
            var result = await GetAsync<TranslationResponse>(
                $"/api/offerTranslation/get-translation-byId/{offerId}/{lang}");

            return result ?? new TranslationResponse();
        }

        //===============================================================================================================
        //     REVIEWS  translation
        //===============================================================================================================

        public async Task<TranslationResponse> AddReviewTranslationAsync(TranslationRequest translated, string lang)
        {
            var result = await PostAsync<TranslationResponse>(
                $"/api/reviewTranslation/create-translations/{lang}", translated);

            return result ?? new TranslationResponse();
        }
       
        //===========================================================================================
        public Task<TranslationResponse?> GetReviewTranslationByIdAsync(int reviewId, string lang)
        {
            return GetAsync<TranslationResponse>(
                $"/api/reviewTranslation/get-translation-byId/{reviewId}/{lang}");
        }


        public async Task<IEnumerable<TranslationResponse>> GetAllReviewsTranslationsAsync(string lang)
        {
            var result = await GetAsync<IEnumerable<TranslationResponse>>(
                $"/api/reviewTranslation/get-all-translations/{lang}");

            return result ?? Enumerable.Empty<TranslationResponse>();
        }
        
        //===========================================================================================
        public async Task<TranslationResponse> UpdateReviewTranslationAsync(TranslationRequest translated, string lang)
        {
            var result = await PutAsync<TranslationResponse>(
                $"/api/reviewTranslation/update-translations/{translated.EntityId}/{lang}", translated);

            return result ?? new TranslationResponse();
        }
       
        //===========================================================================================

        public async Task<TranslationResponse> DeleteReviewTranslationAsync(int reviewId)
        {
            var result = await DeleteAsync<TranslationResponse>(
                $"/api/reviewTranslation/del-translations/{reviewId}");

            return result ?? new TranslationResponse();
        }

    }
}
