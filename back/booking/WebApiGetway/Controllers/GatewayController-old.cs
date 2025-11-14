//using Globals.Abstractions;
//using Globals.EventBus;
//using Microsoft.AspNetCore.Identity.Data;
//using Microsoft.AspNetCore.Mvc;

//namespace WebApiGateway.Controllers;

//[ApiController]
//[Route("[controller]")]
//public class GatewayController : ControllerBase
//{
//    private readonly IHttpClientFactory _clientFactory;
//    private readonly IRabbitMqService _mqService;

//    public GatewayController(IHttpClientFactory clientFactory, IRabbitMqService mqService)
//    {
//        _clientFactory = clientFactory;
//        _mqService = mqService;
//    }

//    [HttpGet("weather")]
//    public async Task<IActionResult> GetWeatherForecast()
//    {
//        var client = _clientFactory.CreateClient("UserApiService");
//        var response = await client.GetAsync("/WeatherForecast");

//        if (response.IsSuccessStatusCode)
//        {
//            _mqService.SendMessage(new RabbitMQMessageBase(nameof(GatewayController), nameof(GetWeatherForecast), "Get Weather Forecast"));
//            var result = await response.Content.ReadFromJsonAsync<object>();
//            return Ok(result);
//        }

//        return StatusCode((int)response.StatusCode);
//    }

//    ========================AUTH===================================

//    [HttpPost("login")]
//    public async Task<IActionResult> Login([FromBody] LoginRequest request)
//    {
//        var client = _clientFactory.CreateClient("UserApiService");

//        var response = await client.PostAsJsonAsync("/api/auth/login", request);

//        if (response.IsSuccessStatusCode)
//        {
//            _mqService.SendMessage(
//                new RabbitMQMessageBase("AuthController", nameof(Login), "User logged in")
//            );

//            var result = await response.Content.ReadFromJsonAsync<object>();
//            return Ok(result);
//        }

//        return StatusCode((int)response.StatusCode);
//    }

//    [HttpPost("register")]
//    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
//    {
//        var client = _clientFactory.CreateClient("UserApiService");

//        var response = await client.PostAsJsonAsync("/api/auth/register", request);

//        if (response.IsSuccessStatusCode)
//        {
//            _mqService.SendMessage(
//                new RabbitMQMessageBase("AuthController", nameof(Register), "User registered")
//            );

//            var result = await response.Content.ReadFromJsonAsync<object>();
//            return Ok(result);
//        }

//        var error = await response.Content.ReadAsStringAsync();
//        return StatusCode((int)response.StatusCode, error);
//    }


//    =======================================================================


//    [HttpGet("sendMsg")]
//    public async Task<IActionResult> SendMsg()
//    {
//        _mqService.SendMessage(new RabbitMQMessageBase(nameof(GatewayController), nameof(SendMsg), "send test messages"));
//        return Ok("Msg send");
//    }

//}