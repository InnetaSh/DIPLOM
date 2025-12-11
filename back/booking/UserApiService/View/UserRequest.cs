using Globals.Controllers;
using UserApiService.Models;
using UserApiService.Models.Enums;

namespace UserApiService.View
{
  
    public class UserRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int CountryId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string? Token { get; set; }



        public static User MapToModel(UserRequest request)
        {
            

            return new User
            {
                id = request.id,
                Username = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                CountryId = request.CountryId,
                RoleName = Enum.TryParse<UserRole>(request.RoleName, true, out var role)
                    ? role
                    : UserRole.Client
            };
        }
    }

 
}
