namespace UserApiService.Models
{
    public class HistoryOfferLink
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int OfferId { get; set; }

        public Client Client { get; set; }

        public bool IsFavorites { get; set; } = false;
    }
}
