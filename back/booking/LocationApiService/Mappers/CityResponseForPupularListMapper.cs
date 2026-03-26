using LocationApiService.Models;
using LocationContracts;

namespace LocationApiService.Mappers
{
    public static class CityResponseForPupularListMapper
    {

        private const string DefaultCityImage = "/images/default-city.jpeg";
        public static CityResponseForPopularList MapToResponse( City model, string baseUrl)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var ImageUrl_Main = string.IsNullOrWhiteSpace(model.ImageUrl_Main)
                ? DefaultCityImage
                : model.ImageUrl_Main;



            return new CityResponseForPopularList
            {
                id = model.id,

                Slug = model.Slug,
                ImageUrl_Main = $"{baseUrl}/{ImageUrl_Main}",
            };
        }
    }
}
