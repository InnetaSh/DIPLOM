using Globals.Controllers;
using LocationApiService.Models;

namespace LocationApiService.View
{
    public class CountryResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public List<RegionResponse> Regions { get; set; } = new();

        public static CountryResponse MapToResponse(Country model)
        {
            return new CountryResponse
            {
                id = model.id,
                Latitude = model.Latitude,
                Longitude = model.Longitude,

                Regions = model.Regions?
                    .Select(RegionResponse.MapToResponse)
                    .ToList() ?? new List<RegionResponse>()
            };
        }
    }
}
