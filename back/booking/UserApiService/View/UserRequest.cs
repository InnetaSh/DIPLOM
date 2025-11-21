using Globals.Controllers;

namespace UserApiService.View
{
  
    public class UserRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }

 
}
