using UserApiService.Models;

namespace UserApiService.View
{
    public class HistoryOfferResponse
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int OfferId { get; set; }

        public bool IsFavorites { get; set; } = false;
    }
}
