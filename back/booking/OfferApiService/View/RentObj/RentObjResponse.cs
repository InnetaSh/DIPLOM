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


        //  Адрес для геокодинга

        public string CountryTitle { get; set; }
        public string CityTitle { get; set; }

        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Postcode { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public int? DistanceToCenter { get; set; } // расстояние до центра

        // основная информация

        public int RoomCount { get; set; }              //Количество комнат
        public int LivingRoomCount { get; set; }         // Количество гостиных
        public int BathroomCount { get; set; }          //Количество ванных комнат
       
        public double Area { get; set; }               //Площадь объекта (кв. м)


        public int TotalBedsCount { get; set; }       //Общее количество спальных мест
        public int SingleBedsCount { get; set; }      // Количество односпальных кроватей
        public int DoubleBedsCount { get; set; }      // Количество двуспальных кроватей
        public bool HasBabyCrib { get; set; }         // Детская кроватка

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
                    .Select(RentObjParamValueResponse.MapToResponse)
                    .ToList() ?? new List<RentObjParamValueResponse>(),


                Images = model.Images?.Select(img => RentObjImageResponse.MapToResponse(img, baseUrl)).ToList()
                     ?? new List<RentObjImageResponse>(),

               
            };
        }
    }
}
