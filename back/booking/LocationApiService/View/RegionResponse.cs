using Globals.Controllers;
using LocationApiService.Models;

namespace LocationApiService.View
{
    public class RegionResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int CountryId { get; set; }

        public List<CityResponse> Cities { get; set; } = new();

        public static RegionResponse MapToResponse(Region model, string baseUrl)
        {
            return new RegionResponse
            {
                id = model.id,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                CountryId = model.CountryId,

                Cities = model.Cities?
                    .Select(city => CityResponse.MapToResponse(city, baseUrl))
                    .ToList() ?? new List<CityResponse>()
            };
        }
    }
}
