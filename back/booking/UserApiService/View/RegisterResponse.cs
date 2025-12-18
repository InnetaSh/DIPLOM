using Globals.Controllers;

namespace UserApiService.View
{
    public class RegisterResponse : IBaseResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public decimal Discount { get; set; }
        public string RoleName { get; set; }
    }
}
