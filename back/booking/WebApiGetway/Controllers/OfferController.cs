using Microsoft.AspNetCore.Mvc;
using WebApiGetway.Service.Interfase;

[ApiController]
[Route("[controller]")]
public class OfferController : ControllerBase
{
    private readonly IGatewayService _gateway;

    public OfferController(IGatewayService gateway)
    {
        _gateway = gateway;
    }




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

}
