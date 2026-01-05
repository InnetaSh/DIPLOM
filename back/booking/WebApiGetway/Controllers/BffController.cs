
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using WebApiGetway.Service.Interfase;
using WebApiGetway.View;
using Microsoft.Extensions.Caching.Memory;
using System.Net.WebSockets;

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
        //                      получаем список названий городов для главного екрана
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


        ////=============================================================================
        ////                      получаем список названий категорий для главного екрана
        ////=============================================================================


        //[HttpGet("paramscategory/get-all-translations/{lang}")]
        //public Task<IActionResult> GetAllParamscategory(string lang) =>
        // _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/ParamCategory/get-all-translations/{lang}", HttpMethod.Get, null);




        //=============================================================================
        //        получаем список названий категорий и параметров для главного екрана
        //=============================================================================


        [HttpGet("params/category/{lang}")]
        public async Task<IActionResult> GetMainParamCategory(string lang)
        {
            // Получаем список параметров
            var paramCategotyObjResult = await _gateway.ForwardRequestAsync<object>(
                "OfferApiService",
                $"/api/paramscategory/get-all",
                HttpMethod.Get, null
                );

            if (paramCategotyObjResult is not OkObjectResult okParamCategory)
                return paramCategotyObjResult;


            // Получаем список переводов
            var translateListResult = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/ParamCategory/get-all-translations/{lang}", HttpMethod.Get, null);


            if (translateListResult is not OkObjectResult okTranslate)
                return paramCategotyObjResult;


            // Преобразуем переводы в список словарей
            var translationsJson = okTranslate.Value as JsonElement?;
            var translations = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(
                translationsJson?.GetRawText() ?? "[]"
            );
            var paramDictList = BffHelper.ConvertActionResultToDict(okParamCategory);
            // Обновляем список 
            UpdateListWithTranslations(paramDictList, translations);


            // получаем список названий параметров для главного екрана
            var translateItemListResult = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/paramitem/get-all-translations/{lang}", HttpMethod.Get, null);
            var transItemDict = BffHelper.ConvertActionResultToDict(translateItemListResult as OkObjectResult);
            foreach(var param in paramDictList)
            {
                if (param["items"] is List<Dictionary<string, object>> itemsDictList)
                    UpdateListWithTranslations(itemsDictList, transItemDict);
            }
            return Ok(paramDictList);
        }


        //=============================================================================
        //                      получаем список названий параметров для главного екрана
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


            // Получаем список переводов
            var translateListResult = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/paramitem/get-all-translations/{lang}", HttpMethod.Get, null);


            if (translateListResult is not OkObjectResult okTranslate)
                return paramItemObjResult;


            // Преобразуем переводы в список словарей
            var translationsJson = okTranslate.Value as JsonElement?;
            var translations = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(
                translationsJson?.GetRawText() ?? "[]"
            );
            var paramDictList = BffHelper.ConvertActionResultToDict(okParamItem);
            // Обновляем список 
            UpdateListWithTranslations(paramDictList, translations);



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

            foreach (var offer in offerDictList)
            {
                if (!TryGetOfferId(offer, out var offerId))
                    continue;

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
            }



            var offerTranslations = await GetTranslationsAsync(lang, "Offer");


            var updateOfferDictList = UpdateListWithTranslations(filteredOfferList, offerTranslations);

            var (cityLat, cityLon) = await GetCityCoordinatesCachedAsync(CityId);

            var result = UpdateAllOffersDistance(updateOfferDictList, cityLat, cityLon);

            return Ok(updateOfferDictList);
        }


  

        //================= Вспомогательные методы ============================================


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

        static bool TryGetOfferId(
            Dictionary<string, object> offer,
            out int offerId)
                {
                    offerId = default;

                    return offer.TryGetValue("id", out var idObj)
                           && int.TryParse(idObj?.ToString(), out offerId);
                }
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


        private async Task<(double lat, double lon)> GetCityCoordinatesCachedAsync(int cityId)
        {
            var cacheKey = $"city_coords_{cityId}";

            return await _cache.GetOrCreateAsync(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                return FetchCityCoordinatesAsync(cityId);
            });
        }

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





        //======================================================================================
        //                      получаем полные данные об обьявлении по id
        //======================================================================================


        [HttpGet("search/booking-offer/{id}/{lang}")]
        public async Task<IActionResult> GetFullOfferById(int id, 
          string lang,
         [FromQuery] OfferByIdRequest request,
         [FromQuery] decimal userDiscountPercent)
        {
            var queryString = Request.QueryString.Value ?? string.Empty;

            var offerObjResult = await _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/offer/get-offer/{id}{queryString}", HttpMethod.Get, null);

            if (offerObjResult is not OkObjectResult okOffer)
                return offerObjResult;

            var offerDictList = BffHelper.ConvertActionResultToDict(okOffer);
            var offer = offerDictList[0];
            var rentObj = (offer["rentObj"] as List<Dictionary<string, object>>)[0];

            var countryId = rentObj["countryId"];
            var regionId = rentObj["regionId"];
            var cityId = rentObj["cityId"];
            var districtId = rentObj["districtId"];

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

            UpdateListWithTranslations(paramItems, transItemDict);


            var imagesObjList = (rentObj["images"] as List<Dictionary<string, object>>);
            var imagesArray = new List<string>();
            for (int i = 0; i < imagesObjList.Count; i++) {
                var image = imagesObjList[i] as Dictionary<string, object>;
                var imageTitle = image["url"].ToString();
                imagesArray.Add(imageTitle);
            }

            
            //var ImagesUrl = (rentObj["imagesUrl"] as List<string>);

            rentObj["imagesUrl"] =  imagesArray;


            if (User.Identity?.IsAuthenticated == true)
            {
                await _gateway.ForwardRequestAsync<object>(
                    "UserApiService",
                    $"/api/user/me/history/add/offer/{id}",
                    HttpMethod.Post,
                    null
                );
            }
            return Ok(offerDictList);

        }


        // =====================================================================
        // CLIENT: добавить заказ в избранное
        // =====================================================================

        [Authorize]
        [HttpPost("me/offer/isfavorite/add/{offerId}")]
        public async Task<IActionResult> AddOfferToClientFavorite(
            int offerId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                      ?? User.FindFirst(JwtRegisteredClaimNames.Sub);
            if (userIdClaim == null)
                return Unauthorized();
            if (!int.TryParse(userIdClaim.Value, out var userId))
                return Unauthorized();
            var result = await _gateway.ForwardRequestAsync<object>(
                "UserApiService",
                $"/api/user/client/offer/isfavorite/add/{offerId}",
                HttpMethod.Post,
                null
            );
            return result;

        }


        //============================================================================================
        //                                               ближайшие  достопримечательности
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

     
            var latitude = rentObj["latitude"];
            var longitude = rentObj["longitude"];

            var url = $"/api/attraction/near/by-distance/{latitude}/{longitude}/{distance}";
            var attractionsObjResult = await _gateway.ForwardRequestAsync<object>(
                "AttractionApiService",
                url,
                HttpMethod.Get,
                null
            );


            if (attractionsObjResult is not OkObjectResult okAttraction)
                return attractionsObjResult;
            var attractionDictList = BffHelper.ConvertActionResultToDict(okAttraction);


            var translateList = await GetTranslationsAsync("en", "attraction");

    
            var updateAttractionList =  UpdateListWithTranslations(attractionDictList, translateList);

            return Ok(updateAttractionList);
        }







            //============================================================================================
            //                                                создание заказа
            //============================================================================================


            [HttpPost("create/booking-order")]
        [Authorize]
        public async Task<IActionResult> CreateOrder(
             [FromBody] CreateOrderRequest request,
             string lang)
        {

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                      ?? User.FindFirst(JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null)
                return Unauthorized();

            if (!int.TryParse(userIdClaim.Value, out var userId))
                return Unauthorized();

     
            var userObjResult = await _gateway.ForwardRequestAsync<object>(
                "UserApiService",
                $"/api/user/me",
                HttpMethod.Get,
                null
            );

            if (userObjResult is not OkObjectResult okUser)
                return userObjResult;

            var userDictList = BffHelper.ConvertActionResultToDict(okUser);
            var user = userDictList[0];
            var discount = decimal.Parse(user["discount"].ToString());



            var offerRequest = OfferByIdRequest.MapToResponse(request.StartDate, request.EndDate, request.Guests);
           
            var offerQuery = QueryString.Create(new Dictionary<string, string?>
            {
                ["startDate"] = offerRequest.StartDate.ToString("O"),
                ["endDate"] = offerRequest.EndDate.ToString("O"),
                ["guests"] = offerRequest.Guests.ToString(),
                ["userDiscountPercent"] = discount.ToString(),
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


            var countryId = rentObj["countryId"];
            var cityId = rentObj["cityId"];
            var address = rentObj["address"];

            var translateOffer = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Offer/get-translations/{request.OfferId}/{lang}", HttpMethod.Get, null);
            var titleOffer = GetStringFromActionResult(translateOffer, "title");

            var translateCountry = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Country/get-translations/{countryId}/{lang}", HttpMethod.Get, null);
            var countryTitle = GetStringFromActionResult(translateCountry, "title");

            var translateCity = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/City/get-translations/{cityId}/{lang}", HttpMethod.Get, null);
            var cityTitle = GetStringFromActionResult(translateCity, "title");

            var orderPrice = offer["orderPrice"];
            var tax = offer["tax"];
            var taxAmount = offer["taxAmount"];
            var totalPrice = offer["totalPrice"];
            var discountPercent = offer["discountPercent"];
            var discountAmount = offer["discountAmount"];
            var depositPersent = offer["depositPersent"];
            var depositAmount = offer["depositAmount"];


            var freeCancelEnabled = offer["freeCancelEnabled"];

            var checkInTime = TimeSpan.Parse(offer["checkInTime"].ToString());
            var checkOutTime = TimeSpan.Parse(offer["checkOutTime"].ToString());



            var paymentStatus = offer["paymentStatus"].ToString();

            var paymentMethod = offer["paymentMethod"].ToString();
            int freeCancelUntilHours = int.Parse(offer["freeCancelUntilHours"].ToString());

            DateTime paidAt = request.StartDate.AddHours(-freeCancelUntilHours);



            var orderRequest = new OrderDto
            {
                OfferId = request.OfferId,
                ClientId = userId,
                Guests = request.Guests,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
               
                OrderPrice = decimal.Parse(orderPrice.ToString()),
                DiscountPercent = decimal.Parse(discountPercent.ToString()),
                DiscountAmount = decimal.Parse(discountAmount.ToString()),
                DepositAmount = decimal.Parse(depositAmount.ToString()),
                TaxAmount = decimal.Parse(taxAmount.ToString()),
                TotalPrice = decimal.Parse(totalPrice.ToString()),
                FreeCancelEnabled = bool.Parse(freeCancelEnabled.ToString()),
                PaidAt = paidAt,
                CheckInTime = checkInTime,
                CheckOutTime = checkOutTime,

                ClientNote = request.ClientNote,
                Status = 0,
                PaymentMethod = paymentMethod,
            };
            var response = await _gateway.ForwardRequestAsync(
                  "OrderApiService",
                  "/api/order/orderAdd",
                  HttpMethod.Post,
                  orderRequest);

            OrderResponse order = new OrderResponse();
            int orderId = -1;
            if (response is ObjectResult obj)
            {
                switch (obj.StatusCode)
                {
                    case StatusCodes.Status201Created:
                        // заказ создан

                        orderId = Convert.ToInt32(obj.Value);
                        Console.WriteLine($"Заказ создан с Id = {orderId}");

                        order.OfferId = request.OfferId;
                        order.ClientId = userId;
                        order.Guests = request.Guests;
                        order.Title = titleOffer;
                        order.Country = countryTitle;
                        order.City = cityTitle;
                        order.Address = address.ToString();
                        order.StartDate = request.StartDate;
                        order.EndDate = request.EndDate;

                        order.BasePrice = decimal.Parse(orderPrice.ToString());
                        order.DiscountPercent = decimal.Parse(discountPercent.ToString());
                        order.DiscountAmount = decimal.Parse(discountAmount.ToString());
                        order.DepositAmount = decimal.Parse(depositAmount.ToString());
                        order.TaxAmount = decimal.Parse(taxAmount.ToString());
                        order.TotalPrice = decimal.Parse(totalPrice.ToString());
                        order.FreeCancelEnabled = bool.Parse(freeCancelEnabled.ToString());
                        order.PaidAt = paidAt;
                        order.CheckInTime = checkInTime;
                        order.CheckOutTime = checkOutTime;
                        order.ClientNote = request.ClientNote;
                        order.Status = "Pending"; // ожидает подтверждения


                        order.PaymentStatus = paymentStatus.ToString();
                        order.PaymentMethod = paymentMethod.ToString();



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



                        BookedDateRequest bookedDateRequest = new BookedDateRequest
                        {
                            Start = request.StartDate,
                            End = request.EndDate,
                            OfferId = request.OfferId,
                        };

                        var dateResponse = await _gateway.ForwardRequestAsync<object>(
                            "OfferApiService",
                            $"/api/bookeddate/create",
                            HttpMethod.Post,
                            bookedDateRequest
                        );

                        if (dateResponse == null)
                        {
                            throw new InvalidOperationException("BookedDate не был создан");
                        }


                        break;
                    case StatusCodes.Status400BadRequest:
                        return BadRequest("Пустой запрос");
                        break;
                    case StatusCodes.Status500InternalServerError:
                        // внутренняя ошибка сервиса
                        break;
                }
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
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                         ?? User.FindFirst(JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null)
                return Unauthorized();

            if (!int.TryParse(userIdClaim.Value, out var userId))
                return Unauthorized();


            var userObjResult = await _gateway.ForwardRequestAsync<object>(
                "UserApiService",
                $"/api/user/me",
                HttpMethod.Get,
                null
            );

            if (userObjResult is not OkObjectResult okUser)
                return userObjResult;

            var userDictList = BffHelper.ConvertActionResultToDict(okUser);
            var user = userDictList[0];

          
            var userRole = user["roleName"].ToString();
            if (!string.Equals(userRole, "owner", StringComparison.OrdinalIgnoreCase))
                return StatusCode(
                    StatusCodes.Status403Forbidden,
                    new { message = "Вы не собственник имущества" }
                );




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

            if (okIsValid.Value is JsonElement json &&
                json.GetBoolean())
            {
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
            }
            else
            {
                return StatusCode(
                    StatusCodes.Status403Forbidden,
                    new { message = "Такого заказа нет у пользователя" }
                );
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



            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                         ?? User.FindFirst(JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null)
                return Unauthorized();

            if (!int.TryParse(userIdClaim.Value, out var userId))
                return Unauthorized();



            if (userIdRequest == userId)
            {
                var reviewRequest = ReviewDto.MapToDto(request, orderId, userId);
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
                        Title = request.Comment
                    };

                var translateReview = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Review/create-translations/{lang}", HttpMethod.Post, translationDto);
                return Ok(reviev);
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


            // Получаем список переводов
            var translateListResult = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Review/get-all-translations/{lang}", HttpMethod.Get, null);


            if (translateListResult is not OkObjectResult okTranslate)
                return reviewsObjResult;


            // Преобразуем переводы в список словарей
            var translationsJson = okTranslate.Value as JsonElement?;
            var translations = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(
                translationsJson?.GetRawText() ?? "[]"
            );
            var reviewDictList = BffHelper.ConvertActionResultToDict(okReviews);
            // Обновляем список 
            UpdateListWithTranslations(reviewDictList, translations);

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
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                      ?? User.FindFirst(JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null)
                return Unauthorized();

            if (!int.TryParse(userIdClaim.Value, out var userId))
                return Unauthorized();


            var reviewsObjResult = await _gateway.ForwardRequestAsync<object>(
                  "ReviewApiService",
                  $"/api/review/get-by-userId/{userId}",
                  HttpMethod.Get,
                  null);


            if (reviewsObjResult is not OkObjectResult okReviews)
                return reviewsObjResult;


            // Получаем список переводов
            var translateListResult = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Review/get-all-translations/{lang}", HttpMethod.Get, null);


            if (translateListResult is not OkObjectResult okTranslate)
                return reviewsObjResult;


            // Преобразуем переводы в список словарей
            var translationsJson = okTranslate.Value as JsonElement?;
            var translations = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(
                translationsJson?.GetRawText() ?? "[]"
            );
            var reviewDictList = BffHelper.ConvertActionResultToDict(okReviews);
            // Обновляем список 
            UpdateListWithTranslations(reviewDictList, translations);

            for (int i = 0; i < reviewDictList.Count; i++)
            {
                var review = reviewDictList[i];

                var offerId = review["offerId"];


                var translateOffer = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Offer/get-translations/{offerId}/{lang}", HttpMethod.Get, null);
                var titleOffer = GetStringFromActionResult(translateOffer, "title");
                //var descriptionOffer = GetStringFromActionResult(translateOffer, "description");

                //review["offerId"] = offerId;
                //review["offerTitle"] = titleOffer;


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

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                      ?? User.FindFirst(JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null)
                return Unauthorized();

            if (!int.TryParse(userIdClaim.Value, out var userId))
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

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                      ?? User.FindFirst(JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null)
                return Unauthorized();

            if (!int.TryParse(userIdClaim.Value, out var userId))
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

        //                                                   private

        //===============================================================================================================


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


        //private List<Dictionary<string, object>> ConvertActionResultToDict(OkObjectResult objResult)
        //{
        //    if (objResult?.Value is JsonElement element)
        //        return ConvertElementToDict(element);
        //    return null;
        //}

        //private List<Dictionary<string, object>> ConvertElementToDict(JsonElement element)
        //{
        //    var dictList = new List<Dictionary<string, object>>();
        //    if (element.ValueKind == JsonValueKind.Array)
        //        dictList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(element.GetRawText());
        //    else if (element.ValueKind == JsonValueKind.Object)
        //    {
        //        var obj = JsonSerializer.Deserialize<Dictionary<string, object>>(element.GetRawText());
        //        dictList.Add(obj);
        //    }
        //    else return null;

        //    foreach (var dl in dictList)
        //        foreach (var key in dl.Keys)
        //            if (dl[key] is JsonElement el
        //                && (el.ValueKind == JsonValueKind.Array || el.ValueKind == JsonValueKind.Object))
        //                dl[key] = ConvertElementToDict(el);
        //    return dictList;
        //}

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




        private List<Dictionary<string, object>> UpdateListWithTranslations(List<Dictionary<string, object>> list, List<Dictionary<string, object>> translations,
            string idFieldName = "id",
            string translationIdFieldName = "entityId")
        {
            foreach (var item in list)
            {
                if (!item.TryGetValue(idFieldName, out var idObj)) continue;
                if (!int.TryParse(idObj.ToString(), out int id)) continue;

                
                var translation = translations.FirstOrDefault(t =>
                    t.TryGetValue(translationIdFieldName, out var eid) &&
                    int.TryParse(eid.ToString(), out int eidInt) &&
                    eidInt == id
                );

                if (translation != null)
                {
                    if (item.ContainsKey("title"))
                        item["title"] = translation["title"];
                    if (item.ContainsKey("description"))
                        item["description"] = translation["description"];

                }
            }
            return list;
        }


      
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
    }
}
