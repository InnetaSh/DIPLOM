using Microsoft.AspNetCore.Mvc;
using WebApiGetway.Service.Interfase;

[ApiController]
[Route("offer")]
public class OfferController : ControllerBase
{
    private readonly IGatewayService _gateway;

    public OfferController(IGatewayService gateway)
    {
        _gateway = gateway;
    }

    // --- Offers ---
    [HttpGet("get-all")]
    public Task<IActionResult> GetAll() =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", "/api/offer/get-all", HttpMethod.Get, null);

    [HttpGet("get/{id}")]
    public Task<IActionResult> GetById(int id) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/offer/get/{id}", HttpMethod.Get, null);

    [HttpPost("create")]
    public Task<IActionResult> Create([FromBody] object request) =>
        _gateway.ForwardRequestAsync("OfferApiService", "/api/offer/create", HttpMethod.Post, request);

    [HttpPut("update/{id}")]
    public Task<IActionResult> Update(int id, [FromBody] object request) =>
        _gateway.ForwardRequestAsync("OfferApiService", $"/api/offer/update/{id}", HttpMethod.Put, request);

    [HttpDelete("del/{id}")]
    public Task<IActionResult> Delete(int id) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/offer/del/{id}", HttpMethod.Delete, null);

    [HttpGet("by-mainparams")]
    public Task<IActionResult> GetMainSearch()
    {
        var queryString = Request.QueryString.Value ?? string.Empty;
        return _gateway.ForwardRequestAsync<object>(
            "OfferApiService",
            $"/api/offer/by-mainparams{queryString}",
            HttpMethod.Get,
            null
        );
    }

    // --- City ---
    [HttpGet("city/get-all")]
    public Task<IActionResult> GetAllCity() =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", "/api/city/get-all", HttpMethod.Get, null);

    [HttpGet("city/get/{id}")]
    public Task<IActionResult> GetByIdCity(int id) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/city/get/{id}", HttpMethod.Get, null);

    [HttpPost("city/create")]
    public Task<IActionResult> CreateCity([FromBody] object request) =>
        _gateway.ForwardRequestAsync("OfferApiService", "/api/city/create", HttpMethod.Post, request);

    [HttpPut("city/update/{id}")]
    public Task<IActionResult> UpdateCity(int id, [FromBody] object request) =>
        _gateway.ForwardRequestAsync("OfferApiService", $"/api/city/update/{id}", HttpMethod.Put, request);

    [HttpDelete("city/del/{id}")]
    public Task<IActionResult> DeleteCity(int id) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/city/del/{id}", HttpMethod.Delete, null);

    // --- Country, ParamItem, ParamCategory, RentObj, etc. ---
    // По такому же принципу можно добавить остальные сущности.
}
