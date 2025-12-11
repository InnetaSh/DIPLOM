using Globals.Controllers;
using LocationApiService.Models;
using System.Linq;

namespace LocationApiService.View
{
    public class DistrictRequest : IBaseRequest
    {
        public int id { get; set; }
        public int CityId { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public List<AttractionRequest> Attractions { get; set; } = new();

        public static District MapToModel(DistrictRequest request)
        {
            return new District
            {
                id = request.id,
                CityId = request.CityId,

                Latitude = request.Latitude,
                Longitude = request.Longitude,

                Attractions = request.Attractions?
                    .Select(AttractionRequest.MapToModel)
                    .ToList() ?? new List<Attraction>()
            };
        }
    }
}
