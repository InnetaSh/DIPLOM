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



    [HttpGet("user/get-all")]
    public Task<IActionResult> GetAllUser() =>
      _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/user/get-all", HttpMethod.Get, null);

    [HttpGet("user/get/{id}")]
    public Task<IActionResult> GetByIdUser(int id) =>
     _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/user/get/{id}", HttpMethod.Get, null);


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
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/country/del/{id}", HttpMethod.Delete, null);





    // ---city---

    [HttpGet("city/get-all")]
    public Task<IActionResult> GetAllCity() =>
      _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/city/get-all", HttpMethod.Get, null);


    [HttpGet("city/get/{id}")]
    public Task<IActionResult> GetByIdCity(int id) =>
    _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/city/get/{id}", HttpMethod.Get, null);


    [HttpPost("city/create")]
    public Task<IActionResult> CreateCity([FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/city/create", HttpMethod.Post, request);

    [HttpPut("city/update/{id}")]
    public Task<IActionResult> UpdateCity(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/city/update/{id}", HttpMethod.Put, request);


    [HttpDelete("city/del/{id}")]
    public Task<IActionResult> DeleteCity(int id) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/city/del/{id}", HttpMethod.Delete, null);




    // ---param item---

    [HttpGet("paramitem/get-all")]
    public Task<IActionResult> GetAllParam() =>
      _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/paramitem/get-all", HttpMethod.Get, null);


    [HttpGet("paramitem/get/{id}")]
    public Task<IActionResult> GetByIdlParam(int id) =>
    _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/paramitem/get/{id}", HttpMethod.Get, null);


    [HttpPost("paramitem/create")]
    public Task<IActionResult> CreatelParam([FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/paramitem/create", HttpMethod.Post, request);

    [HttpPut("paramitem/update/{id}")]
    public Task<IActionResult> UpdatelParam(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/paramitem/update/{id}", HttpMethod.Put, request);


    [HttpDelete("paramitem/del/{id}")]
    public Task<IActionResult> DeletelParam(int id) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/paramitem/del/{id}", HttpMethod.Delete, null);



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
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/paramscategory/del/{id}", HttpMethod.Delete, null);



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
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/rentobjparamvalue/del/{id}", HttpMethod.Delete, null);



    // ---RentObjImage---

    [HttpPut("rentobj-image/update/{imageId}")]
    [Consumes("multipart/form-data")]
    public Task<IActionResult> UpdateRentObjImage(int imageId, IFormFile file)
    {
        return _gateway.ForwardFileAsync(
            "OfferApiService",
            $"/api/rentobjimage/update-file/{imageId}",
            HttpMethod.Put,
            file
        );
    }


    [HttpPost("rentobj-image/upload/{rentObjId}")]
    [Consumes("multipart/form-data")]
    public Task<IActionResult> UploadRentObjImage(int rentObjId, IFormFile file)
    {
        return _gateway.ForwardFileAsync(
            "OfferApiService",
            $"/api/rentobjimage/upload/{rentObjId}",
            HttpMethod.Post,
            file
        );
    }


    [HttpDelete("rentobj-image/del/{id}")]
    public Task<IActionResult> DeleteRentObjImage(int imageId) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/rentobjimage/delete/{imageId}", HttpMethod.Delete, null);



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
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/rentobj/del/{id}", HttpMethod.Delete, null);





    // ---BookedDate---

    [HttpGet("bookeddate/get-all")]
    public Task<IActionResult> GetAllBookedDate() =>
      _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/bookeddate/get-all", HttpMethod.Get, null);


    [HttpGet("bookeddate/get/{id}")]
    public Task<IActionResult> GetByIdBookedDate(int id) =>
    _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/bookeddate/get/{id}", HttpMethod.Get, null);


    [HttpPost("bookeddate/create")]
    public Task<IActionResult> CreateBookedDate([FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/bookeddate/create", HttpMethod.Post, request);

    [HttpPut("bookeddate/update/{id}")]
    public Task<IActionResult> UpdateBookedDate(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/bookeddate/update/{id}", HttpMethod.Put, request);


    [HttpDelete("bookeddate/del/{id}")]
    public Task<IActionResult> DeleteBookedDate(int id) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/bookeddate/del/{id}", HttpMethod.Delete, null);



    // ---Review---

    [HttpGet("review/get-all")]
    public Task<IActionResult> GetAllReview() =>
      _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/review/get-all", HttpMethod.Get, null);


    [HttpGet("review/get/{id}")]
    public Task<IActionResult> GetByIdReview(int id) =>
    _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/review/get/{id}", HttpMethod.Get, null);


    [HttpPost("review/create")]
    public Task<IActionResult> CreateReview([FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/review/create", HttpMethod.Post, request);

    [HttpPut("review/update/{id}")]
    public Task<IActionResult> UpdateReview(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/review/update/{id}", HttpMethod.Put, request);


    [HttpDelete("review/del/{id}")]
    public Task<IActionResult> DeleteReview(int id) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/review/del/{id}", HttpMethod.Delete, null);



    // ---Offer---

    [HttpGet("offer/get-all")]
    public Task<IActionResult> GetAllOffer() =>
      _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/offer/get-all", HttpMethod.Get, null);


    [HttpGet("offer/get/{id}")]
    public Task<IActionResult> GetByIdOffer(int id) =>
    _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/offer/get/{id}", HttpMethod.Get, null);


    [HttpPost("offer/create")]
    public Task<IActionResult> CreateOffer([FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/offer/create", HttpMethod.Post, request);

    [HttpPut("offer/update/{id}")]
    public Task<IActionResult> UpdateOffer(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/offer/update/{id}", HttpMethod.Put, request);


    [HttpDelete("offer/del/{id}")]
    public Task<IActionResult> DeleteOffer(int id) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/offer/del/{id}", HttpMethod.Delete, null);


    [HttpGet("offer/by-mainparams")]
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




    // =======================================================================
    //                              ORDER API SERVICE
    //========================================================================



    [HttpGet("order/get-all")]
    public Task<IActionResult> GetAllOrder() =>
      _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/order/get-all", HttpMethod.Get, null);


    [HttpGet("order/get/{id}")]
    public Task<IActionResult> GetByIdOrder(int id) =>
    _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/order/get/{id}", HttpMethod.Get, null);


    [HttpPost("order/create")]
    public Task<IActionResult> CreateOrder([FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/order/create", HttpMethod.Post, request);

    [HttpPut("order/update/{id}")]
    public Task<IActionResult> UpdateOrder(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("OfferApiService", $"/api/order/update/{id}", HttpMethod.Put, request);


    [HttpDelete("order/del/{id}")]
    public Task<IActionResult> DeleteOrder(int id) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/order/del/{id}", HttpMethod.Delete, null);



}

