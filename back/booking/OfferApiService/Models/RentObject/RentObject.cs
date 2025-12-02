using Globals.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using OfferApiService.Models.RentObject.Enums;

namespace OfferApiService.Models.RentObject
{
    public class RentObject : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public string Address { get; set; }


        // === Основные характеристики объекта  ===
        public int RoomCount { get; set; }              //Количество комнат

        public int BathroomCount { get; set; }          //Количество ванных комнат

        public double Area { get; set; }                //Площадь объекта (кв. м)

        public int Floor { get; set; }                  // Этаж, на котором находится жилье 

        public int TotalFloors { get; set; }           // Общее количество этажей в здании
        public RentObjType RentObjType { get; set; }   //Тип жилья


        /// Координаты для карты
        public double Latitude { get; set; }
        public double Longitude { get; set; }


        // === Спальные места ===
        public int BedroomsCount { get; set; }        //Количество спальных мест
        public int BedsCount { get; set; }            //Количество кроватей
        public bool HasBabyCrib { get; set; }         // Детская кроватка


 
        public List<RentObjParamValue> ParamValues { get; set; } = new();  // Параметры квартиры (список всех параметров квартиры, выбранных из справочника ParamItem)

        public string? MainImageUrl { get; set; }

        public List<RentObjImage> Images { get; set; } // Изображения объекта
    }
}
