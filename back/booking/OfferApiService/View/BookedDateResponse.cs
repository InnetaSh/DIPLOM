using Globals.Models;

namespace OfferApiService.View
{
    public class BookedDateResponse : EntityBase
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int OfferId { get; set; }
    }
}
