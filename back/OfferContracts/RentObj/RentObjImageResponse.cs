using Globals.Controllers;

namespace OfferContracts.RentObj
{
    public class RentObjImageResponse : IBaseResponse
    {
        public int id { get; set; }
        public string Url { get; set; }
        public int RentObjId { get; set; }
    }
}
