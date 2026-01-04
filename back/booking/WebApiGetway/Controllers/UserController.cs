using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiGetway.Service.Interfase;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IGatewayService _gateway;

    public UserController(IGatewayService gateway)
    {
        _gateway = gateway;
    }

    [HttpGet("get-all")]
    public Task<IActionResult> GetAll() =>
        _gateway.ForwardRequestAsync<object>("UserApiService", "/api/user/get-all", HttpMethod.Get, null);

    [HttpGet("get/{id}")]
    public Task<IActionResult> GetById(int id) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/user/get/{id}", HttpMethod.Get, null);

    [HttpGet("me")]
    [Authorize]
    public Task<IActionResult> GetMy(int id) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/user/me", HttpMethod.Get, null);


    [HttpPost("login")]
    public Task<IActionResult> Login([FromBody] object request) =>
        _gateway.ForwardRequestAsync("UserApiService", "/api/auth/login", HttpMethod.Post, request);

    [HttpPost("register")]
    public Task<IActionResult> Register([FromBody] object request) =>
        _gateway.ForwardRequestAsync("UserApiService", "/api/auth/register", HttpMethod.Post, request);


    //===========================================================================================
   
    
    [HttpPut("me/update")]
    [Authorize]
    public Task<IActionResult> Update( [FromBody] object request) =>
        _gateway.ForwardRequestAsync("UserApiService", $"/api/user/update", HttpMethod.Put, request);

    [HttpPut("me/change-password")]
    [Authorize]
    public Task<IActionResult> ChangePassword( [FromBody] object request) =>
       _gateway.ForwardRequestAsync("UserApiService", $"/api/user/me/change-password", HttpMethod.Put, request);

    [HttpPut("me/change-email")]
    [Authorize]
    public Task<IActionResult> ChangeEmail([FromBody] object request) =>
    _gateway.ForwardRequestAsync("UserApiService", $"/api/user/me/me/change-email", HttpMethod.Put, request);
    
    
    //===========================================================================================

    [HttpDelete("delete/me")]
    [Authorize]
    public Task<IActionResult> Delete(int id) =>
        _gateway.ForwardRequestAsync<object>("UserApiService", $"/api/auth/delete/{id}", HttpMethod.Delete, null);
}
