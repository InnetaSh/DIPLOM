using Globals.Controllers;
using OfferApiService.Models.RentObject.Enums;
using System.Collections.Generic;

namespace OfferApiService.View.RentObject
{
    public class RentObjResponse : IBaseResponse
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
        public string? CityTitle { get; set; }    
        public string Address { get; set; }


        public int RoomCount { get; set; }
        public int BathroomCount { get; set; }
        public double Area { get; set; }
        public int Floor { get; set; }
        public int TotalFloors { get; set; }
        public RentObjType RentObjType { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }


        public int BedroomsCount { get; set; }
        public int BedsCount { get; set; }
        public bool HasBabyCrib { get; set; }


        public List<ParamItemResponse> ParamItems { get; set; } = new();

        public List<string> Images { get; set; } = new();
    }
}
