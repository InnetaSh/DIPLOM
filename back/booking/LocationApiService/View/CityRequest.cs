using Globals.Controllers;
using LocationApiService.Models;

namespace LocationApiService.View
{
    public class CityRequest : IBaseRequest
    {
        public int id { get; set; }

        public int RegionId { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public List<DistrictRequest> Districts { get; set; } = new();

        public static City MapToModel(CityRequest request)
        {
            return new City
            {
                id = request.id,
                RegionId = request.RegionId,

                Latitude = request.Latitude,
                Longitude = request.Longitude,

                Districts = request.Districts?
                    .Select(DistrictRequest.MapToModel)
                    .ToList() ?? new List<District>()
            };
        }
    }
}
