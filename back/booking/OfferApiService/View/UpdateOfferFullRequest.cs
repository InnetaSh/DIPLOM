
using OfferApiService.View.RentObj;

namespace OfferApiService.View
{
    public class UpdateOfferFullRequest
    {
        public OfferRequest Offer { get; set; }
        public RentObjRequest RentObj { get; set; }
    }
}
