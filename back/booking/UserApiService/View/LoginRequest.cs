using Globals.Controllers;

namespace UserApiService.View
{
    public class LoginRequest : IBaseRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
