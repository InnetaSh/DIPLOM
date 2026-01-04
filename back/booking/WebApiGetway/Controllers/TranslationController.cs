using Microsoft.AspNetCore.Mvc;
using WebApiGetway.Service.Interfase;

[ApiController]
[Route("[controller]")]
public class TranslationController : ControllerBase
{
    private readonly IGatewayService _gateway;

    public TranslationController(IGatewayService gateway)
    {
        _gateway = gateway;
    }




    // ---Attraction---

    [HttpGet("attraction/get-all-translations/{lang}")]
    public Task<IActionResult> GetAllAttraction(string lang) =>
      _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/attraction/get-all-translations/{lang}", HttpMethod.Get, null);


    [HttpGet("attraction/get-translations/{id}")]
    public Task<IActionResult> GetByIdAttraction(int id) =>
    _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/attraction/get-translations/{id}", HttpMethod.Get, null);


    [HttpPost("attraction/create-translations")]
    public Task<IActionResult> CreateAttraction([FromBody] object request) =>
      _gateway.ForwardRequestAsync("TranslationApiService", $"/api/attraction/create-translations", HttpMethod.Post, request);

    [HttpPut("attraction/update-translations/{id}")]
    public Task<IActionResult> UpdateAttraction(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("TranslationApiService", $"/api/attraction/update-translations/{id}", HttpMethod.Put, request);


    [HttpDelete("attraction/del-translations/{id}")]
    public Task<IActionResult> DeletelAttraction(int id) =>
        _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/attraction/del-translations/{id}", HttpMethod.Delete, null);




    // ---city---

    [HttpGet("city/get-all-translations/{lang}")]
    public Task<IActionResult> GetAllCity(string lang) =>
      _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/city/get-all-translations/{lang}", HttpMethod.Get, null);


    [HttpGet("city/get-translations/{id}")]
    public Task<IActionResult> GetByIdCity(int id) =>
    _gateway.ForwardRequestAsync<object>("`TranslationApiService", $"/api/city/get-translations/{id}", HttpMethod.Get, null);


    [HttpPost("city/create-translations")]
    public Task<IActionResult> CreateCity([FromBody] object request) =>
      _gateway.ForwardRequestAsync("TranslationApiService", $"/api/city/create-translations", HttpMethod.Post, request);

    [HttpPut("city/update-translations/{id}")]
    public Task<IActionResult> UpdateCity(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("TranslationApiService", $"/api/city/update-translations/{id}", HttpMethod.Put, request);


    [HttpDelete("city/del-translations/{id}")]
    public Task<IActionResult> DeletelCity(int id) =>
        _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/city/del-translations/{id}", HttpMethod.Delete, null);




    // ---region---

    [HttpGet("region/get-all-translations/{lang}")]
    public Task<IActionResult> GetAllRegion(string lang) =>
      _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/region/get-all-translations/{lang}", HttpMethod.Get, null);


    [HttpGet("region/get-translations/{id}")]
    public Task<IActionResult> GetByIdRegion(int id,string lang) =>
    _gateway.ForwardRequestAsync<object>("AttractionApTranslationApiServiceiService", $"/api/region/get-translations/{id}/{lang}", HttpMethod.Get, null);


    [HttpPost("region/create-translations")]
    public Task<IActionResult> CreateRegion([FromBody] object request) =>
      _gateway.ForwardRequestAsync("TranslationApiService", $"/api/region/create-translations", HttpMethod.Post, request);

    [HttpPut("region/update-translations/{id}")]
    public Task<IActionResult> UpdateRegion(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("TranslationApiService", $"/api/region/update-translations/{id}", HttpMethod.Put, request);


    [HttpDelete("region/del-translations/{id}")]
    public Task<IActionResult> DeletelRegion(int id) =>
        _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/region/del-translations/{id}", HttpMethod.Delete, null);



    // ---country---

    [HttpGet("country/get-all-translations/{lang}")]
    public Task<IActionResult> GetAllCountry(string lang) =>
      _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/country/get-all-translations/{lang}", HttpMethod.Get, null);


    [HttpGet("country/get-translations/{id}/{lang}")]
    public Task<IActionResult> GetByIdCountry(int id,string lang) =>
    _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/country/get-translations/{id}/{lang}", HttpMethod.Get, null);


    [HttpPost("country/create-translations")]
    public Task<IActionResult> CreateCountry([FromBody] object request) =>
      _gateway.ForwardRequestAsync("TranslationApiService", $"/api/country/create-translations", HttpMethod.Post, request);

    [HttpPut("country/update-translations/{id}")]
    public Task<IActionResult> UpdateCountry(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("TranslationApiService", $"/api/country/update-translations/{id}", HttpMethod.Put, request);


    [HttpDelete("country/del-translations/{id}")]
    public Task<IActionResult> DeletelCountry(int id) =>
        _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/country/del-translations/{id}", HttpMethod.Delete, null);





    // ---district---

    [HttpGet("district/get-all-translations/{lang}")]
    public Task<IActionResult> GetAllDistrict(string lang) =>
      _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/district/get-all-translations/{lang}", HttpMethod.Get, null);


    [HttpGet("district/get-translations/{id}")]
    public Task<IActionResult> GetByIdDistrict(int id) =>
    _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/district/get-translations/{id}", HttpMethod.Get, null);


    [HttpPost("district/create-translations")]
    public Task<IActionResult> CreateDistrict([FromBody] object request) =>
      _gateway.ForwardRequestAsync("TranslationApiService", $"/api/district/create-translations", HttpMethod.Post, request);

    [HttpPut("district/update-translations/{id}")]
    public Task<IActionResult> UpdateDistrict(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("AttractionApiService", $"/api/district/update-translations/{id}", HttpMethod.Put, request);


    [HttpDelete("district/del-translations/{id}")]
    public Task<IActionResult> DeletelDistrict(int id) =>
        _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/district/del-translations/{id}", HttpMethod.Delete, null);




    // ---offer---

    [HttpGet("offer/get-all-translations/{lang}")]
    public Task<IActionResult> GetAllOffer(string lang) =>
      _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/offer/get-all-translations/{lang}", HttpMethod.Get, null);


    [HttpGet("offer/get-translations/{id}")]
    public Task<IActionResult> GetByIdOffer(int id) =>
    _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/offer/get-translations/{id}", HttpMethod.Get, null);


    [HttpPost("offer/create-translations")]
    public Task<IActionResult> CreateOffer([FromBody] object request) =>
      _gateway.ForwardRequestAsync("TranslationApiService", $"/api/offer/create-translations", HttpMethod.Post, request);

    [HttpPut("offer/update-translations/{id}")]
    public Task<IActionResult> UpdateOffer(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("AttractionApiService", $"/api/offer/update-translations/{id}", HttpMethod.Put, request);


    [HttpDelete("offer/del-translations/{id}")]
    public Task<IActionResult> DeletelOffer(int id) =>
        _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/district/del-translations/{id}", HttpMethod.Delete, null);




    // ---paramItem---

    [HttpGet("paramitem/get-all-translations/{lang}")]
    public Task<IActionResult> GetAllParamItem(string lang) =>
      _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/paramitem/get-all-translations/{lang}", HttpMethod.Get, null);


    [HttpGet("paramitem/get-translations/{id}")]
    public Task<IActionResult> GetByIdParamItem(int id) =>
    _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/paramitem/get-translations/{id}", HttpMethod.Get, null);


    [HttpPost("paramitem/create-translations")]
    public Task<IActionResult> CreateParamItem([FromBody] object request) =>
      _gateway.ForwardRequestAsync("TranslationApiService", $"/api/paramitem/create-translations", HttpMethod.Post, request);

    [HttpPut("paramitem/update-translations/{id}")]
    public Task<IActionResult> UpdateParamItem(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("AttractionApiService", $"/api/paramitem/update-translations/{id}", HttpMethod.Put, request);


    [HttpDelete("paramitem/del-translations/{id}")]
    public Task<IActionResult> DeletelParamItem(int id) =>
        _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/paramitem/del-translations/{id}", HttpMethod.Delete, null);

   
    
    
    // ---paramscategory---

    [HttpGet("paramscategory/get-all-translations/{lang}")]
    public Task<IActionResult> GetAllParamscategory(string lang) =>
      _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/paramscategory/get-all-translations/{lang}", HttpMethod.Get, null);


    [HttpGet("paramscategory/get-translations/{id}")]
    public Task<IActionResult> GetByIdaramscategory(int id) =>
    _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/paramscategory/get-translations/{id}", HttpMethod.Get, null);


    [HttpPost("paramscategory/create-translations")]
    public Task<IActionResult> CreateParamscategory([FromBody] object request) =>
      _gateway.ForwardRequestAsync("TranslationApiService", $"/api/paramscategory/create-translations", HttpMethod.Post, request);

    [HttpPut("paramscategory/update-translations/{id}")]
    public Task<IActionResult> UpdateParamscategory(int id, [FromBody] object request) =>
      _gateway.ForwardRequestAsync("AttractionApiService", $"/api/paramscategory/update-translations/{id}", HttpMethod.Put, request);


    [HttpDelete("paramscategory/del-translations/{id}")]
    public Task<IActionResult> DeletelParamscategory(int id) =>
        _gateway.ForwardRequestAsync<object>("TranslationApiService", $"/api/paramscategory/del-translations/{id}", HttpMethod.Delete, null);

}
