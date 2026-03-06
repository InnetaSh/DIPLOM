using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;
using OfferContracts;
using OfferContracts.RentObj;

namespace OfferApiService.Mappers
{
    public static class OfferShortMapper
    {
        public static OfferShortResponse MapToResponse(Offer model, string baseUrl)
        {

            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var firstImage = model.RentObj.Images?.FirstOrDefault();

            return new OfferShortResponse
            {
                id = model.id,
                Tax = model.Tax,
                PricePerDay = model.PricePerDay,
                PricePerWeek = model.PricePerWeek,
                PricePerMonth = model.PricePerMonth,

                RentObj = RentObjShortMapper.MapToResponse(model.RentObj,baseUrl),
            };
        }
    }
}
