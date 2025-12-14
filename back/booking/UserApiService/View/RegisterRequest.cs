using Globals.Controllers;

namespace UserApiService.View
{
    public class RegisterRequest : IBaseRequest
    {

        public string? Username { get; set; }

        public string Password { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int CountryId { get; set; }
        public string? RoleName { get; set; } = "Client";
    }
}
