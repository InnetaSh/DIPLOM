using Globals.Controllers;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Models.RentObjModel.Enums;
using System.Linq;

namespace OfferApiService.View.RentObj
{
    public class RentObjRequest : IBaseRequest
    {
        public int id { get; set; }

        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Address { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public int RoomCount { get; set; }
        public int LivingRoomCount { get; set; }   
        public int BathroomCount { get; set; }
        public bool HasKitchen { get; set; }         
        public bool HasBalcony { get; set; }
        public double Area { get; set; }
        public int Floor { get; set; }
        public int TotalFloors { get; set; }
        public RentObjType RentObjType { get; set; }

        public int BedroomsCount { get; set; }
        public int BedsCount { get; set; }
        public bool HasBabyCrib { get; set; }

        public List<RentObjParamValueRequest> ParamValues { get; set; } = new();
        public List<string> Images { get; set; } = new();

        public static RentObject MapToModel(RentObjRequest request)
        {
            return new RentObject
            {
                id = request.id,
                CountryId = request.CountryId,
                RegionId = request.RegionId,
                CityId = request.CityId,
                DistrictId = request.DistrictId,
                Address = request.Address,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                RoomCount = request.RoomCount,
                LivingRoomCount = request.LivingRoomCount,
                BathroomCount = request.BathroomCount,
                HasKitchen = request.HasKitchen,
                HasBalcony = request.HasBalcony,
                Area = request.Area,
                Floor = request.Floor,
                TotalFloors = request.TotalFloors,
                RentObjType = request.RentObjType,
                BedroomsCount = request.BedroomsCount,
                BedsCount = request.BedsCount,
                HasBabyCrib = request.HasBabyCrib,
                ParamValues = request.ParamValues?
                    .Select(RentObjParamValueRequest.MapToModel)
                    .ToList() ?? new List<RentObjParamValue>(),
                Images = request.Images?
                    .Select(url => new RentObjImage { Url = url })
                    .ToList() ?? new List<RentObjImage>()
            };
        }
    }
}
