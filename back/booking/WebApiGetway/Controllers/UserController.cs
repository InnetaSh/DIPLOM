using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApiGetway.Controllers;
using WebApiGetway.Service.Interfase;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IGatewayService _gateway;

    public UserController(IGatewayService gateway)
    {
        _gateway = gateway;
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
}
