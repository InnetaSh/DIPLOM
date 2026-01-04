using UserApiService.Models;

namespace UserApiService.View
{
    public class OwnerResponse
    {

        public int id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public int CountryId { get; set; }
        public string? CountryTitle { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string? Token { get; set; }
        public decimal Discount { get; set; }

        // ===== Collections =====
        public List<OwnerOfferResponse> OwnerOfferLinks { get; set; } = new();
    }
}
