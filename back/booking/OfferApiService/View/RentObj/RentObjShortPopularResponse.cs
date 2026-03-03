using Microsoft.Extensions.Localization;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Models.View;

namespace OfferApiService.View.RentObj
{
    public class RentObjShortPopularResponse
    {
        public int id { get; set; }
      
        public int CityId { get; set; }
        public string? CityTitle { get; set; }
        public string? MainImageUrl { get; set; }
       

        public static RentObjShortPopularResponse MapToResponse(RentObject model, string baseUrl)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var firstImage = model.Images?.FirstOrDefault();

            return  new RentObjShortPopularResponse
            {
                    id = model.id,
                    CityId = model.CityId,
                    MainImageUrl = firstImage != null
                        ? $"{baseUrl}/images/rentobj/{model.id}/{Path.GetFileName(firstImage.Url)}"
                        : null,
                   
            };
        }
    }
}
