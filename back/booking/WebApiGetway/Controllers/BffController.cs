using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Net;
using System.Text.Json;
using System.Xml.Linq;
using WebApiGetway.Service.Interfase;
using WebApiGetway.View;
using System.Text.Json;

namespace WebApiGetway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BffController : ControllerBase
    {
        private readonly IGatewayService _gateway;

        public BffController(IGatewayService gateway)
        {
            _gateway = gateway;
        }




        //[HttpGet("country/{id}/{lang}")]
        //public async Task<IActionResult> GetCountryById(int id, string lang)
        //{
        //    var translateCountry = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/country/get-translations/{id}/{lang}", HttpMethod.Get, null);
        //    var titleCountry = GetTitleFromActionResult(translateCountry, "title");

        //    var countryObj = await _gateway.ForwardRequestAsync<object>("LocationApiService", $"/api/country/get/{id}", HttpMethod.Get, null);
        //    SetTitleToActionResult(countryObj, titleCountry);

        //    return Ok(countryObj);

        //}


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


        [HttpGet("params/category/main/{lang}")]
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
            var paramDictList = ConvertActionResultToDict(okParamCategory);
            // Обновляем список 
            UpdateListWithTranslations(paramDictList, translations);


            // получаем список названий параметров для главного екрана
            var translateItemListResult = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/paramitem/get-all-translations/{lang}", HttpMethod.Get, null);
            var transItemDict = ConvertActionResultToDict(translateItemListResult as OkObjectResult);
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


        [HttpGet("paramitem/main/{lang}")]
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
            var paramDictList = ConvertActionResultToDict(okParamItem);
            // Обновляем список 
            UpdateListWithTranslations(paramDictList, translations);



            return Ok(paramDictList);
        }
        //=============================================================================
        //                      получаем список обьявлений по главному запросу
        //=============================================================================

        [HttpGet("search/main/{lang}")]
        public async Task<IActionResult> GetMainSearch(
         string lang,
         [FromQuery] OfferMainSearchRequest request,
         [FromQuery] decimal userDiscountPercent)
        {
            var queryString = Request.QueryString.Value ?? string.Empty;

            // Получаем список объявлений
            var offerObjResult = await _gateway.ForwardRequestAsync<object>(
                "OfferApiService",
                $"/api/offer/search/main{queryString}",
                HttpMethod.Get,
                null);

            if (offerObjResult is not OkObjectResult okOffer)
                return offerObjResult;

            // Получаем список переводов
            var translateListResult = await _gateway.ForwardRequestAsync<object>(
                "TranslationApiService",
                $"/api/Offer/get-all-translations/{lang}",
                HttpMethod.Get,
                null);

            if (translateListResult is not OkObjectResult okTranslate)
                return offerObjResult;

            var translations = ConvertActionResultToDict(okTranslate);

            // Берём город один раз
            int cityId = request.CityId;
            var cityObj = await _gateway.ForwardRequestAsync<object>(
                "LocationApiService",
                $"/api/city/get/{cityId}",
                HttpMethod.Get,
                null);

            var cityLat = GetDoubleFromActionResult(cityObj, "latitude").Value;
            var cityLon = GetDoubleFromActionResult(cityObj, "longitude").Value;

            var offerDictList = ConvertActionResultToDict(okOffer);

            // Применяем переводы
            var updateOfferDictList = UpdateListWithTranslations(offerDictList, translations);

            // Обновляем все объявления: переписываем DistanceToCenter у родителя
            var result = UpdateAllOffersDistance(offerDictList, cityLat, cityLon); 

            return Ok(offerDictList);
        }

       


        //======================================================================================
        //                      получаем полные данные об обьявлении по id
        //======================================================================================





        [HttpGet("search/booking/{id}/{lang}")]
        public async Task<IActionResult> GetFullOfferById(int id, 
          string lang,
         [FromQuery] OfferByIdRequest request,
         [FromQuery] decimal userDiscountPercent)
        {
            var queryString = Request.QueryString.Value ?? string.Empty;

            var offerObjResult = await _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/offer/get-offer/{id}{queryString}", HttpMethod.Get, null);

            if (offerObjResult is not OkObjectResult okOffer)
                return offerObjResult;

            var offerDictList = ConvertActionResultToDict(okOffer);
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
            var transItemDict = ConvertActionResultToDict(translateParamListResult as OkObjectResult);

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
            return Ok(offerDictList);

        }


        //======================================================================================


        // Карточка отзывы + автор
        [HttpGet("offer-review-card/{id}")]
        public async Task<IActionResult> GetOfferReviewCard(int id)
        {

            var reviewsTask = _gateway.ForwardRequestAsync<List<ReviewDto>>(
                "OfferApiService", $"/api/review/get-by-offerId/{id}", HttpMethod.Get, null);

            await Task.WhenAll(reviewsTask);


            var reviews = (reviewsTask.Result as OkObjectResult)?.Value as List<ReviewDto>;


            if (reviews.Count == 0) return NotFound("Reviews not found");

            var reviewWithUsers = new List<ReviewWithUserDto>();
            foreach (var r in reviews)
            {
                var userResponce = await _gateway.ForwardRequestAsync<UserDto>(
                    "UserApiService", $"/api/user/get/{r.UserId}", HttpMethod.Get, null);
                var user = (userResponce as OkObjectResult)?.Value as UserDto;

                reviewWithUsers.Add(new ReviewWithUserDto
                {
                    id = r.id,
                    Comment = r.Comment,
                    OverallRating = r.OverallRating,
                    CreatedAt = r.CreatedAt,
                    UpdatedAt = r.UpdatedAt,
                    User = new UserShortInfo()
                    {
                        Username = user.Username
                    }
                });
            }

            return Ok(reviewWithUsers);
        }






        //============================================================================================
        //                                                создание заказа
        //============================================================================================


        [HttpPost("create/booking")]
        public async Task<IActionResult> CreateOrder(
             [FromBody] CreateOrderRequest request,
             [FromQuery] decimal userDiscountPercent,
             string lang)
        {

            var offerRequest = new OfferByIdRequest
            {
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Guests = request.Guests
            };

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

            var offerDictList = ConvertActionResultToDict(okOffer);
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
                ClientId = request.ClientId,
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

            if (response is ObjectResult obj)
            {
                switch (obj.StatusCode)
                {
                    case StatusCodes.Status201Created:
                        // заказ создан

                        order.OfferId = request.OfferId;
                        order.ClientId = request.ClientId;
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

        private List<Dictionary<string, object>> ConvertActionResultToDict(OkObjectResult objResult)
        {
            if (objResult?.Value is JsonElement element)
                return ConvertElementToDict(element);
            return null;
        }

        private List<Dictionary<string, object>> ConvertElementToDict(JsonElement element)
        {
            var dictList = new List<Dictionary<string, object>>();
            if (element.ValueKind == JsonValueKind.Array)
                dictList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(element.GetRawText());
            else if (element.ValueKind == JsonValueKind.Object)
            {
                var obj = JsonSerializer.Deserialize<Dictionary<string, object>>(element.GetRawText());
                dictList.Add(obj);
            }
            else return null;

            foreach (var dl in dictList)
                foreach (var key in dl.Keys)
                    if (dl[key] is JsonElement el
                        && (el.ValueKind == JsonValueKind.Array || el.ValueKind == JsonValueKind.Object))
                        dl[key] = ConvertElementToDict(el);
            return dictList;
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




        //private bool SetTitleToActionResult(object result, string title)
        //{
        //    var valuePi = result.GetType().GetProperty("Value");
        //    if (valuePi != null)
        //    {
        //        var val = valuePi.GetValue(result);
        //        if (val is JsonElement jsonElement)
        //        {

        //            var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonElement.GetRawText());

        //            if (dict != null)
        //            {
        //                dict["title"] = title; 


        //                if (result is Microsoft.AspNetCore.Mvc.OkObjectResult okResult)
        //                {
        //                    okResult.Value = dict;
        //                    return true;
        //                }
        //            }
        //        }
        //    }
        //    return false;
        //}



        private bool SetPropertiesFromDictionaryToActionResult(object result, Dictionary<string, string> properties)
        {
            var valuePi = result.GetType().GetProperty("Value");
            if (valuePi != null)
            {
                var val = valuePi.GetValue(result);
                if (val is JsonElement jsonElement)
                {
                    // Десериализуем Json в словарь
                    var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonElement.GetRawText());
                    if (dict != null)
                    {
                        // Обновляем все свойства из словаря
                        foreach (var kvp in properties)
                        {
                            dict[kvp.Key] = kvp.Value;
                        }

                        // Присваиваем обратно, если это OkObjectResult
                        if (result is Microsoft.AspNetCore.Mvc.OkObjectResult okResult)
                        {
                            okResult.Value = dict;
                            return true;
                        }
                    }
                }
            }
            return false;
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

                    //foreach (var kvp in translation)
                    //{
                    //    if (kvp.Key == translationIdFieldName) continue; 
                    //    item[kvp.Key] = kvp.Value;
                    //}
                }
            }
            return list;
        }


        private int? GetNestedIntFromActionResult(object result, string objectName, string fieldName)
        {
            var value_pi = result.GetType().GetProperty("Value");
            if (value_pi != null)
            {
                var val = value_pi.GetValue(result);
                if (val is JsonElement jsonElement)
                {
                    //if(jsonElement.TryGetProperty(objectName, out var field))
                    //{
                    //    if (field.TryGetInt32(out int v))
                    //        return v;
                    //}
                    if (jsonElement.ValueKind == JsonValueKind.Object &&
                        jsonElement.TryGetProperty(objectName, out var nestedObj))
                    {
                        if (nestedObj.ValueKind == JsonValueKind.Object &&
                            nestedObj.TryGetProperty(fieldName, out var field))
                        {
                            if (field.TryGetInt32(out int v))
                                return v;
                        }
                    }
                }
            }
            return null;
        }



        private decimal? GetNestedDecimal(object result, string parentName, string fieldName)
        {
            var valueProperty = result.GetType().GetProperty("Value");
            if (valueProperty == null)
                return null;

            var val = valueProperty.GetValue(result);
            if (val is not JsonElement root)
                return null;

            return FindDecimalUnderParent(root, parentName, fieldName, insideParent: false);
        }

        private decimal? FindDecimalUnderParent(JsonElement element, string parentName, string fieldName, bool insideParent)
        {
            // ---- Если мы уже находимся внутри родительского объекта ----
            if (insideParent)
            {
                if (element.ValueKind == JsonValueKind.Object)
                {
                    foreach (var prop in element.EnumerateObject())
                    {
                        // проверяем нужный параметр
                        if (prop.NameEquals(fieldName))
                        {
                            if (prop.Value.ValueKind == JsonValueKind.Number &&
                                prop.Value.TryGetDecimal(out decimal decValue))
                            {
                                return decValue;
                            }
                        }

                        // рекурсивно продолжаем искать внутри родителя
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

            // ---- Ещё не нашли родителя — ищем parentName ----
            if (element.ValueKind == JsonValueKind.Object)
            {
                foreach (var prop in element.EnumerateObject())
                {
                    // нашли нужного родителя
                    if (prop.NameEquals(parentName))
                    {
                        return FindDecimalUnderParent(prop.Value, parentName, fieldName, insideParent: true);
                    }

                    // продолжаем поиск
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
