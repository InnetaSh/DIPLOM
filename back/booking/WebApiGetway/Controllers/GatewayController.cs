using Microsoft.AspNetCore.Mvc;
using WebApiGetway.Service;
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

    [HttpGet("getOffersMainSearch")]
    public Task<IActionResult> GetOffersMainSearch([FromQuery] string city, [FromQuery] DateTime start, [FromQuery] DateTime end) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService"
        , $"/api/offer/by-main?city={city}&start={start}&end={end}"
        , HttpMethod.Get, null);


    [HttpPost("login")]
    public Task<IActionResult> Login([FromBody] object request) =>
        _gateway.ForwardRequestAsync("UserApiService", "/api/auth/login", HttpMethod.Post, request);

    [HttpPost("register")]
    public Task<IActionResult> Register([FromBody] object request) 
        => _gateway.ForwardRequestAsync("UserApiService", "/api/auth/register", HttpMethod.Post, request);

    [HttpPut("updateUser/{id}")]
    public Task<IActionResult> UpdateUser([FromBody] object request, int id) =>
        _gateway.ForwardRequestAsync("UserApiService", $"/api/auth/update/{id}", HttpMethod.Put, request);

    [HttpDelete("deleteUser/{id}")]
    public Task<IActionResult> DeleteUser(int id) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/auth/delete/{id}", HttpMethod.Delete, null);



    //==================================================================
    //                              OFFER API SERVICE
    //==================================================================

    //[HttpGet("country/get-all")]
    //public Task<IActionResult> GetAllOffers() =>
    //   _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/country/get-all", HttpMethod.Get, null);

    // ---country---

    [HttpGet("country/get-all")]
    public Task<IActionResult> GetAllCountry() =>
       _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/country/get-all", HttpMethod.Get, null);


    [HttpGet("country/get/{id}")]
    public Task<IActionResult> GetByIdCountry(int id) =>
    _gateway.ForwardRequestAsync<object>( "OfferApiService", $"/api/country/get/{id}", HttpMethod.Get,null);


    [HttpPost("country/create")]
    public Task<IActionResult> CreateCountry([FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/country/create", HttpMethod.Post, request);

    [HttpPut("country/update/{id}")]
    public Task<IActionResult> UpdateCountry(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/country/update/{id}", HttpMethod.Put, request);


    [HttpDelete("country/del/{id}")]
    public Task<IActionResult> DeleteCountry(int id) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/country/del/{id}", HttpMethod.Delete, null);





    // ---city---

    [HttpGet("city/get-all")]
    public Task<IActionResult> GetAllCity() =>
      _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/city/get-all", HttpMethod.Get, null);


    [HttpGet("city/get/{id}")]
    public Task<IActionResult> GetByIdCity(int id) =>
    _gateway.ForwardRequestAsync<object>("OfferApiService", $"/apicity/get/{id}", HttpMethod.Get, null);


    [HttpPost("city/create")]
    public Task<IActionResult> CreateCity([FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/city/create", HttpMethod.Post, request);

    [HttpPut("city/update/{id}")]
    public Task<IActionResult> UpdateCity(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/city/update/{id}", HttpMethod.Put, request);


    [HttpDelete("city/del/{id}")]
    public Task<IActionResult> DeleteCity(int id) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/city/del/{id}", HttpMethod.Delete, null);




    // ---param---

    [HttpGet("param/get-all")]
    public Task<IActionResult> GetAllParam() =>
      _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/param/get-all", HttpMethod.Get, null);


    [HttpGet("param/get/{id}")]
    public Task<IActionResult> GetByIdlParam(int id) =>
    _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/param/get/{id}", HttpMethod.Get, null);


    [HttpPost("param/create")]
    public Task<IActionResult> CreatelParam([FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/param/create", HttpMethod.Post, request);

    [HttpPut("param/update/{id}")]
    public Task<IActionResult> UpdatelParam(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/param/update/{id}", HttpMethod.Put, request);


    [HttpDelete("param/del/{id}")]
    public Task<IActionResult> DeletelParam(int id) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/param/del/{id}", HttpMethod.Delete, null);



    // ---params-category---

    [HttpGet("params-category/get-all")]
    public Task<IActionResult> GetAllParamCategory() =>
      _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/paramscategory/get-all", HttpMethod.Get, null);


    [HttpGet("params-category/get/{id}")]
    public Task<IActionResult> GetByIdParamCategory(int id) =>
    _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/paramscategory/get/{id}", HttpMethod.Get, null);


    [HttpPost("params-category/create")]
    public Task<IActionResult> CreateParamCategory([FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/paramscategory/create", HttpMethod.Post, request);

    [HttpPut("params-category/update/{id}")]
    public Task<IActionResult> UpdateParamCategory(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/paramscategory/update/{id}", HttpMethod.Put, request);


    [HttpDelete("params-category/del/{id}")]
    public Task<IActionResult> DeleteParamCategory(int id) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/paramscategory/del/{id}", HttpMethod.Delete, null);



    // ---RentObjParamValue---

    [HttpGet("rentobjparam-value/get-all")]
    public Task<IActionResult> GetAllRentObjParamValue() =>
      _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/rentobjparamvalue/get-all", HttpMethod.Get, null);


    [HttpGet("rentobjparam-value/get/{id}")]
    public Task<IActionResult> GetByIdRentObjParamValue(int id) =>
    _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/rentobjparamvalue/get/{id}", HttpMethod.Get, null);


    [HttpPost("rentobjparam-value/create")]
    public Task<IActionResult> CreateRentObjParamValue([FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/rentobjparamvalue/create", HttpMethod.Post, request);

    [HttpPut("rentobjparam-value/update/{id}")]
    public Task<IActionResult> UpdateRentObjParamValue(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/rentobjparamvalue/update/{id}", HttpMethod.Put, request);


    [HttpDelete("rentobjparam-value/del/{id}")]
    public Task<IActionResult> DeleteRentObjParamValue(int id) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/rentobjparamvalue/del/{id}", HttpMethod.Delete, null);



    // ---RentObjImage---

    [HttpGet("rentobj-image/get-all")]
    public Task<IActionResult> GetAllRentObjImage() =>
      _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/rentobjimage/get-all", HttpMethod.Get, null);


    [HttpGet("rentobj-image/get/{id}")]
    public Task<IActionResult> GetByIdRentObjImage(int id) =>
    _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/rentobjimage/get/{id}", HttpMethod.Get, null);


    [HttpPost("rentobj-image/create")]
    public Task<IActionResult> CreateRentObjImage([FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/rentobjimage/create", HttpMethod.Post, request);

    [HttpPut("rentobj-image/update/{id}")]
    public Task<IActionResult> UpdateRentObjImage(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/rentobjimage/update/{id}", HttpMethod.Put, request);


    [HttpDelete("rentobj-image/del/{id}")]
    public Task<IActionResult> DeleteRentObjImage(int id) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/rentobjimage/del/{id}", HttpMethod.Delete, null);



    // ---RentObj---

    [HttpGet("rentobj/get-all")]
    public Task<IActionResult> GetAllRentObj() =>
      _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/rentobj/get-all", HttpMethod.Get, null);


    [HttpGet("rentobj/get/{id}")]
    public Task<IActionResult> GetByIdRentObj(int id) =>
    _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/rentobj/get/{id}", HttpMethod.Get, null);


    [HttpPost("rentobj/create")]
    public Task<IActionResult> CreateRentObj([FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/rentobj/create", HttpMethod.Post, request);

    [HttpPut("rentobj/update/{id}")]
    public Task<IActionResult> UpdateRentObj(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/rentobj/update/{id}", HttpMethod.Put, request);


    [HttpDelete("rentobj/del/{id}")]
    public Task<IActionResult> DeleteRentObj(int id) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/rentobj/del/{id}", HttpMethod.Delete, null);
}

