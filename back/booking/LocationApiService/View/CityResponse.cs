using Globals.Controllers;
using LocationApiService.Models;

namespace LocationApiService.View
{
    public class CityResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public int RegionId { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public List<DistrictResponse>? Districts { get; set; } = new();

        public static CityResponse MapToResponse(City model)
        {
            return new CityResponse
            {
                id = model.id,
                RegionId = model.RegionId,
                Latitude = model.Latitude,
                Longitude = model.Longitude,

                Districts = model.Districts?
                    .Select(DistrictResponse.MapToResponse)
                    .ToList()
            };
        }
    }
}
