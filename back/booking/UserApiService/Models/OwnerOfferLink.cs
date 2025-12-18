namespace UserApiService.Models
{
    public class OwnerOfferLink
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int OfferId { get; set; }

        public Owner Owner { get; set; }
    }
}
