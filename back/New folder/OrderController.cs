//using Microsoft.AspNetCore.Mvc;
//using WebApiGetway.Service.Interfase;

//[ApiController]
//[Route("[controller]")]
//public class OrderController : ControllerBase
//{
//    private readonly IGatewayService _gateway;
//    public OrderController(IGatewayService gateway)
//    {
//        _gateway = gateway;
//    }

//    [HttpGet("get-all")]
//    public Task<IActionResult> GetAll() =>
//        _gateway.ForwardRequestAsync<object>("OfferApiService", "/api/order/get-all", HttpMethod.Get, null);

//    [HttpGet("get/{id}")]
//    public Task<IActionResult> GetById(int id) =>
//        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/order/get/{id}", HttpMethod.Get, null);

//    [HttpPost("create")]
//    public Task<IActionResult> Create([FromBody] object request) =>
//        _gateway.ForwardRequestAsync("OfferApiService", "/api/order/create", HttpMethod.Post, request);

//    [HttpPut("update/{id}")]
//    public Task<IActionResult> Update(int id, [FromBody] object request) =>
//        _gateway.ForwardRequestAsync("OfferApiService", $"/api/order/update/{id}", HttpMethod.Put, request);

//    [HttpDelete("del/{id}")]
//    public Task<IActionResult> Delete(int id) =>
//        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/order/del/{id}", HttpMethod.Delete, null);
//}
