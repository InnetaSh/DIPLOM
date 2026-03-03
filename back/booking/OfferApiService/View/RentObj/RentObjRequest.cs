using Globals.Controllers;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Models.RentObjModel.Enums;
using System.Linq;

namespace OfferApiService.View.RentObj
{
    public class RentObjRequest : IBaseRequest
    {
        public int id { get; set; }
        public int OfferId { get; set; }
        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }

        //public string Address { get; set; }


        //  Адрес для геокодинга

        public string? CountryTitle { get; set; }
        public string? CityTitle { get; set; }
        public double? CityLatitude { get; set; }
        public double? CityLongitude { get; set; }


        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Street { get; set; }        
        public string HouseNumber { get; set; }  
        public string Postcode { get; set; }

        public int? DistanceToCenter { get; set; } // расстояние до центра

        //=====Основная информация==================

        public int RoomCount { get; set; }           //Количество комнат
        public int LivingRoomCount { get; set; }     // Количество гостиных
        public int BathroomCount { get; set; }        //Количество ванных комнат
      

        public double Area { get; set; }                 //Площадь объекта (кв. м)
       

        public int TotalBedsCount { get; set; }         //Общее количество спальных мест
        public int SingleBedsCount { get; set; }      // Количество односпальных кроватей
        public int DoubleBedsCount { get; set; }      // Количество двуспальных кроватей
        public bool HasBabyCrib { get; set; }         // Детская кроватка

        public List<RentObjParamValueRequest> ParamValues { get; set; } = new();
        public List<RentObjImageRequest> Images { get; set; } = new();

        public static RentObject MapToModel(
             RentObjRequest request
         )
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
                    .Select(RentObjParamValueRequest.MapToModel)
                    .ToList() ?? new List<RentObjParamValue>(),
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


    }
}
