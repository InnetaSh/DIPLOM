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
        public string? ImageUrl { get; set; }
        public List<DistrictResponse>? Districts { get; set; } = new();


        private const string DefaultCityImage = "/images/default-city.jpeg";
        public static CityResponse MapToResponse(
            City model,
            string baseUrl )
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var imagePath = string.IsNullOrWhiteSpace(model.ImageUrl)
                ? DefaultCityImage
                : model.ImageUrl;

            return new CityResponse
            {
                id = model.id,
                RegionId = model.RegionId,
                Latitude = model.Latitude,
                Longitude = model.Longitude,

                ImageUrl = $"{baseUrl}{imagePath}",
                Districts = model.Districts?
                    .Select(DistrictResponse.MapToResponse)
                    .ToList()
            };
        }
    }
}
