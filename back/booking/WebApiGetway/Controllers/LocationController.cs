using Microsoft.AspNetCore.Mvc;
using WebApiGetway.Service.Interfase;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    private readonly IGatewayService _gateway;
    public LocationController(IGatewayService gateway)
    {
        _gateway = gateway;
    }


    // ---country---


    [HttpGet("get-all")]
    public Task<IActionResult> GetAll() =>
        _gateway.ForwardRequestAsync<object>("LocationApiService", "/api/country/get-all", HttpMethod.Get, null);

    [HttpGet("get/{id}")]
    public Task<IActionResult> GetById(int id) =>
        _gateway.ForwardRequestAsync<object>("LocationApiService", $"/api/country/get/{id}", HttpMethod.Get, null);

    [HttpGet("get-by-district/{id}")]
    public Task<IActionResult> GetByDistrictId(int id) =>
        _gateway.ForwardRequestAsync<object>("LocationApiService", $"/api/country/get-by-district/{id}", HttpMethod.Get, null);

  

    [HttpPost("create")]
    public Task<IActionResult> Create([FromBody] object request) =>
        _gateway.ForwardRequestAsync("LocationApiService", "/api/country/create", HttpMethod.Post, request);
    
        [HttpPut("update/{id}")]
    public Task<IActionResult> Update(int id, [FromBody] object request) =>
        _gateway.ForwardRequestAsync("LocationApiService", $"/api/country/update/{id}", HttpMethod.Put, request);

    [HttpDelete("del/{id}")]
    public Task<IActionResult> Delete(int id) =>
        _gateway.ForwardRequestAsync<object>("LocationApiService", $"/api/country/del/{id}", HttpMethod.Delete, null);



    // ---city---
    [HttpGet("get-all-cities")]
    public Task<IActionResult> GetAllCities() =>
        _gateway.ForwardRequestAsync<object>("LocationApiService", "/api/country/get-all-cities", HttpMethod.Get, null);

}
