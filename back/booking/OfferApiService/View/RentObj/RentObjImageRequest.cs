using Globals.Controllers;
using OfferApiService.Models.RentObjModel;

namespace OfferApiService.View.RentObj
{
    public class RentObjImageRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Url { get; set; }
        public int RentObjId { get; set; }

        public static RentObjImage MapToModel(RentObjImageRequest request)
        {
            return new RentObjImage
            {
                id = request.id,
                Url = request.Url,
                RentObjId = request.RentObjId
               
            };
        }
    }
}
