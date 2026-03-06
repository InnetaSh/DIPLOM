using OfferApiService.Models;
using OfferContracts;

namespace OfferApiService.Mappers
{
    public static class OfferShortPopularMapper
    {
        public static OfferShortPopularResponse MapToResponse(  Offer model, string baseUrl)
        {

            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var firstImage = model.RentObj.Images?.FirstOrDefault();

            return new OfferShortPopularResponse
            {
                id = model.id,

                RentObj = RentObjShortPopularMapper.MapToResponse(model.RentObj, baseUrl),
            };
        }

    }
}
