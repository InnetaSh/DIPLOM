using AttractionApiService.Models;
using Globals.Controllers;

namespace AttractionApiService.View
{
    public class AttractionResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public int CountryId { get; set; }
        public int DistrictId { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public List<AttractionImageResponse>? Images { get; set; } = new();


        public static AttractionResponse MapToResponse(Attraction model, string baseUrl)
        {
            return new AttractionResponse
            {
                id = model.id,
                CountryId = model.CountryId,
                DistrictId = model.DistrictId,
                RegionId = model.RegionId,
                CityId = model.CityId,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Images = model.Images?.Select(img => AttractionImageResponse.MapToResponse(img, baseUrl)).ToList()
                     ?? new List<AttractionImageResponse>(),

            };
        }
    }
}
