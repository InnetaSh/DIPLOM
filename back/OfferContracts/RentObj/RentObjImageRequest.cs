using Globals.Controllers;

namespace OfferContracts.RentObj
{
    public class RentObjImageRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Url { get; set; }
        public int RentObjId { get; set; }
    }
}
