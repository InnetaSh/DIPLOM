
using OfferApiService.View.RentObj;

namespace OfferApiService.View
{
    public class CreateOfferFullRequest
    {
        public OfferRequest Offer { get; set; }
        public RentObjRequest RentObj { get; set; }
    }
}
