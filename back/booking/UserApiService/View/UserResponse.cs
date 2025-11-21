using Globals.Controllers;
using Globals.Models;

namespace UserApiService.View
{
    public class UserResponse : IBaseResponse
    {
        public int id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
