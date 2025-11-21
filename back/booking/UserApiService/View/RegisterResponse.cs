using Globals.Controllers;

namespace UserApiService.View
{
    public class RegisterResponse : IBaseResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string RoleName { get; set; }
    }
}
