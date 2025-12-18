using Globals.Controllers;

namespace UserApiService.View
{
    public class LoginResponse : IBaseResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string RoleName { get; set; }
        public decimal Discount { get; set; }
    }
}
