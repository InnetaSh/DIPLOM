//using Microsoft.AspNetCore.Mvc;
//using WebApiGetway.Service.Interfase;

//[ApiController]
//[Route("[controller]")]
//public class UserController : ControllerBase
//{
//    private readonly IGatewayService _gateway;

//    public UserController(IGatewayService gateway)
//    {
//        _gateway = gateway;
//    }

//    [HttpGet("get-all")]
//    public Task<IActionResult> GetAll() =>
//        _gateway.ForwardRequestAsync<object>("OfferApiService", "/api/user/get-all", HttpMethod.Get, null);

//    [HttpGet("get/{id}")]
//    public Task<IActionResult> GetById(int id) =>
//        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/user/get/{id}", HttpMethod.Get, null);

//    [HttpPost("login")]
//    public Task<IActionResult> Login([FromBody] object request) =>
//        _gateway.ForwardRequestAsync("UserApiService", "/api/auth/login", HttpMethod.Post, request);

//    [HttpPost("register")]
//    public Task<IActionResult> Register([FromBody] object request) =>
//        _gateway.ForwardRequestAsync("UserApiService", "/api/auth/register", HttpMethod.Post, request);

//    [HttpPut("update/{id}")]
//    public Task<IActionResult> Update(int id, [FromBody] object request) =>
//        _gateway.ForwardRequestAsync("UserApiService", $"/api/auth/update/{id}", HttpMethod.Put, request);

//    [HttpDelete("delete/{id}")]
//    public Task<IActionResult> Delete(int id) =>
//        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/auth/delete/{id}", HttpMethod.Delete, null);
//}
