using Globals.Controllers;
using LocationApiService.Models;

namespace LocationApiService.View
{
    public class CityResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }

        public string? RegionTitle { get; set; }
        public string? CountryTitle { get; set; }
        public int? RegionId { get; set; }
        public int? CountryId { get; set; }
        public string? Description { get; set; }
        public string? History { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string PostCode { get; set; }
        public bool? IsTop { get; set; }
        public string? Slug { get; set; }
        public string? ImageUrl_Main { get; set; }
        public string? ImageUrl_1 { get; set; }
        public string? ImageUrl_2 { get; set; }
        public string? ImageUrl_3 { get; set; }
        public List<DistrictResponse>? Districts { get; set; } = new();


        private const string DefaultCityImage = "/images/default-city.jpeg";
        public static CityResponse MapToResponse(
            City model,
            string baseUrl )
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var ImageUrl_Main = string.IsNullOrWhiteSpace(model.ImageUrl_Main)
                ? DefaultCityImage
                : model.ImageUrl_Main;

            var ImageUrl_1 = string.IsNullOrWhiteSpace(model.ImageUrl_1)
                ? DefaultCityImage
                : model.ImageUrl_1;

            var ImageUrl_2 = string.IsNullOrWhiteSpace(model.ImageUrl_2)
                ? DefaultCityImage
                : model.ImageUrl_2;

            var ImageUrl_3 = string.IsNullOrWhiteSpace(model.ImageUrl_3)
                ? DefaultCityImage
                : model.ImageUrl_3;

            return new CityResponse
            {
                id = model.id,
                RegionId = model.RegionId,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                PostCode = model.PostCode,
                IsTop = model.IsTop,
                Slug = model.Slug,
                ImageUrl_Main = $"{baseUrl}/{ImageUrl_Main}",

                ImageUrl_1 = $"{baseUrl}/{ImageUrl_1}",
                ImageUrl_2 = $"{baseUrl}/{ImageUrl_2}",
                ImageUrl_3 = $"{baseUrl}/{ImageUrl_3}",
                Districts = model.Districts?
                    .Select(DistrictResponse.MapToResponse)
                    .ToList()
            };
        }
    }
}
