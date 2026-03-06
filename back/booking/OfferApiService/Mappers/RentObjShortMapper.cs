using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;
using OfferContracts;
using OfferContracts.RentObj;

namespace OfferApiService.Mappers
{
    public static class RentObjShortMapper
    {
        public static RentObjShortResponse MapToResponse( RentObject model, string baseUrl)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var firstImage = model.Images?.FirstOrDefault();

            return new RentObjShortResponse
            {
                id = model.id,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                CityId = model.CityId,
                RoomCount = model.RoomCount,
                LivingRoomCount = model.LivingRoomCount,
                Area = model.Area,
                TotalBedsCount = model.TotalBedsCount,
                SingleBedsCount = model.SingleBedsCount,
                DoubleBedsCount = model.DoubleBedsCount,
                HasBabyCrib = model.HasBabyCrib,


                MainImageUrl = firstImage != null
                        ? $"{baseUrl}/images/rentobj/{model.id}/{Path.GetFileName(firstImage.Url)}"
                        : null,
                ParamValues = model.ParamValues?
                         .Select(x => RentObjParamValueMapper.MapToResponse(x))
                         ?.ToList() ?? new List<RentObjParamValueResponse>(),
            };
        }
    }
}
