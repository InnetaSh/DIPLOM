using Globals.Controllers;
using LocationApiService.Models;

namespace LocationApiService.View
{
    public class CityResponseForPupularList : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
      
        public string? Slug { get; set; }
        public string? ImageUrl_Main { get; set; }
     


        private const string DefaultCityImage = "/images/default-city.jpeg";
        public static CityResponseForPupularList MapToResponse(
            City model,
            string baseUrl )
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var ImageUrl_Main = string.IsNullOrWhiteSpace(model.ImageUrl_Main)
                ? DefaultCityImage
                : model.ImageUrl_Main;

          

            return new CityResponseForPupularList
            {
                id = model.id,
              
                Slug = model.Slug,
                ImageUrl_Main = $"{baseUrl}/{ImageUrl_Main}",
            };
        }
    }
}
