using Globals.Controllers;
using System.Linq;


namespace WebApiGetway.View
{
    public class RentObjRequest : IBaseRequest
    {
        public int? id { get; set; }
        public int? OfferId { get; set; }
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


        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Postcode { get; set; }
    


        // public double? Latitude { get; set; }
        //public double? Longitude { get; set; }

        public int RoomCount { get; set; }           //Количество комнат
        public int LivingRoomCount { get; set; }     // Количество гостиных
        public int BathroomCount { get; set; }        //Количество ванных комнат


        public double Area { get; set; }                 //Площадь объекта (кв. м)

        public int TotalBedsCount { get; set; }         //Общее количество спальных мест
        public int SingleBedsCount { get; set; }      // Количество односпальных кроватей
        public int DoubleBedsCount { get; set; }      // Количество двуспальных кроватей
        public bool HasBabyCrib { get; set; }         // Детская кроватка

        public List<RentObjParamValueRequest> ParamValues { get; set; } = new();
        public List<ImageRequest> Images { get; set; } = new();

      

    }
}
