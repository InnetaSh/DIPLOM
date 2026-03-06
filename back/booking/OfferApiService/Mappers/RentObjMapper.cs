using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;
using OfferContracts;
using OfferContracts.RentObj;

namespace OfferApiService.Mappers
{
    public static class RentObjMapper
    {
        public static RentObject MapToModel(  RentObjRequest request)
        {
            return new RentObject
            {
                id = request.id,
                OfferId = request.OfferId,
                CountryId = request.CountryId,
                RegionId = request.RegionId,
                CityId = request.CityId,
                DistrictId = request.DistrictId,
                Street = request.Street,
                HouseNumber = request.HouseNumber,
                Postcode = request.Postcode,
                DistanceToCenter = request.DistanceToCenter,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                RoomCount = request.RoomCount,
                LivingRoomCount = request.LivingRoomCount,
                BathroomCount = request.BathroomCount,
                Area = request.Area,
                TotalBedsCount = request.TotalBedsCount,
                SingleBedsCount = request.SingleBedsCount,
                DoubleBedsCount = request.DoubleBedsCount,
                HasBabyCrib = request.HasBabyCrib,
                ParamValues = request.ParamValues?
                    .Select(x => RentObjParamValueMapper.MapToModel(x))
                    ?.ToList() ?? new List<RentObjParamValue>(),
                Images = request.Images?
                    .Select(img => new RentObjImage
                    {
                        id = img.id,
                        Url = img.Url,
                        RentObjId = img.RentObjId
                    })
                    .ToList() ?? new List<RentObjImage>()
            };
        }

        public static RentObjResponse MapToResponse( RentObject model, string baseUrl)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            return new RentObjResponse
            {
                id = model.id,
                OfferId = model.OfferId,
                CountryId = model.CountryId,
                RegionId = model.RegionId,
                CityId = model.CityId,
                DistrictId = model.DistrictId,
                Street = model.Street,
                HouseNumber = model.HouseNumber,
                Postcode = model.Postcode,

                RoomCount = model.RoomCount,
                LivingRoomCount = model.LivingRoomCount,
                BathroomCount = model.BathroomCount,

                Area = model.Area,

                Latitude = model.Latitude,
                Longitude = model.Longitude,

                TotalBedsCount = model.TotalBedsCount,
                SingleBedsCount = model.SingleBedsCount,
                DoubleBedsCount = model.DoubleBedsCount,
                HasBabyCrib = model.HasBabyCrib,

                ParamValues = model.ParamValues?
                     .Select(x => RentObjParamValueMapper.MapToResponse(x))
                    ?.ToList() ?? new List<RentObjParamValueResponse>(),


                Images = model.Images?.Select(x => RentObjImageMapper.MapToResponse(x,baseUrl))?.ToList()
                     ?? new List<RentObjImageResponse>(),
            };
        }
    }
}
