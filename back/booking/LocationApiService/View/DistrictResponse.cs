using Globals.Controllers;
using LocationApiService.Models;

namespace LocationApiService.View
{
    public class DistrictResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }


        public static DistrictResponse MapToResponse(District model)
        {
            return new DistrictResponse
            {
                id = model.id,
                CityId = model.CityId,      
                Latitude = model.Latitude,
                Longitude = model.Longitude,
            };
        }
    }
}
