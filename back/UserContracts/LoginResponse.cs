using Globals.Controllers;

namespace UserContracts
{
    public class LoginResponse : IBaseResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string RoleName { get; set; }
        public decimal Discount { get; set; }
    }
}
