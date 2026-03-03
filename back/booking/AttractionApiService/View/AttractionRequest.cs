using AttractionApiService.Models;
using Globals.Controllers;

namespace AttractionApiService.View
{
    public class AttractionRequest : IBaseRequest
    {
        public int id { get; set; }
        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }

        //public double? Latitude { get; set; }
        //public double? Longitude { get; set; }

        public string CountryTitle { get; set; }
        public string CityTitle { get; set; }

        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Postcode { get; set; }
        public string? Slug { get; set; }
        public string? ImageUrl_Main { get; set; }
        public string? ImageUrl_1 { get; set; }
        public string? ImageUrl_2 { get; set; }
        public string? ImageUrl_3 { get; set; }
        public List<string>? Images { get; set; } = new();


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
                ImageUrl_1=request.ImageUrl_1,
                ImageUrl_2=request.ImageUrl_2,
                ImageUrl_3=request.ImageUrl_3,
                Images = request.Images?
                    .Select(url => new AttractionImage { Url = url })
                    .ToList() ?? new List<AttractionImage>()
            };
        }


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
    }
}
