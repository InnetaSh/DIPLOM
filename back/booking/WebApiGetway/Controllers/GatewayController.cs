using Microsoft.AspNetCore.Mvc;
using WebApiGetway.Service.Interfase;

[ApiController]
[Route("[controller]")]
public class GatewayController : ControllerBase
{
    private readonly IGatewayService _gateway;

    public GatewayController(IGatewayService gateway)
    {
        _gateway = gateway;
    }

    [HttpGet("weather")]
    public Task<IActionResult> GetWeather() =>
    _gateway.ForwardRequestAsync<object>("WeatherService", "/WeatherForecast", HttpMethod.Get, null);


    [HttpPost("login")]
    public Task<IActionResult> Login([FromBody] object request) =>
        _gateway.ForwardRequestAsync("UserApiService", "/api/auth/login", HttpMethod.Post, request);

    [HttpPut("updateUser/{id}")]
    public Task<IActionResult> UpdateUser([FromBody] object request, int id) =>
        _gateway.ForwardRequestAsync("UserApiService", $"/api/auth/update/{id}", HttpMethod.Put, request);

    [HttpDelete("deleteUser/{id}")]
    public Task<IActionResult> DeleteUser(int id) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/auth/delete/{id}", HttpMethod.Delete, null);
}
