

using AttractionsApiService.Models;
using Globals.Controllers;

namespace AttractionsApiService.View
{
    public class AttractionRequest : IBaseRequest
    {
        public int id { get; set; }
        public int CountryId { get; set; }
        public int DistrictId { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }

        //public double? Latitude { get; set; }
        //public double? Longitude { get; set; }

        public string CountryTitle { get; set; }
        public string CityTitle { get; set; }

        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Postcode { get; set; }
        public List<string> Images { get; set; } = new();


        public static Attraction MapToModel(AttractionRequest request)
        {
            return new Attraction
            {
                id = request.id,
                CountryId = request.CountryId,
                DistrictId = request.DistrictId,
                RegionId = request.RegionId,
                CityId = request.CityId,

                Address = $"{request.Street} {request.HouseNumber}",
                Latitude = 0,
                Longitude = 0,
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
                DistrictId = request.DistrictId,
                RegionId = request.RegionId,
                CityId = request.CityId,

                Address = $"{request.Street} {request.HouseNumber}",
                Latitude = latitude,
                Longitude = longitude,
                Images = request.Images?
                    .Select(url => new AttractionImage { Url = url })
                    .ToList() ?? new List<AttractionImage>()
            };
        }
    }
}
