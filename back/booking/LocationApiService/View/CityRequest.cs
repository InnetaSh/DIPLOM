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
        public string? PostCode { get; set; }
        public bool? IsTop { get; set; }
        public string? Slug { get; set; }
        public string? ImageUrl_Main { get; set; }
        public string? ImageUrl_1 { get; set; }
        public string? ImageUrl_2 { get; set; }
        public string? ImageUrl_3 { get; set; }
        public List<DistrictRequest> Districts { get; set; } = new();

        public static City MapToModel(CityRequest request)
        {
            return new City
            {
                id = request.id,
                RegionId = request.RegionId,

                Latitude = request.Latitude,
                Longitude = request.Longitude,
                PostCode = request.PostCode,
                IsTop = request.IsTop,
                Slug = request.Slug,
                ImageUrl_Main = request.ImageUrl_Main,

                ImageUrl_1 = request.ImageUrl_1,

                ImageUrl_2 = request.ImageUrl_2,

                ImageUrl_3 = request.ImageUrl_3,

                Districts = request.Districts?
                    .Select(DistrictRequest.MapToModel)
                    .ToList() ?? new List<District>()
            };
        }
    }
}
