//using Microsoft.AspNetCore.Mvc;
//using WebApiGetway.Service.Interfase;

//[ApiController]
//[Route("weather")]
//public class WeatherController : ControllerBase
//{
//    private readonly IGatewayService _gateway;
//    public WeatherController(IGatewayService gateway) => _gateway = gateway;

//    [HttpGet]
//    public Task<IActionResult> GetWeather() =>
//        _gateway.ForwardRequestAsync<object>("WeatherService", "/WeatherForecast", HttpMethod.Get, null);
//}
