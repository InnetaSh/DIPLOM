using Globals.Models;

namespace OfferApiService.View
{
    public class BookedDateRequest : EntityBase
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int OfferId { get; set; }
    }
}
