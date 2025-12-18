namespace OfferApiService.Models
{
    public class OfferOrderLink
    {
        public int Id { get; set; }
        public int OfferId { get; set; }
        public int OrderId { get; set; }

        public Offer Offer { get; set; }
    }
}
