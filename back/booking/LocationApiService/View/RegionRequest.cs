using Globals.Controllers;
using LocationApiService.Models;
using System.Linq;

namespace LocationApiService.View
{
    public class RegionRequest : IBaseRequest
    {
        public int id { get; set; }
        public int CountryId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public List<CityRequest> Cities { get; set; } = new();

        public static Region MapToModel(RegionRequest request)
        {
            return new Region
            {
                id = request.id,
                CountryId = request.CountryId, 
                Latitude = request.Latitude,
                Longitude = request.Longitude,

                Cities = request.Cities?
                    .Select(cityReq => CityRequest.MapToModel(cityReq))
                    .ToList() ?? new List<City>()
            };
        }
    }
}
