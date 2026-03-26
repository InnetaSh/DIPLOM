using Globals.Clients;
using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using OfferContracts;
using OfferContracts.RentObj;
using WebApiGetway.Clients.Interface;


namespace WebApiGetway.Clients
{
    public class OfferApiClient : BaseApiClient, IOfferApiClient
    {

        public OfferApiClient(HttpClient client, ILogger<OfferApiClient> logger)
       : base(client, logger) { }

        //===============================================================================================================
        // Params  
        //===============================================================================================================

        public async Task<IEnumerable<ParamsCategoryResponse>> GetAllParamCategoryWithParams()
        {
            var result = await GetAsync<IEnumerable<ParamsCategoryResponse>>(
                "/api/paramscategory/get-all/filtered");

            return result ?? Enumerable.Empty<ParamsCategoryResponse>();
        }


        //================================================================================================
        // ParamItem
        //================================================================================================
        public async Task<IEnumerable<ParamItemResponse>> GetAllParamsItems()
        {
            var result = await GetAsync<IEnumerable<ParamItemResponse>>(
                "/api/paramitem/get-all");

            return result ?? Enumerable.Empty<ParamItemResponse>();
        }

        //===============================================================================================================
        //    Получить все объявления (для админки)
        //===============================================================================================================

        public async Task<IEnumerable<OfferResponse>> GetAllOffers()
        {
            var result = await GetAsync<IEnumerable<OfferResponse>>(
                "/api/offer/search/all");

            return result ?? Enumerable.Empty<OfferResponse>();
        }


        //================================================================================================
        // Поиск объявлений по городу
        //================================================================================================
        public async Task<IEnumerable<OfferResponse>> GetOffersByCityAsync(
            int cityId,
            DateTime start,
            DateTime end,
            int adults,
            int children,
            int rooms,
            int totalGuests,
            decimal userDiscountPercent)
        {
            var queryDict = new Dictionary<string, string?>
            {
                ["cityId"] = cityId.ToString(),
                ["startDate"] = start.ToString("O"),
                ["endDate"] = end.ToString("O"),
                ["adults"] = adults.ToString(),
                ["children"] = children.ToString(),
                ["rooms"] = rooms.ToString(),
                ["guests"] = totalGuests.ToString(),
                ["userDiscountPercent"] = userDiscountPercent.ToString()
            };

            var queryString = QueryString.Create(queryDict);
            var result = await GetAsync<IEnumerable<OfferResponse>>($"/api/offer/search/offers{queryString}");
            return result ?? Enumerable.Empty<OfferResponse>();
        }
        //================================================================================================
        // Поиск объявлений по региону
        //================================================================================================
        public async Task<IEnumerable<OfferResponse>> GetOffersByRegionAsync(
            int regionId,
            DateTime start,
            DateTime end,
            int adults,
            int children,
            int rooms,
            int totalGuests,
            decimal userDiscountPercent)
        {
            var queryDict = new Dictionary<string, string?>
            {
                ["regionId"] = regionId.ToString(),
                ["startDate"] = start.ToString("O"),
                ["endDate"] = end.ToString("O"),
                ["adults"] = adults.ToString(),
                ["children"] = children.ToString(),
                ["rooms"] = rooms.ToString(),
                ["guests"] = totalGuests.ToString(),
                ["userDiscountPercent"] = userDiscountPercent.ToString()
            };

            var queryString = QueryString.Create(queryDict);
            var result = await GetAsync<IEnumerable<OfferResponse>>($"/api/offer/search/offers/fromRegion{queryString}");
            return result ?? Enumerable.Empty<OfferResponse>();
        }

        //================================================================================================
        // Поиск объявлений по стране
        //================================================================================================
        public async Task<IEnumerable<OfferResponse>> GetOffersByCountryAsync(
            int countryId,
            DateTime start,
            DateTime end,
            int adults,
            int children,
            int rooms,
            int totalGuests,
            decimal userDiscountPercent)
        {
            var queryDict = new Dictionary<string, string?>
            {
                ["countryId"] = countryId.ToString(),
                ["startDate"] = start.ToString("O"),
                ["endDate"] = end.ToString("O"),
                ["adults"] = adults.ToString(),
                ["children"] = children.ToString(),
                ["rooms"] = rooms.ToString(),
                ["guests"] = totalGuests.ToString(),
                ["userDiscountPercent"] = userDiscountPercent.ToString()
            };

            var queryString = QueryString.Create(queryDict);
            var result = await GetAsync<IEnumerable<OfferResponse>>($"/api/offer/search/offers/fromCountry{queryString}");
            return result ?? Enumerable.Empty<OfferResponse>();
        }


        //======================================================================================
        // GET METHODS полные данные об обьявлении по id c дополнительными расчетами (цена с учетом дат, кол-ва гостей и скидки)
        //======================================================================================
        public async Task<OfferResponse> GetFullOfferById(
         int id,
         string? startDate,
         string? endDate,
         int adults,
         int children,
         int rooms,
         decimal userDiscountPercent)
        {
            var query = new Dictionary<string, string?>
            {
                ["StartDate"] = startDate,
                ["EndDate"] = endDate,
                ["Adults"] = adults.ToString(),
                ["Children"] = children.ToString(),
                ["userDiscountPercent"] = userDiscountPercent.ToString()
            };

            var url = QueryHelpers.AddQueryString($"/api/offer/get-offer/{id}", query);

            var result = await GetAsync<OfferResponse>(url);
            return result ?? new OfferResponse();
        }
        //==========================================================================================
        // GET METHODS полные данные об обьявлении по id без дополнительных расчетов
        //==========================================================================================
        public async Task<OfferResponse> GetOfferById(int id)
        {

            var result = await GetAsync<OfferResponse>($"/api/offer/get/{id}");
            return result ?? new OfferResponse();
        }
        //===========================================================================================
        //   GET METHODS получить обьявления по ownerId без дополнительных расчетов
        //===========================================================================================
        public async Task<IEnumerable<OfferResponse>> GetOfferByOwnerId(int ownerId)
        {

            var result = await GetAsync<IEnumerable<OfferResponse>>(
                $"/api/offer/get/offersByOwner/{ownerId}");
            return result ?? Enumerable.Empty<OfferResponse>(); 
        }
        //===========================================================================================
        //   GET METHODS получить обьявления по ownerId и cityId без дополнительных расчетов
        //===========================================================================================
        public async Task<IEnumerable<OfferResponse>> GetOfferByOwnerIdAndCityId(int ownerId, int cityId)
        {

            var result = await GetAsync<IEnumerable<OfferResponse>>(
                $"/api/offer/get/offersByOwnerFromCity/{ownerId}/{cityId}");
            return result ?? Enumerable.Empty<OfferResponse>();
        }

        //===========================================================================================
        //   GET METHODS получить обьявления по ownerId и countryId без дополнительных расчетов
        //===========================================================================================
        public async Task<IEnumerable<OfferResponse>> GetOfferByOwnerIdAndCountryId(int ownerId, int countryId)
        {

            var result = await GetAsync<IEnumerable<OfferResponse>>(
                $"/api/offer/get/offersByOwnerFromCountry/{ownerId}/{countryId}");
            return result ?? Enumerable.Empty<OfferResponse>();
        }

        //===========================================================================================
        // GET METHODS получение RentObjId обьекта оренды по offerId
        //===========================================================================================

        public async Task<int> GetRentObjIdByOfferId(int offerId)
        {
            var result = await GetAsync<int>(
                $"/api/Offer/get/rentobjid/{offerId}");
            return result;
        }


  
        //======================================================================================
        // POST METHODS создание обьявления
        //======================================================================================

        public async Task<int> CreateOffer(OfferRequest offer)
        {

            var result = await PostAsync<int>(
                $"/api/offer/create/offer-with-rentobj-with-param-values", offer);
            return result;
        }

        //======================================================================================
        //редактирование обьявления
        //======================================================================================

        public async Task<OfferResponse?> UpdateOffer(int offerId, OfferRequest offer)
        {

            var result = await PutAsync<OfferResponse>(
                $"/api/offer/update/offer-with-rentobj-with-param-values/{offerId}", offer);
            return result;
        }

        //============================================================================================
        // редактирование цены обьявления
        //============================================================================================
        public async Task<OfferResponse> UpdateOfferPrice(
            int offerId,
            UpdateOfferPriceRequest updateOfferPriceRequest)
        {

            var result = await PutAsync<OfferResponse>(
                $"/api/offer/update/price/booking-offer/{offerId}", updateOfferPriceRequest);
            return result;
        }

       

        //============================================================================================
        //добавление изображений обьявления
        //============================================================================================
        public async Task<string> AddImageOffer(int rentObjId, IFormFile file)
        {
            var result = await PostAsync<string>(
                $"/api/RentObjImage/upload/{rentObjId}",file);
            return result ?? string.Empty;
        }
        //============================================================================================
        // редактирование изображений обьявления
        //============================================================================================

        public async Task<bool> UpdateImageAsync(int imageId, IFormFile file)
        {
            var result = false;
            result = await PutAsync<bool>(
                $"/api/rentobjimage/update-file/{imageId}", file);
            return result;
        }
        //============================================================================================
        //  удаление изображений обьявления
        //============================================================================================
        public async Task<bool> DeleteImageOffer(int imageId)
        {
            var result = false;
            result = await DeleteAsync<bool>(
                $"/api/rentobjimage/update-file/{imageId}");
            return result;
        }

        //==========================================================================================
        //       заблокировать обьявление
        //==========================================================================================
        public async Task<bool> BlockOffer(int offerId)
        {
            return await PutAsync<bool>(
                $"/api/offer/{offerId}/block",
                new { }
            );
        }
        //==========================================================================================
        //       разблокировать обьявление
        //==========================================================================================
        public async Task<bool> UnBlockOffer(int offerId)
        {
            return await PutAsync<bool>(
                $"/api/offer/{offerId}/unblock",
                new { }
            );
        }


        //===========================================================================================
        //  добавление ссылки на заказ в обьявление
        //===========================================================================================
        public async Task<bool> AddOrderToOffersOrderList(int offerId, int orderId)
        {
            return await PostAsync<bool>(
                $"/api/offer/{offerId}/orders/add/{orderId}",
                new { }
            );
        }
        //===============================================================================================================
        // Топ offers за период (week / month / year)
        //===============================================================================================================

        public async Task<IEnumerable<OfferResponseForPupularList>> GetPopularsOffersAsync(List<int> idList)
        {
            var result = await PostAsync<IEnumerable<OfferResponseForPupularList>>(
                "/api/City/search/offers/populars",
                idList);

            return result ?? Enumerable.Empty<OfferResponseForPupularList>();
        }

    }
}
