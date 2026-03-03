using Globals.Controllers;
using Globals.Models;
using UserApiService.Models;

namespace UserApiService.View
{
    public class UserResponse : IBaseResponse
    {
        public int id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? Lastname { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public int CountryId { get; set; }
        public string? CountryTitle { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string? Token { get; set; }
        public decimal Discount { get; set; }

        public bool IsBlocked { get; set; } = false;
        public static UserResponse MapToResponse(User model)
        {
            return new UserResponse
            {
                id = model.id,
                Username = model.Username ?? string.Empty,
                Lastname = model.Lastname ?? string.Empty,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                BirthDate = model.BirthDate,
                CountryId = model.CountryId,
                Discount = model.Discount,
                RoleName = model.RoleName.ToString(),
                IsBlocked = model.IsBlocked,
            };
        }
    }
}
