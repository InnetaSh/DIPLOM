using Globals.Models;

namespace OfferApiService.View
{
    public class OfferRequest : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal PricePerDay { get; set; }

        public int OwnerId { get; set; }
        public int RentObjId { get; set; }
    }

}
