using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApiGetway.Controllers;
using WebApiGetway.Service.Interfase;
using Microsoft.Extensions.Caching.Memory;

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
    //  GET METHODS (для админа)
    //===========================================================================================

    [HttpGet("get-all")]
    public Task<IActionResult> GetAll() =>
        _gateway.ForwardRequestAsync<object>("UserApiService", "/api/user/get-all", HttpMethod.Get, null);

    [HttpGet("get/{id}")]
    public Task<IActionResult> GetById(int id) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/user/get/{id}", HttpMethod.Get, null);


    //===========================================================================================


    [HttpGet("me/{lang}")]
    [Authorize]
    public async Task<IActionResult> GetMe(string lang)
{
        var userResult = await _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/user/me", HttpMethod.Get, null);
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


    [HttpPost("login")]
    public Task<IActionResult> Login([FromBody] object request) =>
        _gateway.ForwardRequestAsync("UserApiService", "/api/auth/login", HttpMethod.Post, request);

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
        _gateway.ForwardRequestAsync("UserApiService", $"/api/user/update", HttpMethod.Put, request);

    [HttpPut("me/change-password")]
    [Authorize]
    public Task<IActionResult> ChangePassword( [FromBody] object request) =>
       _gateway.ForwardRequestAsync("UserApiService", $"/api/user/me/change-password", HttpMethod.Put, request);

    [HttpPut("me/change-email")]
    [Authorize]
    public Task<IActionResult> ChangeEmail([FromBody] object request) =>
    _gateway.ForwardRequestAsync("UserApiService", $"/api/user/me/me/change-email", HttpMethod.Put, request);
    
    
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
               $"/api/offer/get/offers/{userId}",
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
               $"/api/get/offers/{userId}/{cityId}",
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
               $"/api/get/offers/{userId}/{countryId}",
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
        if (!string.Equals(userRole, "client", StringComparison.OrdinalIgnoreCase))
            return StatusCode(
                StatusCodes.Status403Forbidden,
                new { message = "Вы не клиент" }
            );


        var orderObjResult = await _gateway.ForwardRequestAsync<object>(
               "OrderApiService",
               $"/api/order/get/orders/{userId}",
               HttpMethod.Get,
               null
           );

        if (orderObjResult is not OkObjectResult okOrder)
            return orderObjResult;

        var orderDictList = BffHelper.ConvertActionResultToDict(okOrder);


        var orderTranslations = await GetTranslationsAsync(lang, "Order");

        var updateOrderDictList = BffHelper.UpdateListWithTranslations(orderDictList, orderTranslations);

        return Ok(updateOrderDictList);
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
