

using Globals.Controllers;
using OfferApiService.Models.RentObject;

namespace OfferApiService.View.RentObject
{
    public class RentObjImageRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Url { get; set; }
        public int RentObjId { get; set; }
    }
}
