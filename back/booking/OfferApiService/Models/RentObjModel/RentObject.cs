using Globals.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using OfferApiService.Models.RentObjModel.Enums;

namespace OfferApiService.Models.RentObjModel
{
    public class RentObject : EntityBase
    {
        
        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        //=====расположение==================
        public int CountryId { get; set; }
        public int DistrictId { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }


        //  Адрес для геокодинга

        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Postcode { get; set; }

        /// Координаты для карты
        public double Latitude { get; set; }
        public double Longitude { get; set; }



        //=====Основная информация==================
        public int? DistanceToCenter { get; set; } // расстояние до центра


        // === Основные характеристики объекта  ===
        public int RoomCount { get; set; }              //Количество комнат
        public int LivingRoomCount { get; set; }         // Количество гостиных
        public int BathroomCount { get; set; }          //Количество ванных комнат


        public double Area { get; set; }                //Площадь объекта (кв. м)

        
        // === Спальные места ===
        public int TotalBedsCount { get; set; }       //Общее количество спальных мест
        public int SingleBedsCount { get; set; }      // Количество односпальных кроватей
        public int DoubleBedsCount { get; set; }      // Количество двуспальных кроватей
        public bool HasBabyCrib { get; set; }         // Детская кроватка


 
        public List<RentObjParamValue> ParamValues { get; set; } = new();  // Параметры квартиры (список всех параметров квартиры, выбранных из справочника ParamItem)

        public List<RentObjImage> Images { get; set; } 
    }
}
