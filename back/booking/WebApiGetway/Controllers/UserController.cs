using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApiGetway.Controllers;
using WebApiGetway.Service.Interfase;
using WebApiGetway.View;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IGatewayService _gateway;
    private readonly IMemoryCache _cache;
    public UserController(IGatewayService gateway, IMemoryCache cache)
    {
        _gateway = gateway;
        _cache = cache;
    }

    //===========================================================================================
    //  GET METHODS (для админа) - получить всех пользователей
    //===========================================================================================

    [HttpGet("get-all")]
    public Task<IActionResult> GetAll() =>
        _gateway.ForwardRequestAsync<object>("UserApiService", "/api/user/get-all", HttpMethod.Get, null);



    //===========================================================================================
    //  GET METHODS (для админа) - получить полную информацию о пользователе по Id
    //===========================================================================================
    [HttpGet("get/{userId}")]
    public Task<IActionResult> GetById(int userId) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/user/admin/get/userfullinfo/{userId}", HttpMethod.Get, null);

    // ==========================================================================================
    // GET METHODS (для админа) - получить полную информацию о пользователе по email
    // ==========================================================================================
    [HttpGet("get/{email}")]
    public Task<IActionResult> GetByEmail(string email) =>
       _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/user/admin/get/userfullinfo/{email}", HttpMethod.Get, null);






    [HttpPost("google")]
    public Task<IActionResult> GoogleLogin([FromBody] object request) =>
      _gateway.ForwardRequestAsync("UserApiService", $"/api/auth/google", HttpMethod.Post, request);


    //===========================================================================================
    //  GET METHODS (для авторизованного пользователя) - получить полную информацию о себе
    //===========================================================================================

    [HttpGet("me/{lang}")]
    [Authorize]
    public async Task<IActionResult> GetMe(string lang)
{
        var userResult = await _gateway.ForwardRequestAsync<object>(
            "UserApiService",
            $"/api/user/me",
            HttpMethod.Get,
            null
            );
        if (userResult is not OkObjectResult okResult)
        {
            return userResult;
        }
        var userDictList = BffHelper.ConvertActionResultToDict(okResult);

        var user = userDictList[0];
        int userId = int.Parse(user["id"].ToString());
        int countryId = int.Parse(user["countryId"].ToString());

        var cityResult = await _gateway.ForwardRequestAsync<object>(
                "TranslationApiService",
                $"/api/country/get-translations/{countryId}/{lang}",
                HttpMethod.Get,
                null
            );
        if (cityResult is not OkObjectResult okCityResult)
        {
            return Ok(user);
        }
        var cityDictList = BffHelper.ConvertActionResultToDict(okCityResult);
        user["countryTitle"] = cityDictList[0]["title"];
        return Ok(user);
    }

    //===========================================================================================
    //  AUTH METHODS - login / register
    //===========================================================================================

    [HttpPost("login")]
    public Task<IActionResult> Login([FromBody] object request) =>
        _gateway.ForwardRequestAsync("UserApiService", "/api/auth/login", HttpMethod.Post, request);

    //===========================================================================================
    //  REGISTRATION METHODS - register client / register owner
    //===========================================================================================

    [HttpPost("register/client")]
    public Task<IActionResult> RegisterClient([FromBody] object request) =>
        _gateway.ForwardRequestAsync("UserApiService", "/api/auth/register/client", HttpMethod.Post, request);

    [HttpPost("register/owner")]
    public Task<IActionResult> RegisterOwner([FromBody] object request) =>
      _gateway.ForwardRequestAsync("UserApiService", "/api/auth/register/owner", HttpMethod.Post, request);


    //===========================================================================================


    [HttpPut("me/update")]
    [Authorize]
    public Task<IActionResult> Update( [FromBody] object request) =>
        _gateway.ForwardRequestAsync("UserApiService", $"/api/user/me/update", HttpMethod.Post, request);

    [HttpPut("me/change-password")]
    [Authorize]
    public Task<IActionResult> ChangePassword( [FromBody] object request) =>
       _gateway.ForwardRequestAsync("UserApiService", $"/api/user/me/change-password", HttpMethod.Post, request);

    [HttpPut("me/change-email")]
    [Authorize]
    public Task<IActionResult> ChangeEmail([FromBody] object request) =>
    _gateway.ForwardRequestAsync("UserApiService", $"/api/user/me/change-email", HttpMethod.Post, request);
    
    
    //===========================================================================================

    [HttpDelete("delete/me")]
    [Authorize]
    public Task<IActionResult> Delete(int id) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/auth/delete/{id}", HttpMethod.Delete, null);




    // =====================================================================
    //  получить обьявления владельцем
    // =====================================================================
    [Authorize]
    [HttpGet("me/offers/{lang}")]
    public async Task<IActionResult> GetMyOffers(string lang)
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


        var offerObjResult = await _gateway.ForwardRequestAsync<object>(
               "OfferApiService",
               $"/api/Offer/get/offersByOwner/{userId}",
               HttpMethod.Get,
               null
           );

        if (offerObjResult is not OkObjectResult okOffer)
            return offerObjResult;

        var offerDictList = BffHelper.ConvertActionResultToDict(okOffer);
        var translateListResult = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Offer/get-all-translations/{lang}", HttpMethod.Get, null);

        var transItemDict = BffHelper.ConvertActionResultToDict(translateListResult as OkObjectResult);

      
      

        //var offerTranslations = await GetTranslationsAsync(lang, "Offer");

        var updateOfferDictList = BffHelper.UpdateListWithTranslations(offerDictList, transItemDict);


        var idList = new List<int>();
        foreach (var statsOffer in updateOfferDictList)
        {
            var id = int.Parse(statsOffer["id"].ToString());
            idList.Add(id);
        }
        //получаем рейтинг
        var ratingObjResult = await _gateway.ForwardRequestAsync<object>("ReviewApiService", $"/api/review/search/offers/rating", HttpMethod.Post, idList);
        if (ratingObjResult is not OkObjectResult okRating)
            return Ok(updateOfferDictList);
        var ratingDictList = BffHelper.ConvertActionResultToDict(okRating);

        BffHelper.UpdateOfferListWithRating(updateOfferDictList, ratingDictList);

        return Ok(updateOfferDictList);
    }


    // =====================================================================
    //  получить обьявления владельцем по конкретному городу
    // =====================================================================
    [Authorize]
    [HttpGet("me/offers/{cityId:int}/{lang}")]
    public async Task<IActionResult> GetMyOffersByCity(int cityId, string lang)
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



        var offerObjResult = await _gateway.ForwardRequestAsync<object>(
               "OfferApiService",
               $"/api/Offer/get/offers/{userId}/{cityId}",
               HttpMethod.Get,
               null
           );

        if (offerObjResult is not OkObjectResult okOffer)
            return offerObjResult;

        var offerDictList = BffHelper.ConvertActionResultToDict(okOffer);


        var offerTranslations = await GetTranslationsAsync(lang, "Offer");

        var updateOfferDictList = BffHelper.UpdateListWithTranslations(offerDictList, offerTranslations);

        return Ok(updateOfferDictList);
    }



    // =====================================================================
    //  получить обьявления владельцем по конкретной стране
    // =====================================================================
    [Authorize]
    [HttpGet("me/offers/{countryId:int}/{lang}")]
    public async Task<IActionResult> GetMyOffersByCountry(int countryId, string lang)
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



        var offerObjResult = await _gateway.ForwardRequestAsync<object>(
               "OfferApiService",
               $"/api/Offer/get/offers/{userId}/{countryId}",
               HttpMethod.Get,
               null
           );

        if (offerObjResult is not OkObjectResult okOffer)
            return offerObjResult;

        var offerDictList = BffHelper.ConvertActionResultToDict(okOffer);


        var offerTranslations = await GetTranslationsAsync(lang, "Offer");

        var updateOfferDictList = BffHelper.UpdateListWithTranslations(offerDictList, offerTranslations);

        return Ok(updateOfferDictList);
    }


    // =====================================================================
    // проверить есть ли новые не подтвержденные брони у owner
    // =====================================================================
    [Authorize]
    [HttpGet("me/myOffers/orders/has-pending")]
    public async Task<IActionResult> HasPendingOrder()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                         ?? User.FindFirst(JwtRegisteredClaimNames.Sub);

        if (userIdClaim == null)
            return Unauthorized();

        if (!int.TryParse(userIdClaim.Value, out var userId))
            return Unauthorized();

        return await _gateway.ForwardRequestAsync<object>(
             "OrderApiService",
             $"/api/Order/has-pending/{userId}",
             HttpMethod.Get,
             null
         );
    }


        // =====================================================================
        //  получить брони клиентом
        // =====================================================================
        [Authorize]
    [HttpGet("me/orders/{lang}")]
    public async Task<IActionResult> GetMyOrders(string lang)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                         ?? User.FindFirst(JwtRegisteredClaimNames.Sub);

        if (userIdClaim == null)
            return Unauthorized();

        if (!int.TryParse(userIdClaim.Value, out var userId))
            return Unauthorized();



        var orderObjResult = await _gateway.ForwardRequestAsync<object>(
               "OrderApiService",
               $"/api/order/get/orders/{userId}",
               HttpMethod.Get,
               null
           );

        if (orderObjResult is not OkObjectResult okOrder)
            return orderObjResult;

        var orderDictList = BffHelper.ConvertActionResultToDict(okOrder);


        var orderState = "Completed";
        foreach (var order in orderDictList)
        {
            if (order.ContainsKey("endDate") && order["endDate"] != null)
            {
                if (DateTimeOffset.TryParse(order["endDate"]?.ToString(), out var dto))
                {
                    if (dto.UtcDateTime < DateTime.UtcNow && order["status"] != orderState)
                    {

                        var orderId = int.Parse(order["id"].ToString());
                       

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
                }
            }
        }

        var orderTranslations = await GetTranslationsAsync(lang, "Order");

        var updateOrderDictList = BffHelper.UpdateListWithTranslations(orderDictList, orderTranslations);


        var OrderResponse = new List<OrderResponseForAccountCard>();

        foreach (var orderDict in updateOrderDictList)
        {
            var idOrder = int.Parse(orderDict["id"].ToString());

            var idOffer = int.Parse(orderDict["offerId"].ToString());


            var offerObjResult = await _gateway.ForwardRequestAsync<object>(
                  "OfferApiService",
                  $"/api/offer/get/{idOffer}",
                  HttpMethod.Get,
                  null
              );

            if (offerObjResult is not OkObjectResult okOffer)
                return offerObjResult;

            var offerDictList = BffHelper.ConvertActionResultToDict(okOffer);
            if (offerDictList == null || !offerDictList.Any())
                continue;

            var offer = offerDictList.FirstOrDefault();
            if (offer == null)
                continue;

            if (!offer.TryGetValue("rentObj", out var rentObjRaw))
                continue;

            var rentList = rentObjRaw as List<Dictionary<string, object>>;
            var rentObj = rentList?.FirstOrDefault();
            if (rentObj == null)
                continue;

            var imageList = rentObj["images"] as List<Dictionary<string, object>>;
            var mainImgUrl = imageList?.FirstOrDefault()?["url"]?.ToString() ?? "";


            var countryId = int.Parse(rentObj["countryId"].ToString());
            var cityId = int.Parse(rentObj["cityId"].ToString());

            var translateOffer = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Offer/get-translations/{idOffer}/{lang}", HttpMethod.Get, null);
            string? titleOffer = null;

            if (translateOffer is OkObjectResult okOfferTr)
            {
                var offerTranslateDictList = BffHelper.ConvertActionResultToDict(okOfferTr);
                titleOffer = offerTranslateDictList?.FirstOrDefault()?["title"]?.ToString()
                             ?? titleOffer;
            }

            //var translateCountry = await _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/Country/get-translations/{countryId}/{lang}", HttpMethod.Get, null);
            //var countryTranslateDictList = BffHelper.ConvertActionResultToDict(okOffer);
            //var countruTr = countryTranslateDictList[0];
            //var countryTitle = offerTr["Title"].ToString();


            orderDict.TryGetValue("offerId", out var offerIdRaw);
            orderDict.TryGetValue("startDate", out var startDateRaw);
            orderDict.TryGetValue("endDate", out var endDateRaw);
            orderDict.TryGetValue("paymentMethod", out var paymentRaw);
            orderDict.TryGetValue("status", out var statusRaw);

            orderDict.TryGetValue("totalPrice", out var totalPriceRaw);

            var order = new OrderResponseForAccountCard
            {
                OrderId = idOrder,
                OfferId = int.TryParse(offerIdRaw?.ToString(), out var oid) ? oid : 0,
                ClientId = userId,
                CityId = cityId,
                Title = titleOffer ?? "Без названия",
                StartDate = startDateRaw?.ToString() ?? "",
                EndDate = endDateRaw?.ToString() ?? "",
                TotalPrice = decimal.TryParse(totalPriceRaw?.ToString(), out var price) ? price : 0,
                PaymentMethod = paymentRaw?.ToString() ?? "",
                Status = statusRaw?.ToString() ?? "",
                MainImageUrl = mainImgUrl ?? ""
            };

            OrderResponse.Add(order);

        }


        return Ok(OrderResponse);
    }





    //=====================================================================
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
}
