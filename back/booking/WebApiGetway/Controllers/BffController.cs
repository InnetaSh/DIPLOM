
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using WebApiGetway.Service.Interfase;
using WebApiGetway.View;
using Microsoft.Extensions.Caching.Memory;
using System.Net.WebSockets;
using WebApiGetway.Models.Enum;

namespace WebApiGetway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BffController : ControllerBase
    {
        private readonly IGatewayService _gateway;
        private readonly IMemoryCache _cache;
        public BffController(IGatewayService gateway, IMemoryCache cache)
        {
            _gateway = gateway;
            _cache = cache;
        }



        //=============================================================================
        //                      получаем список названий городов 
        //=============================================================================

        [HttpGet("city/get-all-translations/{lang}")]
        public async Task<IActionResult> GetAllCity(string lang)
        {
            var result = await _gateway.ForwardRequestAsync<object>(
                "TranslationApiService",
                $"/api/City/get-all-translations/{lang}",
                HttpMethod.Get,
                null
            );

            return Ok(result);
        }



        //=============================================================================
        //            получаем список названий категорий и параметров для фильтра
        //=============================================================================


        [HttpGet("params/category/{lang}")]
        public async Task<IActionResult> GetMainParamCategory(string lang)
        {
            // Получаем список параметров
            var paramCategotyObjResult = await _gateway.ForwardRequestAsync<object>(
                "OfferApiService",
                $"/api/paramscategory/get-all/filtered",
                HttpMethod.Get, null
                );

            if (paramCategotyObjResult is not OkObjectResult okParamCategory)
                return paramCategotyObjResult;
            var paramDictList = BffHelper.ConvertActionResultToDict(okParamCategory);

            // Получаем список переводов
            var translateListResult = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/ParamCategory/get-all-translations/{lang}", HttpMethod.Get, null);
            if (translateListResult is not OkObjectResult okTranslate)
                return paramCategotyObjResult;
            var translations = BffHelper.ConvertActionResultToDict(okTranslate);


            // Обновляем список 
            BffHelper.UpdateListWithTranslations(paramDictList, translations);


            // получаем список названий параметров для главного екрана
            var translateItemListResult = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/paramitem/get-all-translations/{lang}", HttpMethod.Get, null);
            var transItemDict = BffHelper.ConvertActionResultToDict(translateItemListResult as OkObjectResult);
            foreach(var param in paramDictList)
            {
                if (param["items"] is List<Dictionary<string, object>> itemsDictList)
                    BffHelper.UpdateListWithTranslations(itemsDictList, transItemDict);
            }
            return Ok(paramDictList);
        }


        //=============================================================================
        //                      получаем список названий параметров
        //=============================================================================


        [HttpGet("paramitem/{lang}")]
        public async Task<IActionResult> GetMainParamItem(string lang)
        {
            // Получаем список параметров
            var paramItemObjResult = await _gateway.ForwardRequestAsync<object>(
                "OfferApiService",
                $"/api/paramitem/get-all",
                HttpMethod.Get, null
                );
            if (paramItemObjResult is not OkObjectResult okParamItem)
                return paramItemObjResult;
            var paramDictList = BffHelper.ConvertActionResultToDict(okParamItem);


            var translateListResult = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/paramitem/get-all-translations/{lang}", HttpMethod.Get, null);
            if (translateListResult is not OkObjectResult okTranslate)
                return paramItemObjResult;
            var translations = BffHelper.ConvertActionResultToDict(okTranslate);

            BffHelper.UpdateListWithTranslations(paramDictList, translations);

            return Ok(paramDictList);
        }
        
        
        //=====================================================================================
        //      получаем список обьявлений по запросу(город, даты и параметры(если они есть))
        //=====================================================================================

        [HttpGet("search/offers/{lang}")]
        public async Task<IActionResult> GetSearchOffers(
            string lang,
            [FromQuery] int CityId,
            [FromQuery] DateTime StartDate,
            [FromQuery] DateTime EndDate,
            [FromQuery] int Guests,
            [FromQuery] string paramItemFilters = null)
        {
            decimal userDiscountPercent = 0;
            int? userId = null;

            if (User.Identity?.IsAuthenticated == true)
            {
                (userId, userDiscountPercent) = await GetUserIdAndDiscountAsync();
            }

            var offerQuery = QueryString.Create(new Dictionary<string, string?>
            {
                ["cityId"] = CityId.ToString(),
                ["guests"] = Guests.ToString(),
                ["userDiscountPercent"] = userDiscountPercent.ToString(),
                ["startDate"] = StartDate.ToString("O"),
                ["endDate"] = EndDate.ToString("O"),
            });

            var offerObjResult = await _gateway.ForwardRequestAsync<object>(
                "OfferApiService",
                $"/api/offer/search/offers{offerQuery}",
                HttpMethod.Get,
                null);

            if (offerObjResult is not OkObjectResult okOffer)
                return offerObjResult;

            var offerDictList = BffHelper.ConvertActionResultToDict(okOffer);
            var filterDicts = ParseParamFiltersToDict(paramItemFilters);
            var filteredOfferList = new List<Dictionary<string, object>>();

            var dateConflictCache =
                new Dictionary<(int offerId, DateTime start, DateTime end), bool>();


            var idList = new List<int>();
            foreach (var offer in offerDictList)
            {
                if (!TryGetOfferId(offer, out var offerId))
                    continue;
                var id = int.Parse(offer["id"].ToString());
                idList.Add(id);

                var cacheKey = (offerId, StartDate, EndDate);

                if (!dateConflictCache.TryGetValue(cacheKey, out var hasConflict))
                {
                    hasConflict = await HasDateConflictAsync(
                        offerId, StartDate, EndDate);

                    dateConflictCache[cacheKey] = hasConflict;
                }

                if (!hasConflict)
                    continue;

                if (!filterDicts.Any())
                {
                    filteredOfferList.Add(offer);
                    continue;
                }

                if (!TryGetParamValues(offer, out var paramValues))
                    continue;

                if (MatchAllFilters(paramValues, filterDicts))
                    filteredOfferList.Add(offer);

                var entityStatEventRequest = new EntityStatEventRequest
                {
                    EntityId = offerId,
                    EntityType = "Offer",
                    ActionType = "Search",
                    UserId = userId
                };
                await SendStatEvent(entityStatEventRequest, "Offer");
            }

            var entityStatCityEventRequest = new EntityStatEventRequest
            {
                EntityId = CityId,
                EntityType = "City",
                ActionType = "Search",
                UserId = userId
            };
            await SendStatEvent(entityStatCityEventRequest, "City");

            var offerTranslations = await GetTranslationsAsync(lang, "Offer");
            var updateOfferDictList = BffHelper.UpdateListWithTranslations(filteredOfferList, offerTranslations);


            //получаем рейтинг
            var ratingObjResult = await _gateway.ForwardRequestAsync<object>("ReviewApiService", $"/api/review/search/offers/rating", HttpMethod.Get, idList);
            if (ratingObjResult is not OkObjectResult okRating)
                return ratingObjResult;
            var ratingDictList = BffHelper.ConvertActionResultToDict(okRating);

            BffHelper.UpdateOfferListWithRating(updateOfferDictList, ratingDictList);
            return Ok(updateOfferDictList);
        }



        //======================================================================================
        //                      получаем полные данные об обьявлении по id
        //======================================================================================


        [HttpGet("search/booking-offer/{id}/{lang}")]
        public async Task<IActionResult> GetFullOfferById(int id, 
          string lang,
         [FromQuery] OfferByDataAndCountGuestRequest request,
         [FromQuery] decimal userDiscountPercent)
        {
            var queryString = Request.QueryString.Value ?? string.Empty;

            var offerObjResult = await _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/offer/get-offer/{id}{queryString}", HttpMethod.Get, null);

            if (offerObjResult is not OkObjectResult okOffer)
                return offerObjResult;

            var offerDictList = BffHelper.ConvertActionResultToDict(okOffer);
            var offer = offerDictList[0];
            var rentObj = (offer["rentObj"] as List<Dictionary<string, object>>)[0];

            var countryId = int.Parse(rentObj["countryId"].ToString());
            var regionId = int.Parse(rentObj["regionId"].ToString());
            var cityId = int.Parse(rentObj["cityId"].ToString());
            var districtId = int.Parse(rentObj["districtId"].ToString());

            //-----------

            var translateOffer = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Offer/get-translations/{id}/{lang}", HttpMethod.Get, null);
            var titleOffer = GetStringFromActionResult(translateOffer, "title");
            var descriptionOffer = GetStringFromActionResult(translateOffer, "description");

            var translateCountry = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Country/get-translations/{countryId}/{lang}", HttpMethod.Get, null);
            var countryTitle = GetStringFromActionResult(translateCountry, "title");

            var translateRegion = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Region/get-translations/{regionId}/{lang}", HttpMethod.Get, null);
            var regionTitle = GetStringFromActionResult(translateRegion, "title");

            var translateCity = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/City/get-translations/{cityId}/{lang}", HttpMethod.Get, null);
            var cityTitle = GetStringFromActionResult(translateCity, "title");

            var translateDistrict = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/District/get-translations/{districtId}/{lang}", HttpMethod.Get, null);
            var districtTitle = GetStringFromActionResult(translateDistrict, "title");


            //----------

            offer["title"] = titleOffer;
            offer["description"] = descriptionOffer;
            offer["countryTitle"] = countryTitle;
            offer["regionTitle"] = regionTitle;
            offer["cityTitle"] = cityTitle;
            offer["districtTitle"] = districtTitle;

            //----------

            var paramItems = (rentObj["paramValues"] as List<Dictionary<string, object>>);

            var translateParamListResult = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/paramitem/get-all-translations/{lang}", HttpMethod.Get, null);
            var transItemDict = BffHelper.ConvertActionResultToDict(translateParamListResult as OkObjectResult);

            BffHelper.UpdateListWithTranslations(paramItems, transItemDict);


            var imagesObjList = (rentObj["images"] as List<Dictionary<string, object>>);
            var imagesArray = new List<string>();
            for (int i = 0; i < imagesObjList.Count; i++) {
                var image = imagesObjList[i] as Dictionary<string, object>;
                var imageTitle = image["url"].ToString();
                imagesArray.Add(imageTitle);
            }

            
            //var ImagesUrl = (rentObj["imagesUrl"] as List<string>);

            rentObj["imagesUrl"] =  imagesArray;

            var userId = 0;
            if (User.Identity?.IsAuthenticated == true)
            {
                await _gateway.ForwardRequestAsync<object>(
                    "UserApiService",
                    $"/api/user/me/history/add/offer/{id}",
                    HttpMethod.Post,
                    null
                );
                userId = GetUserId();
                if (userId == null)
                    return Unauthorized();

            }


            var entityStatEventRequest = new EntityStatEventRequest
            {
                EntityId = id,
                EntityType = "Offer",
                ActionType = "View",
                UserId = userId
            };
            var entityStatCityEventRequest = new EntityStatEventRequest
            {
                EntityId = cityId,
                EntityType = "City",
                ActionType = "View",
                UserId = userId
            };
            await SendStatEvent(entityStatEventRequest, "Offer");
            await SendStatEvent(entityStatCityEventRequest, "City");



            //получаем рейтинг
            var ratingObjResult = await _gateway.ForwardRequestAsync<object>("ReviewApiService", $"/api/review/search/offers/rating/{id}", HttpMethod.Get, null);
            if (ratingObjResult is not OkObjectResult okRating)
                return ratingObjResult;
            var ratingDictList = BffHelper.ConvertActionResultToDict(okRating);

            BffHelper.UpdateOfferListWithRating(offerDictList, ratingDictList);

            return Ok(offerDictList);

        }


        // =======================================================================================
        //                          CLIENT: добавить заказ в избранное
        // =======================================================================================

        [Authorize]
        [HttpPost("me/offer/isfavorite/add/{offerId}")]
        public async Task<IActionResult> AddOfferToClientFavorite(
            int offerId)
        {
            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();

            var result = await _gateway.ForwardRequestAsync<object>(
                "UserApiService",
                $"/api/user/me/isfavorite/add/offer/{offerId}",
                HttpMethod.Post,
                null
            );
            return result;

        }


        //============================================================================================
        //                           ближайшие  достопримечательности
        //============================================================================================

            [HttpGet("search/booking-offer/attractions/{id}/{distance}/{lang}")]
        public async Task<IActionResult> GetNearSttractionsByIdWithDistance(int id,
        decimal distance,
        string lang)
        {
            var offerObjResult = await _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/offer/get/{id}", HttpMethod.Get, null);
            if (offerObjResult is not OkObjectResult okOffer)
                return offerObjResult;
            var offerDictList = BffHelper.ConvertActionResultToDict(okOffer);

            var offer = offerDictList[0];
            var rentObj = (offer["rentObj"] as List<Dictionary<string, object>>)[0];

     
            var latitude = decimal.Parse(rentObj["latitude"].ToString());
            var longitude = decimal.Parse(rentObj["longitude"].ToString());


            var attractionsObjResult = await _gateway.ForwardRequestAsync<object>(
                "AttractionApiService",
                $"/api/Attraction/near/by-distance/{latitude}/{longitude}/{distance}",
                HttpMethod.Get,
                null
            );


            if (attractionsObjResult is not OkObjectResult okAttraction)
                return attractionsObjResult;
            var attractionDictList = BffHelper.ConvertActionResultToDict(okAttraction);


            var translateList = await GetTranslationsAsync(lang, "attraction");

    
            var updateAttractionList = BffHelper.UpdateListWithTranslations(attractionDictList, translateList);

            return Ok(updateAttractionList);
        }





        //============================================================================================
        //                           создание обьявления
        //============================================================================================
        [HttpPost("create/booking-offer")]
        [Authorize]
        public async Task<IActionResult> CreateOffer(
             [FromBody] CreateOfferFullRequest createOfferFullRequest,
             string lang)
        {

            var ownerValidation = await ValidateOwnerAsync();
            if (!ownerValidation.IsOwner)
                return ownerValidation.ErrorResult;


            createOfferFullRequest.Offer.OwnerId = ownerValidation.UserId;

            var cityResult = await _gateway.ForwardRequestAsync<object>(
                "LocationApiService",
                $"/api/City/get/{createOfferFullRequest.RentObj.CityId}",
                HttpMethod.Get,
                null
            );
            if (cityResult is not OkObjectResult okCityResult)
                return cityResult;

            var cityDictList = BffHelper.ConvertActionResultToDict(okCityResult);
            var cityObj = cityDictList[0];
            var cityLongitude = double.Parse(cityObj["longitude"].ToString());
            var cityLatitude = double.Parse(cityObj["latitude"].ToString());

            createOfferFullRequest.RentObj.CityLatitude = cityLatitude;
            createOfferFullRequest.RentObj.CityLongitude = cityLongitude;


            var offerIdResult = await _gateway.ForwardRequestAsync<object>(
                "OfferApiService",
                "/api/Offer/create/offer-with-rentobj-with-param-values",
                HttpMethod.Post,
                createOfferFullRequest
            );

            if (offerIdResult is not OkObjectResult okOfferId)
                return offerIdResult;

            var offerIdList = BffHelper.ConvertActionResultToDict(okOfferId);
            var offerIdObj = offerIdList[0];
            var offerId = int.Parse(offerIdObj["id"].ToString());


            var translateOfferRequest = new TranslationDto
            {
                EntityId = offerId,
                Lang = lang,
                Title = createOfferFullRequest.Offer.Title,
                TitleInfo = createOfferFullRequest.Offer.TitleInfo,
                Description = createOfferFullRequest.Offer.Description
            };

            var translateResult = await _gateway.ForwardRequestAsync<object>(
                "TranslationApiService",
                $"/api/Offer/create-translations/{lang}",
                HttpMethod.Post,
                translateOfferRequest
            );

            var addToOwnerLink = await _gateway.ForwardRequestAsync<object>(
              "UserApiService",
              $"/api/User/owner/offers/add/{offerId}",
              HttpMethod.Post,
              translateOfferRequest
          );

            return Ok(offerId);
        }




        //============================================================================================
        //                             редактирование обьявления
        //============================================================================================
        [HttpPut("update/booking-offer")]
        [Authorize]
        public async Task<IActionResult> UpdateOffer(
             [FromBody] UpdateOfferFullRequest updateOfferFullRequest,
             string lang)
        {
            var offerId = updateOfferFullRequest.Offer.id;

            var isValidResult = await _gateway.ForwardRequestAsync<object>(
                "UserApiService",
                $"api/user/valid/offers/{offerId}",
                HttpMethod.Get,
                null
            );

            if (isValidResult is not OkObjectResult okIsValid)
                return isValidResult;

            if (okIsValid.Value is not JsonElement json || !json.GetBoolean())
                return Forbid();

     
            var offerUpdateResult = await _gateway.ForwardRequestAsync<object>(
                    "OfferApiService",
                    "/api/Offer/update/offer-with-rentobj-with-param-values",
                    HttpMethod.Put,
                    updateOfferFullRequest
                );

                if (offerUpdateResult is not OkObjectResult okOfferUpdate)
                    return offerUpdateResult;

            var offerIdList = BffHelper.ConvertActionResultToDict(okOfferUpdate);
            var offerIdObj = offerIdList[0];
             var newOfferId = int.Parse(offerIdObj["id"].ToString());
            if (newOfferId != offerId)
            {
                return BadRequest("Offer ID mismatch after update.");
            }

            var translateOfferRequest = new TranslationDto
                {
                    EntityId = offerId,
                    Lang = lang,
                    Title = updateOfferFullRequest.Offer.Title,
                    Description = updateOfferFullRequest.Offer.Description
                };

                var translateResult = await _gateway.ForwardRequestAsync<object>(
                    "TranslationApiService",
                    $"/api/Offer/update-translations/{offerId}/{lang}",
                    HttpMethod.Put,
                    translateOfferRequest
                );
            
            return Ok(offerId);
        }

        //============================================================================================
        //                                 редактирование цены обьявления
        //============================================================================================
        [HttpPut("update/price/booking-offer/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateOfferPrice(int id,
             [FromBody] UpdateOfferPriceRequest updateOfferPriceRequest,
             string lang)
        {
            var offerId = id;

            var isValidResult = await _gateway.ForwardRequestAsync<object>(
                "UserApiService",
                $"api/user/valid/offers/{offerId}",
                HttpMethod.Get,
                null
            );

            if (isValidResult is not OkObjectResult okIsValid)
                return isValidResult;

            if (okIsValid.Value is not JsonElement json || !json.GetBoolean())
                return Forbid();

            var offerUpdateResult = await _gateway.ForwardRequestAsync<object>(
                    "OfferApiService",
                    $"/api/Offer/update/price/booking-offer/{id}",
                    HttpMethod.Put,
                    updateOfferPriceRequest
                );

                if (offerUpdateResult is not OkObjectResult okOfferUpdate)
                    return offerUpdateResult;

                var offerIdList = BffHelper.ConvertActionResultToDict(okOfferUpdate);
                var offerIdObj = offerIdList[0];
                var offerIdResponse = int.Parse(offerIdObj["idOffer"].ToString());
                if (offerIdResponse != offerId)
                {
                    return BadRequest("Offer ID mismatch after price update.");
                }
            
            return Ok(offerId);
        }


        //============================================================================================
        //                               редактирование текста обьявления
        //============================================================================================
        [HttpPut("update/text/booking-offer/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateTextOffer(int id,
             [FromBody] UpdateTextOfferRequest request,
             string lang)
        {
            var offerId = id;

            var isValidResult = await _gateway.ForwardRequestAsync<object>(
             "UserApiService",
             $"api/user/valid/offers/{offerId}",
             HttpMethod.Get,
             null
         );
            if (isValidResult is not OkObjectResult okIsValid)
                return isValidResult;

            if (okIsValid.Value is JsonElement json &&
                json.GetBoolean())
            {
                var translateOfferRequest = new TranslationDto
                {
                    EntityId = offerId,
                    Lang = lang,
                    Title = request.Title,
                    Description = request.Description
                };

                var translateResult = await _gateway.ForwardRequestAsync<object>(
                    "TranslationApiService",
                    $"/api/Offer/update-translations/{offerId}/{lang}",
                    HttpMethod.Put,
                    translateOfferRequest
                );
            }

            return Ok(offerId);
        }

        //============================================================================================
        //                            добавление изображений обьявления
        //============================================================================================
        [HttpPost("img/booking-offer/{offerId}/add")]
        [Authorize]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddImageOffer(
         [FromRoute] int offerId,
         [FromForm] ImageOfferRequest request)
        {
            var file = request.File;
            if (file == null || file.Length == 0)
                return BadRequest("Файл не передан");

           

            var isValidResult = await _gateway.ForwardRequestAsync<object>(
                "UserApiService",
                $"api/user/valid/offers/{offerId}",
                HttpMethod.Get,
                null
            );

            if (isValidResult is not OkObjectResult okIsValid)
                return isValidResult;

            if (okIsValid.Value is not JsonElement json || !json.GetBoolean())
                return Forbid();


            var rentobjidResult = await _gateway.ForwardRequestAsync<object>(
                  "OfferApiService",
                 $"/api/Offer/get/rentobjid/{offerId}",
                  HttpMethod.Get,
                  null
              );

            if (rentobjidResult is not OkObjectResult okRentObjId)
                return rentobjidResult;

            var RentObjIdList = BffHelper.ConvertActionResultToDict(okRentObjId);
            var RentObjIdObj = RentObjIdList[0];

            var rentObjId = int.Parse(RentObjIdObj["rentObjId"].ToString());

            return await _gateway.ForwardFileAsync(
                "OfferApiService",
                $"/api/rentobjimage/upload/{rentObjId}",
                HttpMethod.Put,
                file
            );
        }

        //============================================================================================
        //                             редактирование изображений обьявления
        //============================================================================================
        public class UpdateImageOfferRequest
        {
            public IFormFile File { get; set; } = null!;
        }

        [HttpPut("img/booking-offer/{offerId}/update/{imageId}")]
        [Authorize]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateImageOffer(
             [FromRoute] int offerId,
             [FromRoute] int imageId,
             [FromForm] ImageOfferRequest request
        )
        {
            var file = request.File;
            if (file == null || file.Length == 0)
                return BadRequest("Файл не передан");

            var isValidResult = await _gateway.ForwardRequestAsync<object>(
                "UserApiService",
                $"api/user/valid/offers/{offerId}",
                HttpMethod.Get,
                null
            );

            if (isValidResult is not OkObjectResult okIsValid)
                return isValidResult;

            if (okIsValid.Value is not JsonElement json || !json.GetBoolean())
                return Forbid();

            return await _gateway.ForwardFileAsync(
                "OfferApiService",
                $"/api/rentobjimage/update-file/{imageId}",
                HttpMethod.Put,
                file
            );
        }



        //============================================================================================
        //                               удаление изображений обьявления
        //============================================================================================
        [HttpPut("img/booking-offer/{id}/delete/{imageId}")]
        [Authorize]
        public async Task<IActionResult> DeleteImageOffer(
             [FromRoute] int id,
             [FromRoute] int imageId
        )
        {
            var offerId = id;

            var isValidResult = await _gateway.ForwardRequestAsync<object>(
                "UserApiService",
                $"api/user/valid/offers/{offerId}",
                HttpMethod.Get,
                null
            );

            if (isValidResult is not OkObjectResult okIsValid)
                return isValidResult;

            if (okIsValid.Value is not JsonElement json || !json.GetBoolean())
                return Forbid();

            return await _gateway.ForwardRequestAsync<object>(
                "OfferApiService",
                $"/api/rentobjimage/delete/{imageId}",
                HttpMethod.Put,
                null
            );
        }


        //==========================================================================================
        //       заблокировать обьявление
        //==========================================================================================
        [HttpPut("block/booking-offer/{offerId}")]
        [Authorize]
        public async Task<IActionResult> BlockOffer(int offerId)
        {
            var ownerValidationResult = await _gateway.ForwardRequestAsync<object>(
                "UserApiService",
                $"api/user/valid/offers/{offerId}",
                HttpMethod.Get,
                null
            );
            if (ownerValidationResult is not OkObjectResult okResult)
                return Forbid();

            bool isOwner = false;

            if (okResult.Value is JsonElement json)
            {
                isOwner = json.GetBoolean();
            }
            else if (okResult.Value is bool b)
            {
                isOwner = b;
            }

            if (!isOwner)
                return Forbid();


            var blockResult = await _gateway.ForwardRequestAsync<object>(
                "OfferApiService",
                $"/api/offer/block/{offerId}",
                HttpMethod.Put,
                null
            );
            return blockResult;
        }


        //==========================================================================================
        //       разблокировать обьявление
        //==========================================================================================
        [HttpPut("unblock/booking-offer/{offerId}")]
        [Authorize]
        public async Task<IActionResult> UnBlockOffer(int offerId)
        {
            var ownerValidationResult = await _gateway.ForwardRequestAsync<object>(
                "UserApiService",
                $"api/user/valid/offers/{offerId}",
                HttpMethod.Get,
                null
            );
            if (ownerValidationResult is not OkObjectResult okResult)
                return Forbid();

            bool isOwner = false;

            if (okResult.Value is JsonElement json)
            {
                isOwner = json.GetBoolean();
            }
            else if (okResult.Value is bool b)
            {
                isOwner = b;
            }

            if (!isOwner)
                return Forbid();


            var blockResult = await _gateway.ForwardRequestAsync<object>(
                "OfferApiService",
                $"/api/offer/unblock/{offerId}",
                HttpMethod.Put,
                null
            );
            return blockResult;
        }





        //============================================================================================
        //                                создание заказа
        //============================================================================================


        [HttpPost("create/booking-order/{lang}")]
        [Authorize]
        public async Task<IActionResult> CreateOrder(
             [FromBody] CreateOrderRequest request,
              string lang)
        {
            if (User.Identity?.IsAuthenticated != true)
                return Forbid(); 

            var (userId, userDiscountPercent) = await GetUserIdAndDiscountAsync();

            if (userId == null)
                return Forbid(); 

            var offerRequest = OfferByDataAndCountGuestRequest.MapToResponse(request.StartDate, request.EndDate, request.Guests);
           
            var offerQuery = QueryString.Create(new Dictionary<string, string?>
            {
                ["startDate"] = offerRequest.StartDate.ToString("O"),
                ["endDate"] = offerRequest.EndDate.ToString("O"),
                ["guests"] = offerRequest.Guests.ToString(),
                ["userDiscountPercent"] = userDiscountPercent.ToString(),
            });

            var offerObjResult = await _gateway.ForwardRequestAsync<object>(
                "OfferApiService",
                $"/api/offer/get-offer/{request.OfferId}{offerQuery}",
                HttpMethod.Get,
                null
            );

            if (offerObjResult is not OkObjectResult okOffer)
                return offerObjResult;

            var offerDictList = BffHelper.ConvertActionResultToDict(okOffer);
            var offer = offerDictList[0];
            var rentObj = (offer["rentObj"] as List<Dictionary<string, object>>)[0];


            var countryId = int.Parse(rentObj["countryId"].ToString());
            var cityId = int.Parse(rentObj["cityId"].ToString());
            var address = int.Parse(rentObj["address"].ToString());

            var translateOffer = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Offer/get-translations/{request.OfferId}/{lang}", HttpMethod.Get, null);
            var titleOffer = GetStringFromActionResult(translateOffer, "title");

            var translateCountry = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Country/get-translations/{countryId}/{lang}", HttpMethod.Get, null);
            var countryTitle = GetStringFromActionResult(translateCountry, "title");

            var translateCity = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/City/get-translations/{cityId}/{lang}", HttpMethod.Get, null);
            var cityTitle = GetStringFromActionResult(translateCity, "title");

            var orderRequest = OrderDto.MapToOrderDto(request, offer, userId.Value);
            var orderIdResult = await _gateway.ForwardRequestAsync(
                  "OrderApiService",
                  "/api/order/order/add",
                  HttpMethod.Post,
                  orderRequest);


            int orderId = -1;
            OrderResponse order = new OrderResponse();

            if (orderIdResult is OkObjectResult ok)
            {
                if (ok.Value is JsonElement el)
                {
                    if (el.ValueKind == JsonValueKind.Number)
                    {
                        orderId = el.GetInt32();
                    }
                }

                if (orderId == -1)
                    return BadRequest("Пустой запрос");

                Console.WriteLine($"Заказ создан с Id = {orderId}");

                order = OrderResponse.MapToOrderResponse(
                    request,
                    offer,
                    userId.Value,
                    titleOffer,
                    countryTitle,
                    cityTitle,
                    address
                );

                var orderToOfferResponse = await _gateway.ForwardRequestAsync<object>(
                    "OfferApiService",
                    $"/api/offer/{request.OfferId}/orders/add/{orderId}",
                    HttpMethod.Post,
                    null
                );
                if (orderToOfferResponse == null)
                {
                    throw new InvalidOperationException("Order не был добавлен в список для заказа");
                }

                var addOrder = await _gateway.ForwardRequestAsync<object>(
                    "UserApiService",
                    $"/api/user/client/orders/add/{orderId}",
                    HttpMethod.Post,
                    null
                );
                if (addOrder == null)
                {
                    throw new InvalidOperationException("Order не был добавлен в список для клиента");
                }

                var entityStatEventRequest = new EntityStatEventRequest
                {
                    EntityId = request.OfferId,
                    EntityType = "Offer",
                    ActionType = "Booking",
                    UserId = userId
                };

                var entityStatCityEventRequest = new EntityStatEventRequest
                {
                    EntityId = cityId,
                    EntityType = "City",
                    ActionType = "Booking",
                    UserId = userId
                };
                await SendStatEvent(entityStatEventRequest, "Offer");
                await SendStatEvent(entityStatCityEventRequest, "City");

                decimal discountCount = 0.25m; 

                var discountObjResult = await _gateway.ForwardRequestAsync<object>(
                    "UserApiService",
                    $"/api/user/update/discount/{userId}/{discountCount}",
                    HttpMethod.Post,
                    null
                );

                if (discountObjResult is not OkObjectResult okDiscount)
                   Console.WriteLine("Дисконт не обновился");

            }
           return Ok(order);
            
        }



        //===============================================================================================================
        //                                         редактирование статуса заказа
        //======================================+=========================================================================


        [HttpPost("update_status/booking/{orderId}")]
        [Authorize]
        public async Task<IActionResult> UpdateStateOrder(
             int orderId,
             [FromQuery] string orderState)
        {
            var ownerValidation = await ValidateOwnerAsync();
            if (!ownerValidation.IsOwner)
                return Forbid();
         
            var orderObjResult = await _gateway.ForwardRequestAsync<object>(
              "OrderApiService",
              $"/api/order/get/{orderId}",
              HttpMethod.Get,
              null
          );


            if (orderObjResult is not OkObjectResult okOrder)
                return orderObjResult;

            var orderDictList = BffHelper.ConvertActionResultToDict(okOrder);
            var order = orderDictList[0];

            var offerId = int.Parse(order["offerId"].ToString());


            var isValidResult = await _gateway.ForwardRequestAsync<object>(
                "UserApiService",
                $"api/user/valid/offers/{offerId}",
                HttpMethod.Get,
                null
            );

            if (isValidResult is not OkObjectResult okIsValid)
                return isValidResult;

            if (okIsValid.Value is not JsonElement json || !json.GetBoolean())
                return Forbid();

            order["status"] = orderState;
                var resultObj = await _gateway.ForwardRequestAsync<object>(
                    "OrderApiService",
                    $"/api/order/update/status/{orderId}?orderState={orderState}",
                    HttpMethod.Post,
                    null
                );
                if (resultObj is not OkObjectResult okResult)
                {
                    return resultObj;
                }

                if (okResult.Value is int resultId)
                {
                    if (resultId == -1)
                    {
                        return BadRequest(new { message = "Не удалось изменить заказ" });
                    }
                }
            

            return Ok(order);

        }

       
        //===============================================================================================================
        //                                         создание отзыва
        //======================================+=========================================================================

        [HttpPost("user/orders/{orderId}/reviews/create")]
        [Authorize]
        public async Task<IActionResult> CreateReview(
             [FromBody] CreateReviewRequest request,
             int orderId,
             string lang)
        {
            var(userIdRequest, status) = await GetClientIdAndStatusFromOrder(orderId);

            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();


            if (userIdRequest == userId)
            {
                var userResult = await _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/User/get/name/{userIdRequest}", HttpMethod.Get, null);
                if (userResult is not OkObjectResult okResult)
                {
                    return userResult;
                }
                var userDictList = BffHelper.ConvertActionResultToDict(okResult);

                var user = userDictList[0];
                var userName = user["userName"]?.ToString();
                int countryId = int.Parse(user["countryId"].ToString());

                var countryResult = await _gateway.ForwardRequestAsync<object>(
                        "TranslationApiService",
                        $"/api/country/get-translations/{countryId}/{lang}",
                        HttpMethod.Get,
                        null
                    );
                if (countryResult is not OkObjectResult okCountryResult)
                {
                    return Ok(user);
                }
                var countryDictList = BffHelper.ConvertActionResultToDict(okCountryResult);
                var countryTitle = countryDictList[0]["title"].ToString();


                var reviewRequest = ReviewDto.MapToDto(request, orderId, userId);
                var orderResult = await _gateway.ForwardRequestAsync<object>(
                        "OrderApiService",
                        $"/api/Order/{orderId}/get/offerId",
                        HttpMethod.Get,
                        null
                    );
                OkObjectResult okOrderIdResult = null;

                if (orderResult is OkObjectResult ok)
                {
                    okOrderIdResult = ok;
                }
                else
                {
                    Console.WriteLine("Offer not found");
                }

                int offerId = 0;

                if (okOrderIdResult != null)
                {
                    var offerIdDictList = BffHelper.ConvertActionResultToDict(okOrderIdResult);
                    offerId = int.Parse(offerIdDictList[0]["offerId"].ToString());
                }
                reviewRequest.OfferId = offerId;
                var reviewObjResult = await _gateway.ForwardRequestAsync(
                      "ReviewApiService",
                      "/api/review/create",
                      HttpMethod.Post,
                      reviewRequest);


                if (reviewObjResult is not OkObjectResult okReview)
                    return reviewObjResult;

                var reviewDictList = BffHelper.ConvertActionResultToDict(okReview);
                var reviev = reviewDictList[0];
                reviev["orderId"] = orderId;
                var id = reviev["id"];

                    var translationDto = new TranslationDto
                    {
                        EntityId = int.Parse(id.ToString()),
                        Lang = lang,
                        Title = request.Comment,

                    };

                var translateReview = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Review/create-translations/{lang}", HttpMethod.Post, translationDto);
                var revievResponse = ReviewDto.MapToDto(request, orderId, userId);
                revievResponse.UserName = userName;
                revievResponse.UserCountry = countryTitle;
                revievResponse.Title = request.Comment;
                revievResponse.OfferId = offerId;

                decimal discountCount = 0.1m;

                var discountObjResult = await _gateway.ForwardRequestAsync<object>(
                    "UserApiService",
                    $"/api/User/update/discount/{userId}/{discountCount}",
                    HttpMethod.Get,
                    null
                );

                if (discountObjResult is not OkObjectResult okDiscount)
                    Console.WriteLine("Дисконт не обновился");

                return Ok(revievResponse);
            }

            return Ok(null);

        }


        //===============================================================================================================
        //                                         получение отзывoв обьявления
        //===============================================================================================================

        [HttpPost("offer/{offerId}/reviews/get/{lang}")]
        public async Task<IActionResult> GetReviewByOffer(
             [FromRoute] int offerId,
             string lang)
        {


            var reviewsObjResult = await _gateway.ForwardRequestAsync<object>(
                  "ReviewApiService",
                  $"/api/review/get-by-offerId/{offerId}",
                  HttpMethod.Get,
                  null);


            if (reviewsObjResult is not OkObjectResult okReviews)
                return reviewsObjResult;
            var reviewDictList = BffHelper.ConvertActionResultToDict(okReviews);

            // Получаем список переводов
            var translateListResult = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Review/get-all-translations/{lang}", HttpMethod.Get, null);

            if (translateListResult is not OkObjectResult okTranslate)
                return reviewsObjResult;
            var translations = BffHelper.ConvertActionResultToDict(okTranslate);



            BffHelper.UpdateListWithTranslations(reviewDictList, translations);

            for (int i = 0; i < reviewDictList.Count; i++) { 
                var review = reviewDictList[i];
                var userId = review["userId"];

                var userObjResult = await _gateway.ForwardRequestAsync<object>(
                "UserApiService",
                $"/api/user/get/{userId}",
                HttpMethod.Get,
                null
            );
                if (userObjResult is not OkObjectResult okUser)
                    return userObjResult;

                var userDictList = BffHelper.ConvertActionResultToDict(okUser);

                var user = userDictList[0];
                string userName = user["username"].ToString();
                string userEmail = user["email"].ToString();
                int countryId = int.Parse(user["countryId"].ToString());

                var translateCountry = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Country/get-translations/{countryId}/{lang}", HttpMethod.Get, null);
                var countryTitle = GetStringFromActionResult(translateCountry, "title");

                review["userName"] = userName;
                review["userEmail"] = userEmail;
                review["userCountry"] = countryTitle;
            }
            return Ok(reviewDictList);
      

        }




        //===============================================================================================================
        //                                         получение отзывoв клиента
        //===============================================================================================================

        [HttpPost("me/reviews/get/{lang}")]
        [Authorize]
        public async Task<IActionResult> GetReviewByUser(
             string lang)
        {
            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();


            var reviewsObjResult = await _gateway.ForwardRequestAsync<object>(
                  "ReviewApiService",
                  $"/api/review/get-by-userId/{userId}",
                  HttpMethod.Get,
                  null);


            if (reviewsObjResult is not OkObjectResult okReviews)
                return reviewsObjResult;
            var reviewDictList = BffHelper.ConvertActionResultToDict(okReviews);

            // Получаем список переводов
            var translateListResult = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Review/get-all-translations/{lang}", HttpMethod.Get, null);
             if (translateListResult is not OkObjectResult okTranslate)
                return reviewsObjResult;
            var translations = BffHelper.ConvertActionResultToDict(okTranslate);

            BffHelper.UpdateListWithTranslations(reviewDictList, translations);

            for (int i = 0; i < reviewDictList.Count; i++)
            {
                var review = reviewDictList[i];

                var offerId = review["offerId"];


                var translateOffer = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Offer/get-translations/{offerId}/{lang}", HttpMethod.Get, null);
                var titleOffer = GetStringFromActionResult(translateOffer, "title");
                
            }
            return Ok(reviewDictList);


        }



        //===============================================================================================================
        //                                         редактирование отзывoв 
        //===============================================================================================================

        [HttpPost("me/{orderId}/reviews/update/{reviewId}/{lang}")]
        [Authorize]
        public async Task<IActionResult> UpdateReviewById(
             [FromBody] CreateReviewRequest request,
             int reviewId,
             int orderId,
             string lang)
        {

            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();

            var (userIdRequest, status) = await GetClientIdAndStatusFromOrder(orderId);
            //if (userIdRequest == userId &&  status == "Completed")
            if (userIdRequest == userId)
            {
                var reviewRequest = ReviewDto.MapToDto(request, orderId, userId);

                var reviewObjResult = await _gateway.ForwardRequestAsync(
                      "ReviewApiService",
                      $"/api/review/update/{reviewId}",
                      HttpMethod.Put,
                      reviewRequest);


                if (reviewObjResult is not OkObjectResult okReview)
                    return reviewObjResult;

                var reviewDictList = BffHelper.ConvertActionResultToDict(okReview);
                var review = reviewDictList[0];
              

                var translationDto = new TranslationDto
                {
                    EntityId = reviewId,
                    Lang = lang,
                    Title = request.Comment
                };

                var translateReview = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Review/create-translations/{lang}", HttpMethod.Post, translationDto);
                return Ok(review);
            }

            return Ok(null);
        }



        //===============================================================================================================
        //                                         удаление отзывoв 
        //===============================================================================================================

        [HttpDelete("me/{userId}/{orderId}/reviews/delete/{reviewId}")]
        [Authorize]
        public async Task<IActionResult> DeleteReviewById(
             int reviewId,
             int orderId)
        {

            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();

            var (userIdRequest, status) = await GetClientIdAndStatusFromOrder(orderId);
            //if (userIdRequest == userId &&  status == "Completed")
            if (userIdRequest == userId)
            {
                await _gateway.ForwardRequestAsync<object>(
                      "ReviewApiService",
                      $"/api/review/update/{reviewId}",
                      HttpMethod.Delete,
                      null);

                var lang = "en";
                await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Review/del-translations/{reviewId}/{lang}", HttpMethod.Delete, null);
                return Ok();
            }

            return Ok(null);
        }




        //===============================================================================================================
        //                         Топ city за период (week / month / year)
        //===============================================================================================================

        [HttpGet("statistic/top/{period}/get/city/{lang}")]
        public async Task<IActionResult> GetPopularTopCity(
            StatisticPeriod period,
            string lang)
        {
            const int entityTypeId = 2; // City
            const int limit = 10;

            var statisticUrl = period switch
            {
                StatisticPeriod.Week => "/api/EntityStatistic/top-week",
                StatisticPeriod.Month => "/api/EntityStatistic/top-month",
                StatisticPeriod.Year => "/api/EntityStatistic/top-year",
                _ => throw new ArgumentOutOfRangeException()
            };

            var url =
                $"{statisticUrl}" +
                $"?entityType={entityTypeId}" +
                $"&limit={limit}";

            var statisticResult =
                await _gateway.ForwardRequestAsync<object>(
                    "StatisticApiService",
                    url,
                    HttpMethod.Get,
                    null);

            if (statisticResult is not OkObjectResult okStatistic)
                return statisticResult;
            var statisticObjDictList = BffHelper.ConvertActionResultToDict(okStatistic);

            var idList = new List<int>();
            foreach (var statsOffer in statisticObjDictList)
            {
                var id = int.Parse(statsOffer["EntityId"].ToString());
                idList.Add(id);
            }
          
            var citiesObjResult = await _gateway.ForwardRequestAsync<object>(
                  "LocationApiService",
                  $"/api/city/search/cities/populars",
                  HttpMethod.Post,
                  idList);
            if (citiesObjResult is not OkObjectResult okCities)
                return citiesObjResult;

            var statisticCityDictList = BffHelper.ConvertActionResultToDict(okCities);


            var translateListResult =
                await _gateway.ForwardRequestAsync<object>(
                    "TranslationApiService",
                    $"/api/City/get-all-translations/{lang}",
                    HttpMethod.Get,
                    null);

            if (translateListResult is not OkObjectResult okTranslate)
                return translateListResult;
            var translations = BffHelper.ConvertActionResultToDict(okTranslate);


            BffHelper.UpdateListWithTranslations(statisticCityDictList, translations);

            return Ok(statisticCityDictList);
        }

        //===============================================================================================================
        //                         Топ offer за период (week / month / year)
        //===============================================================================================================

        [HttpGet("statistic/top/{period}/get/offer/{lang}")]
        public async Task<IActionResult> GetPopularTopOffer(
            StatisticPeriod period,
            string lang)
        {
            const int entityTypeId = 3; // Offer
            const int limit = 10;

            var statisticUrl = period switch
            {
                StatisticPeriod.Week => "/api/EntityStatistic/top-week",
                StatisticPeriod.Month => "/api/EntityStatistic/top-month",
                StatisticPeriod.Year => "/api/EntityStatistic/top-year",
                _ => throw new ArgumentOutOfRangeException()
            };

            var url =
                $"{statisticUrl}" +
                $"?entityType={entityTypeId}" +
                $"&limit={limit}";

            var statisticResult =
                await _gateway.ForwardRequestAsync<object>(
                    "StatisticApiService",
                    url,
                    HttpMethod.Get,
                    null);

            if (statisticResult is not OkObjectResult okStatistic)
                return statisticResult;

            var statisticObjDictList = BffHelper.ConvertActionResultToDict(okStatistic);
            
            var idList = new List<int>();
            foreach (var statsOffer in statisticObjDictList)
            {
                var id  =int.Parse(statsOffer["EntityId"].ToString());
                idList.Add(id);
            }
            //получаем данные
            var offerObjResult = await _gateway.ForwardRequestAsync<object>(
                  "OfferApiService",
                  $"/api/offer/search/offers/populars",
                  HttpMethod.Post,
                  idList);
            if (offerObjResult is not OkObjectResult okOffer)
                return offerObjResult;

            var statisticOfferDictList = BffHelper.ConvertActionResultToDict(okOffer);

            // Получаем список переводов для title
            var translateListResult =
                await _gateway.ForwardRequestAsync<object>(
                    "TranslationApiService",
                    $"/api/Offer/get-all-translations/{lang}",
                    HttpMethod.Get,
                    null);

            if (translateListResult is not OkObjectResult okTranslate)
                return translateListResult;
            var translations = BffHelper.ConvertActionResultToDict(okTranslate);

            BffHelper.UpdateListWithTranslations(statisticOfferDictList, translations);


            //заменяем название города
            foreach (var offer in statisticOfferDictList)
            {
                var rentObj = (offer["rentObj"] as List<Dictionary<string, object>>)[0];

                var cityId = rentObj["cityId"];

                var translateCity = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/City/get-translations/{cityId}/{lang}", HttpMethod.Get, null);
                var cityTitle = GetStringFromActionResult(translateCity, "title");

                offer["cityTitle"] = cityTitle;
            }
            //получаем рейтинг
            var ratingObjResult = await _gateway.ForwardRequestAsync<object>("ReviewApiService", $"/api/review/search/offers/rating", HttpMethod.Post, idList);
            if (ratingObjResult is not OkObjectResult okRating)
                return ratingObjResult;
            var ratingDictList = BffHelper.ConvertActionResultToDict(okRating);

            BffHelper.UpdateOfferListWithRating(statisticOfferDictList, ratingDictList);

            return Ok(statisticOfferDictList);
        }


        //===============================================================================================================

        //                            Вспомогательные методы

        //==============================================================================================================

        //-----парсим строку с фильтрами параметров в список словарей-----
        private static List<Dictionary<string, object>> ParseParamFiltersToDict(string filter)
        {
            var result = new List<Dictionary<string, object>>();
            if (string.IsNullOrWhiteSpace(filter)) return result;
            foreach (var part in filter.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                var kv = part.Split(':', 2, StringSplitOptions.TrimEntries);
                if (int.TryParse(kv[0], out var id))
                {
                    var dict = new Dictionary<string, object> { ["id"] = id };
                    if (kv.Length > 1) dict["value"] = kv[1];
                    result.Add(dict);
                }
            }
            return result;
        }
        //-----получение id обьявления-----
        static bool TryGetOfferId(
            Dictionary<string, object> offer,
            out int offerId)
        {
            offerId = default;

            return offer.TryGetValue("id", out var idObj)
                   && int.TryParse(idObj?.ToString(), out offerId);
        }
        //-----получение значений параметров обьявления-----
        static bool TryGetParamValues(
            Dictionary<string, object> offer,
            out List<Dictionary<string, object>> paramValues)
        {
            paramValues = null;

            if (!offer.TryGetValue("rentObj", out var rentObjObj)
                || rentObjObj is not List<Dictionary<string, object>> rentObjList
                || rentObjList.Count == 0)
                return false;

            var rentObj = rentObjList[0];

            return rentObj.TryGetValue("paramValues", out var pvObj)
                    && pvObj is List<Dictionary<string, object>> pvList
                    && (paramValues = pvList) != null;
        }

        //-----вычисление совпадения всех фильтров с параметрами обьявления-----
        static bool MatchAllFilters(
            List<Dictionary<string, object>> paramValues,
            List<Dictionary<string, object>> filters)
        {
            var flag = true;
            foreach (var f in filters)
            {
                if (!paramValues.Any(p => p["id"].ToString() == f["id"].ToString()
                    && (p["valueBool"].ToString().ToLower() == f["value"].ToString().ToLower()
                    || p["valueInt"].ToString().ToLower() == f["value"].ToString().ToLower()
                    || p["valueString"].ToString().ToLower() == f["value"].ToString().ToLower())))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }



        //-----получение id пользователя и его скидки-----
        private async Task<(int? userId, decimal discount)> GetUserIdAndDiscountAsync()
        {
            int? userId = null;
            decimal discount = 0;

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                            ?? User.FindFirst(JwtRegisteredClaimNames.Sub);

            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int parsedUserId))
            {
                userId = parsedUserId;

                var userObjResult = await _gateway.ForwardRequestAsync<object>(
                    "UserApiService", "/api/user/me", HttpMethod.Get, null);

                if (userObjResult is OkObjectResult okUser)
                {
                    var userDictList = BffHelper.ConvertActionResultToDict(okUser);
                    if (userDictList.Any())
                    {
                        var user = userDictList[0];

                        if (user.ContainsKey("discount") && user["discount"] is JsonElement discountElement)
                        {
                            switch (discountElement.ValueKind)
                            {
                                case JsonValueKind.Number:
                                    discount = discountElement.GetDecimal();
                                    break;
                                case JsonValueKind.String:
                                    if (!decimal.TryParse(discountElement.GetString(), out discount))
                                        discount = 0;
                                    break;
                                default:
                                    discount = 0;
                                    break;
                            }
                        }
                    }
                }
            }

            return (userId, discount);
        }

        //-----проверка на конфликт дат обьявления-----
        private async Task<bool> HasDateConflictAsync(int offerId, DateTime start, DateTime end)
        {
            var ordersIdListResult = await _gateway.ForwardRequestAsync<object>(
                "OfferApiService",
                $"/api/offer/{offerId}/get/orders/id",
                HttpMethod.Get,
                null);

            if (ordersIdListResult is not OkObjectResult okOrders)
                return true;

            List<int> ordersIdList;
            try
            {
                var json = JsonSerializer.Serialize(okOrders.Value);
                ordersIdList = JsonSerializer.Deserialize<List<int>>(json) ?? new List<int>();
            }
            catch
            {
                return true;
            }

            var validRequest = new DateValidationRequest
            {
                Start = start,
                End = end,
                OrdersIdList = ordersIdList
            };

            var validResult = await _gateway.ForwardRequestAsync<object>(
                "OrderApiService",
                $"/api/order/{offerId}/valid/date-time",
                HttpMethod.Post,
                validRequest);

            if (validResult is not OkObjectResult okResult)
                return true;

            if (okResult.Value is bool b)
                return b;
            if (okResult.Value is JsonElement je && je.ValueKind == JsonValueKind.True)
                return true;
            return false;
        }

        //-----получение переводов из кэша или сервиса-----
        private async Task<List<Dictionary<string, object>>> GetTranslationsAsync(string lang, string resource)
        {
            if (string.IsNullOrWhiteSpace(lang)) return new List<Dictionary<string, object>>();
            if (string.IsNullOrWhiteSpace(resource)) throw new ArgumentException("Resource cannot be empty", nameof(resource));

            var cacheKey = $"translations_{resource}_{lang}";

            return await _cache.GetOrCreateAsync(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60);
                return FetchTranslationsFromServiceAsync(lang, resource);
            });
        }
        //-----получение переводов из сервиса-----
        private async Task<List<Dictionary<string, object>>> FetchTranslationsFromServiceAsync(string lang, string resource)
        {
            var translateListResult = await _gateway.ForwardRequestAsync<object>(
                "TranslationApiService",
                $"/api/{resource}/get-all-translations/{lang}",
                HttpMethod.Get,
                null);

            if (translateListResult is OkObjectResult okTranslate)
                return BffHelper.ConvertActionResultToDict(okTranslate);

            return new List<Dictionary<string, object>>();
        }

        //-----получение координат города из кэша или сервиса-----
        private async Task<(double lat, double lon)> GetCityCoordinatesCachedAsync(int cityId)
        {
            var cacheKey = $"city_coords_{cityId}";

            return await FetchCityCoordinatesAsync(cityId);
            //return await _cache.GetOrCreateAsync(cacheKey, async entry =>
            //{
            //    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
            //    return await FetchCityCoordinatesAsync(cityId);
            //});
        }

        //-----получение координат города из сервиса-----
        private async Task<(double lat, double lon)> FetchCityCoordinatesAsync(int cityId)
        {
            var cityObj = await _gateway.ForwardRequestAsync<object>(
                "LocationApiService",
                $"/api/city/get/{cityId}",
                HttpMethod.Get,
                null);

            double lat = 0, lon = 0;
            var dLat = GetDoubleFromActionResult(cityObj, "latitude");
            var dLon = GetDoubleFromActionResult(cityObj, "longitude");
            if (dLat.HasValue) lat = dLat.Value;
            if (dLon.HasValue) lon = dLon.Value;

            return (lat, lon);
        }
        //-----получение id клиента и статуса заказа-----

        private async Task<(int userId, string status)> GetClientIdAndStatusFromOrder(int orderId)
        {
            var orderObjResult = await _gateway.ForwardRequestAsync<object>(
                "OrderApiService",
                $"/api/order/get/{orderId}",
                HttpMethod.Get,
                null
            );

            if (orderObjResult is OkObjectResult okOrder)
            {

                var orderDictList = BffHelper.ConvertActionResultToDict(okOrder);
                var order = orderDictList[0];
                var status = order["status"].ToString();
                var userId = int.Parse(order["clientId"].ToString());

                return (userId, status);
            }
            return (-1, "Pending");
        }



        private string GetStringFromActionResult(object result, string param)
        {
            var value_pi = result.GetType().GetProperty("Value");
            if (value_pi != null)
            {
                var val = value_pi.GetValue(result);
                if (val is JsonElement jsonElement)
                {
                    if (jsonElement.ValueKind == JsonValueKind.Object &&
                        jsonElement.TryGetProperty(param, out var titleProp))
                    {
                        return titleProp.GetString();
                    }
                }
            }
            return null;
        }

        private double? GetDoubleFromActionResult(object result, string propertyName)
        {
            var value_pi = result.GetType().GetProperty("Value");
            if (value_pi != null)
            {
                var val = value_pi.GetValue(result);

                if (val is JsonElement jsonElement)
                {
                    if (jsonElement.ValueKind == JsonValueKind.Object &&
                        jsonElement.TryGetProperty(propertyName, out var prop))
                    {
                        if (prop.ValueKind == JsonValueKind.Number &&
                            prop.TryGetDouble(out double number))
                        {
                            return number;
                        }
                    }
                }
            }

            return null;
        }




        //private List<Dictionary<string, object>> UpdateListWithTranslations(List<Dictionary<string, object>> list, List<Dictionary<string, object>> translations,
        //    string idFieldName = "id",
        //    string translationIdFieldName = "entityId")
        //{
        //    foreach (var item in list)
        //    {
        //        if (!item.TryGetValue(idFieldName, out var idObj)) continue;
        //        if (!int.TryParse(idObj.ToString(), out int id)) continue;

                
        //        var translation = translations.FirstOrDefault(t =>
        //            t.TryGetValue(translationIdFieldName, out var eid) &&
        //            int.TryParse(eid.ToString(), out int eidInt) &&
        //            eidInt == id
        //        );

        //        if (translation != null)
        //        {
        //            CopyIfExists(item, translation, "title");
        //            CopyIfExists(item, translation, "description");
        //            CopyIfExists(item, translation, "titleInfo");
        //            CopyIfExists(item, translation, "address");
        //        }
        //    }
        //    return list;
        //}


        //private List<Dictionary<string, object>> UpdateOfferListWithRating(List<Dictionary<string, object>> list, List<Dictionary<string, object>> ratings,
        //    string idFieldName = "id",
        //    string ratingIdFieldName = "OfferId")
        //{
        //    foreach (var item in list)
        //    {
        //        var itemKey = item.Keys.FirstOrDefault(k => k.Equals(idFieldName, StringComparison.OrdinalIgnoreCase));
        //        if (itemKey == null) continue;

        //        if (!int.TryParse(item[itemKey]?.ToString(), out int id)) continue;

        //        var rating = ratings.FirstOrDefault(r =>
        //        {
        //            var ratingKey = r.Keys.FirstOrDefault(k => k.Equals(ratingIdFieldName, StringComparison.OrdinalIgnoreCase));
        //            return ratingKey != null && int.TryParse(r[ratingKey]?.ToString(), out int rid) && rid == id;
        //        });

        //        if (rating == null) continue;

        //        CopyIfExists(item, rating, "Staff");
        //        CopyIfExists(item, rating, "Facilities");
        //        CopyIfExists(item, rating, "Cleanliness");
        //        CopyIfExists(item, rating, "Comfort");
        //        CopyIfExists(item, rating, "ValueForMoney");
        //        CopyIfExists(item, rating, "Location");
        //        CopyIfExists(item, rating, "OverallRating");
        //    }
        //    return list;
        //}
        //private static void CopyIfExists(
        //    Dictionary<string, object> target,
        //    Dictionary<string, object> source,
        //    string key)
        //{
        //    var sourceKey = source.Keys
        //        .FirstOrDefault(k => k.Equals(key, StringComparison.OrdinalIgnoreCase));

        //    if (sourceKey == null)
        //        return;

        //    var targetKey = target.Keys
        //        .FirstOrDefault(k => k.Equals(key, StringComparison.OrdinalIgnoreCase))
        //        ?? key;

        //    target[targetKey] = source[sourceKey];
        //}


        private decimal? FindDecimalUnderParent(JsonElement element, string parentName, string fieldName, bool insideParent)
        {
       
            if (insideParent)
            {
                if (element.ValueKind == JsonValueKind.Object)
                {
                    foreach (var prop in element.EnumerateObject())
                    {
                      
                        if (prop.NameEquals(fieldName))
                        {
                            if (prop.Value.ValueKind == JsonValueKind.Number &&
                                prop.Value.TryGetDecimal(out decimal decValue))
                            {
                                return decValue;
                            }
                        }
                      
                        var nested = FindDecimalUnderParent(prop.Value, parentName, fieldName, insideParent: true);
                        if (nested != null)
                            return nested;
                    }
                }
                else if (element.ValueKind == JsonValueKind.Array)
                {
                    foreach (var item in element.EnumerateArray())
                    {
                        var nested = FindDecimalUnderParent(item, parentName, fieldName, insideParent: true);
                        if (nested != null)
                            return nested;
                    }
                }

                return null;
            }

            if (element.ValueKind == JsonValueKind.Object)
            {
                foreach (var prop in element.EnumerateObject())
                {
                    if (prop.NameEquals(parentName))
                    {
                        return FindDecimalUnderParent(prop.Value, parentName, fieldName, insideParent: true);
                    }

                    var nested = FindDecimalUnderParent(prop.Value, parentName, fieldName, insideParent: false);
                    if (nested != null)
                        return nested;
                }
            }

            if (element.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in element.EnumerateArray())
                {
                    var nested = FindDecimalUnderParent(item, parentName, fieldName, insideParent: false);
                    if (nested != null)
                        return nested;
                }
            }

            return null;
        }


        //==============расчет расстояния по ширине и долготе===============
        public static double CalculateDistanceMeters(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371000; // радиус Земли в метрах

            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);

            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ToRadians((double)lat1)) *
                Math.Cos(ToRadians((double)lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c;
        }

        private static double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }




        private bool UpdateAllOffersDistance(List<Dictionary<string, object>> offers, double cityLat, double cityLon)
        {
            foreach (var offer in offers)
            {
                var rentObj = offer["rentObj"] as List<Dictionary<string, object>>;
                if (rentObj == null) return false;
                if (!Double.TryParse(rentObj[0]["latitude"].ToString(), out var lat)) return false;
                if (!Double.TryParse(rentObj[0]["longitude"].ToString(), out var lon)) return false;

                var distance = (int)CalculateDistanceMeters(lat, lon, cityLat, cityLon);
                offer["distanceToCenter"] = distance;
            }
            return true;
        }



        // =====проверка роли owner + получение userId ==========================


        private async Task<(bool IsOwner, int UserId, IActionResult ErrorResult)> ValidateOwnerAsync()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                              ?? User.FindFirst(JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return (false, 0, Unauthorized());
            }

            var userObjResult = await _gateway.ForwardRequestAsync<object>(
                "UserApiService",
                "/api/user/me",
                HttpMethod.Get,
                null
            );

            if (userObjResult is not OkObjectResult okUser)
            {
                return (false, 0, userObjResult);
            }

            var userDictList = BffHelper.ConvertActionResultToDict(okUser);
            var user = userDictList[0];

            var userRole = user["roleName"]?.ToString();
            if (!string.Equals(userRole, "owner", StringComparison.OrdinalIgnoreCase))
            {
                return (
                    false,
                    userId,
                    StatusCode(
                        StatusCodes.Status403Forbidden,
                        new { message = "Вы не собственник имущества" }
                    )
                );
            }

            return (true, userId, null);
        }


        private int GetUserId()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier)
                        ?? User.FindFirst(JwtRegisteredClaimNames.Sub);
            if (claim == null) return 0;
            return int.TryParse(claim.Value, out var id) ? id : 0;
        }

        private async Task SendStatEvent(EntityStatEventRequest request, string type)
        {
            var result = await _gateway.ForwardRequestAsync(
                "StatisticApiService",
                "/api/EntityStatistic/event",
                HttpMethod.Post,
                request
            );

            if (result is OkResult)
                Console.WriteLine($"Событие ({type}) успешно добавлено");
            else if (result is StatusCodeResult status)
                Console.WriteLine($"Ошибка ({type}): {status.StatusCode}");
            else
                Console.WriteLine($"Неизвестный результат ({type})");
        }

       



    }
}
