using Globals.Controllers;
using OfferApiService.Models;
using OfferApiService.Models.RentObject.Enums;
using OfferApiService.Services.Interfaces.RentObject;
using System.Collections.Generic;

namespace OfferApiService.View.RentObject
{
    public class RentObjResponse : IBaseResponse
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int CountryId { get; set; }
        public int DistrictId { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }



        public int RoomCount { get; set; }
        public int BathroomCount { get; set; }
        public double Area { get; set; }
        public int Floor { get; set; }
        public int TotalFloors { get; set; }
        public RentObjType RentObjType { get; set; }

      
        public int BedroomsCount { get; set; }
        public int BedsCount { get; set; }
        public bool HasBabyCrib { get; set; }


        public List<RentObjParamValueResponse>? ParamValues { get; set; } = new();
        public List<string>? Images { get; set; } = new();

       public static RentObjResponse MapToResponse(Models.RentObject.RentObject model, IRentObjParamValueService paramValueService, string baseUrl)
        {
            return new RentObjResponse
            {
                id = model.id,
                Title = model.Title,
                Description = model.Description,
                CountryId = model.CountryId,
                RegionId = model.RegionId,
                CityId = model.CityId,
                DistrictId = model.DistrictId,
                Address = model.Address,

                RoomCount = model.RoomCount,
                BathroomCount = model.BathroomCount,
                Area = model.Area,
                Floor = model.Floor,
                TotalFloors = model.TotalFloors,
                RentObjType = model.RentObjType,

                Latitude = model.Latitude,
                Longitude = model.Longitude,

                BedroomsCount = model.BedroomsCount,
                BedsCount = model.BedsCount,
                HasBabyCrib = model.HasBabyCrib,

                ParamValues = model.ParamValues?.Select(x => RentObjParamValueResponse.MapToResponse(x, paramValueService))?.ToList() ?? new List<RentObjParamValueResponse>(),


                Images = model.Images
                        ?.Select(i => $"{baseUrl}/images/rentobj/{model.id}/{Path.GetFileName(i.Url)}")
                        .ToList() ?? new List<string>(),
            };
        }
    }
}
