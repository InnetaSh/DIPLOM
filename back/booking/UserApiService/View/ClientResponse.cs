namespace UserApiService.View
{
    public class ClientResponse
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
        public List<ClientOrderResponse> ClientOrderLinks { get; set; } = new();
        public List<HistoryOfferResponse> HistoryOfferLinks { get; set; } = new();
    }
}
