using Globals.Controllers;


namespace UserContracts
{
  
    public class UserRequest : IBaseRequest
    {
        public string Username { get; set; } = string.Empty;
        public string? Lastname { get; set; }
        public string Password { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public int CountryId { get; set; }
        public decimal Discount { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string? Token { get; set; }

        public bool IsBlocked { get; set; } = false;

    }
}
