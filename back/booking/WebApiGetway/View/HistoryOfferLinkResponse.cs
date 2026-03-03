namespace WebApiGetway.View
{
    public class HistoryOfferLinkResponse
    {

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int OfferId { get; set; }

        public bool IsFavorites { get; set; } = false;
        public string Title { get; set; }
        public string? MainImageUrl { get; set; }
    }
}
