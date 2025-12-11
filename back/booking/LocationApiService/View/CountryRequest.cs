using Globals.Controllers;
using LocationApiService.Models;
using System.Linq;

namespace LocationApiService.View
{
    public class CountryRequest : IBaseRequest
    {
        public int id { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public List<RegionRequest> Regions { get; set; } = new();

        public static Country MapToModel(CountryRequest request)
        {
            return new Country
            {
                id = request.id,
                Latitude = request.Latitude,
                Longitude = request.Longitude,

                Regions = request.Regions?
                    .Select(RegionRequest.MapToModel)
                    .ToList() ?? new List<Region>()
            };
        }
    }
}
