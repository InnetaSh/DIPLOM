using Globals.Models;

namespace OfferApiService.Models.RentObjModel
{
    public class RentObjImage : EntityBase
    {
        public string Url { get; set; }
        public int RentObjId { get; set; }
        public RentObject RentObj { get; set; }
    }
}
