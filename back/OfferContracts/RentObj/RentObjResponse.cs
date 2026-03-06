using Globals.Controllers;

namespace OfferContracts.RentObj
{
    public class RentObjResponse : IBaseResponse
    {
        public int id { get; set; }
        public int OfferId { get; set; }
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

    }
}
