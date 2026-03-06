using AttractionApiService.Models;
using AttractionContracts;

namespace AttractionApiService.Mappers
{
    public class AttractionMapper
    {
        public static Attraction MapToModelWithCoords(AttractionRequest request, double latitude, double longitude)
        {
            return new Attraction
            {
                id = request.id,
                CountryId = request.CountryId,
                RegionId = request.RegionId,
                CityId = request.CityId,

                Address = $"{request.Street} {request.HouseNumber}",
                Latitude = latitude,
                Longitude = longitude,
                Slug = request.Slug,
                ImageUrl_Main = request.ImageUrl_Main,

                ImageUrl_1 = request.ImageUrl_1,

                ImageUrl_2 = request.ImageUrl_2,

                ImageUrl_3 = request.ImageUrl_3,
                Images = request.Images?
                    .Select(url => new AttractionImage { Url = url })
                    .ToList() ?? new List<AttractionImage>()
            };
        }
        public static Attraction MapToModel(AttractionRequest request)
        {
            return new Attraction
            {
                id = request.id,
                CountryId = request.CountryId,
                RegionId = request.RegionId,
                CityId = request.CityId,

                Address = $"{request.Street} {request.HouseNumber}",
                Latitude = 0,
                Longitude = 0,
                Slug = request.Slug,
                ImageUrl_Main = request.ImageUrl_Main,

                ImageUrl_1 = request.ImageUrl_1,

                ImageUrl_2 = request.ImageUrl_2,

                ImageUrl_3 = request.ImageUrl_3,
                Images = request.Images?
                    .Select(url => new AttractionImage { Url = url })
                    .ToList() ?? new List<AttractionImage>()
            };
        }



        private const string DefaultCityImage = "/images/default-attraction.jpeg";
        public static AttractionResponse MapToResponse(Attraction model, string baseUrl)
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

            return new AttractionResponse
            {
                id = model.id,
                CountryId = model.CountryId,
                RegionId = model.RegionId,
                CityId = model.CityId,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Slug = model.Slug,
                ImageUrl_Main = $"{baseUrl}/{ImageUrl_Main}",

                ImageUrl_1 = $"{baseUrl}/{ImageUrl_1}",
                ImageUrl_2 = $"{baseUrl}/{ImageUrl_2}",
                ImageUrl_3 = $"{baseUrl}/{ImageUrl_3}",
                Images = model.Images?.Select(img => AttractionImageMapper.MapToResponse(img, baseUrl)).ToList()
                     ?? new List<AttractionImageResponse>(),

            };
        }
    }
}
