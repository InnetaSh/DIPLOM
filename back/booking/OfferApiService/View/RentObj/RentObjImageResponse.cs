using Globals.Controllers;
using OfferApiService.Models.RentObjModel;

namespace OfferApiService.View.RentObj
{
    public class RentObjImageResponse : IBaseResponse
    {
        public int id { get; set; }
        public string Url { get; set; }
        public int RentObjId { get; set; }

        public static RentObjImageResponse MapToResponse(RentObjImage model, string baseUrl)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            return new RentObjImageResponse
            {
                id = model.id,
                Url = $"{baseUrl}{model.Url}",
                RentObjId = model.RentObjId
            };
        }


    }
}
