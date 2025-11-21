using Globals.Models;

namespace OfferApiService.Models
{
    public class BookedDate : EntityBase
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }

    }
}
