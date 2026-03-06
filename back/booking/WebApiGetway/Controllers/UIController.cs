using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApiGetway.Models.Enum;
using WebApiGetway.Service.Interfase;
using WebApiGetway.View;

namespace WebApiGetway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UIController : ControllerBase
    {
        private readonly IGatewayService _gateway;
        private readonly IMemoryCache _cache;
        public UIController(IGatewayService gateway, IMemoryCache cache)
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
    }
}
