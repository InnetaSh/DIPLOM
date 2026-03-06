using LocationApiService.Models;
using LocationContracts;

namespace LocationApiService.Mappers
{
    public static class CityMapper
    {
        public static City MapToModel( CityRequest request)
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
                   .Select(x => DistrictMapper.MapToModel(x))
                    ?.ToList() ?? new List<District>()
            };
        }


        private const string DefaultCityImage = "/images/default-city.jpeg";
        public static CityResponse MapToResponse( City model,string baseUrl)
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
                   .Select(x => DistrictMapper.MapToResponse(x))
                   ?.ToList() ?? new List<DistrictResponse>()
            };
        }
    }
}
