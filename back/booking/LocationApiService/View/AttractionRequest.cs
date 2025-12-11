

using Globals.Controllers;
using LocationApiService.Models;

namespace LocationApiService.View
{
    public class AttractionRequest : IBaseRequest
    {
        public int id { get; set; }
        public int CountryId { get; set; }
        public int DistrictId { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }



        public static Attraction MapToModel(AttractionRequest request)
        {
            return new Attraction
            {
                id = request.id,
                CountryId = request.CountryId,
                DistrictId = request.DistrictId,
                RegionId = request.RegionId,
                CityId = request.CityId,

                Latitude = request.Latitude,
                Longitude = request.Longitude
            };
        }
    }
}
