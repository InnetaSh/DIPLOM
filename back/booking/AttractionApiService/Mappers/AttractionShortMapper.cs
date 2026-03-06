using AttractionApiService.Models;
using AttractionContracts;

namespace AttractionApiService.Mappers
{
    public class AttractionShortMapper
    {
        private const string DefaultCityImage = "/images/default-attraction.jpeg";

        public static AttractionShortResponse MapToResponse(Attraction model, string baseUrl)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var ImageUrl_Main = string.IsNullOrWhiteSpace(model.ImageUrl_Main)
                ? DefaultCityImage
                : model.ImageUrl_Main;


            return new AttractionShortResponse
            {
                id = model.id,
                Slug = model.Slug,
                ImageUrl_Main = $"{baseUrl}/{ImageUrl_Main}",


                Images = model.Images?.Select(img => AttractionImageMapper.MapToResponse(img, baseUrl)).ToList()
                     ?? new List<AttractionImageResponse>(),

            };
        }
    }
}
