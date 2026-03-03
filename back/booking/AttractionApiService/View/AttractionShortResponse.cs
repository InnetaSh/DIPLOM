using AttractionApiService.Models;
using Globals.Controllers;

namespace AttractionApiService.View
{
    public class AttractionShortResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl_Main { get; set; }
        public string? Slug {  get; set; }


        public List<AttractionImageResponse>? Images { get; set; } = new();

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

               
                Images = model.Images?.Select(img => AttractionImageResponse.MapToResponse(img, baseUrl)).ToList()
                     ?? new List<AttractionImageResponse>(),

            };
        }
    }
}
