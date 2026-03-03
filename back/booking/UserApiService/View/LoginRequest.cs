using Globals.Controllers;

namespace UserApiService.View
{
    public class LoginRequest : IBaseRequest
    {
        public string Login { get; set; }   // email или телефон
        public string Password { get; set; }
    }
}
