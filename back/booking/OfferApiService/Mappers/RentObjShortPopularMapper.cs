using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;
using OfferContracts;
using OfferContracts.RentObj;

namespace OfferApiService.Mappers
{
    public static class RentObjShortPopularMapper
    {
        public static RentObjShortPopularResponse MapToResponse( RentObject model, string baseUrl)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var firstImage = model.Images?.FirstOrDefault();

            return new RentObjShortPopularResponse
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
