using Globals.Controllers;
using LocationApiService.Models;

namespace LocationApiService.View
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

        public static AttractionResponse MapToResponse(Attraction model)
        {
            return new AttractionResponse
            {
                id = model.id,
                CountryId = model.CountryId,
                DistrictId = model.DistrictId,
                RegionId = model.RegionId,
                CityId = model.CityId,
                Latitude = model.Latitude,
                Longitude = model.Longitude
            };
        }
    }
}
