using Globals.Controllers;
using OfferApiService.Models;
using OfferApiService.Models.RentObjModel.Enums;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using OfferApiService.Models.RentObjModel;
using System.Globalization;

namespace OfferApiService.View.RentObj
{
    public class RentObjResponse : IBaseResponse
    {
        public int id { get; set; }

        public int CountryId { get; set; }
        public int DistrictId { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }

       
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

        public List<string> ImagesUrl {get; set;} = new List<string>();
        public List<RentObjParamValueResponse>? ParamValues { get; set; } = new();
        public List<RentObjImageResponse>? Images { get; set; } = new();

        public static RentObjResponse MapToResponse(RentObject model, string baseUrl)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            return new RentObjResponse
            {
                id = model.id,
                CountryId = model.CountryId,
                RegionId = model.RegionId,
                CityId = model.CityId,
                DistrictId = model.DistrictId,
                Address = model.Address,

                RoomCount = model.RoomCount,
                LivingRoomCount = model.LivingRoomCount,
                BathroomCount = model.BathroomCount,
                HasKitchen = model.HasKitchen,
                HasBalcony = model.HasBalcony,
                Area = model.Area,
                Floor = model.Floor,
                TotalFloors = model.TotalFloors,
                RentObjType = model.RentObjType,

                Latitude = model.Latitude,
                Longitude = model.Longitude,

                BedroomsCount = model.BedroomsCount,
                BedsCount = model.BedsCount,
                HasBabyCrib = model.HasBabyCrib,

                ParamValues = model.ParamValues?
                    .Select(RentObjParamValueResponse.MapToResponse)
                    .ToList() ?? new List<RentObjParamValueResponse>(),


                Images = model.Images?.Select(img => RentObjImageResponse.MapToResponse(img, baseUrl)).ToList()
                     ?? new List<RentObjImageResponse>(),

               
            };
        }
    }
}
