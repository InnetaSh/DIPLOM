using Globals.Models;
using OfferApiService.Models;

namespace OfferApiService.View
{
    public class OfferResponse : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal PricePerDay { get; set; }

        public int OwnerId { get; set; }
        public int RentObjId { get; set; }

        public List<BookedDate> BookedDates { get; set; }
    }

}
