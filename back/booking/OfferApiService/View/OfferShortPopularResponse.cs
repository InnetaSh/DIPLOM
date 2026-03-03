using Globals.Controllers;
using OfferApiService.View.RentObj;

namespace OfferApiService.Models.View
{
    public class OfferShortPopularResponse : IBaseResponse
    {
        public int id { get; set; }

        public string? Title { get; set; } 
      
        public RentObjShortPopularResponse RentObj { get; set; }
        public double? OverallRating { get; set; }


        public static OfferShortPopularResponse MapToResponse(Offer model, string baseUrl)
        {
            var firstImage = model.RentObj.Images?.FirstOrDefault();

            return new OfferShortPopularResponse
            {
                id = model.id,
               
                RentObj = model.RentObj != null
                    ? RentObjShortPopularResponse.MapToResponse(model.RentObj, baseUrl)
                    : null,
            };
        }

    }
}
