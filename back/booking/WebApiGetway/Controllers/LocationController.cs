using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApiGetway.Service.Interfase;
using System.Text.Json;

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

    [HttpGet("get-country-title/{id}")]
    public Task<IActionResult> GetCountryTitle(int id) =>
       _gateway.ForwardRequestAsync<object>("LocationApiService", $"/api/country/get-country-title/{id}", HttpMethod.Get, null);

    [HttpGet("get-countries-by-district/{id}")]
    public Task<IActionResult> GetByDistrictId(int id) =>
        _gateway.ForwardRequestAsync<object>("LocationApiService", $"/api/country/get-by-district/{id}", HttpMethod.Get, null);



    [HttpGet("get-countries-by-city/{id}")]
    public Task<IActionResult> GetByCityId(int id) =>
        _gateway.ForwardRequestAsync<object>("LocationApiService", $"/api/country/get-by-city/{id}", HttpMethod.Get, null);



    [HttpPost("create")]
    public Task<IActionResult> Create([FromBody] object request) =>
        _gateway.ForwardRequestAsync("LocationApiService", "/api/country/create", HttpMethod.Post, request);
    
        [HttpPut("update/{id}")]
    public Task<IActionResult> Update(int id, [FromBody] object request) =>
        _gateway.ForwardRequestAsync("LocationApiService", $"/api/country/update/{id}", HttpMethod.Put, request);

    [HttpDelete("del/{id}")]
    public Task<IActionResult> Delete(int id) =>
        _gateway.ForwardRequestAsync<object>("LocationApiService", $"/api/country/del/{id}", HttpMethod.Delete, null);


    // ---region---
    [HttpGet("get-region-title/{id}")]
    public Task<IActionResult> GetRegionTitle(int id) =>
      _gateway.ForwardRequestAsync<object>("LocationApiService", $"/api/country/get-region-title/{id}", HttpMethod.Get, null);


    // ---city---
    [HttpGet("get-all-cities")]
    public Task<IActionResult> GetAllCities() =>
        _gateway.ForwardRequestAsync<object>("LocationApiService", "/api/country/get-all-cities", HttpMethod.Get, null);

    [HttpGet("get-cities-from-country/{id}")]
    public Task<IActionResult> GetCitiesByCountryId(int id) =>
    _gateway.ForwardRequestAsync<object>("LocationApiService", $"/api/country/get-cities-from-country/{id}", HttpMethod.Get, null);


    [HttpGet("get-city-title/{id}")]
    public Task<IActionResult> GetCityTitle(int id) =>
     _gateway.ForwardRequestAsync<object>("LocationApiService", $"/api/country/get-city-title/{id}", HttpMethod.Get, null);




    // ---districts---

    [HttpGet("get-district-title/{id}")]
    public Task<IActionResult> GetDistrictTitle(int id) =>
   _gateway.ForwardRequestAsync<object>("LocationApiService", $"/api/country/get-district-title/{id}", HttpMethod.Get, null);




}
