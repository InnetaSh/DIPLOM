using Microsoft.AspNetCore.Mvc;

namespace WebApiGateway.Controllers;

[ApiController]
[Route("[controller]")]
public class GatewayController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;

    public GatewayController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [HttpGet("weather")]
    public async Task<IActionResult> GetWeatherForecast()
    {
        var client = _clientFactory.CreateClient("UserApiService");
        var response = await client.GetAsync("/WeatherForecast");

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<object>();
            return Ok(result);
        }

        return StatusCode((int)response.StatusCode);
    }
}