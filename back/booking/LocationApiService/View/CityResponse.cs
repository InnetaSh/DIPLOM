
using Globals.Controllers;

namespace LocationApiService.View
{
    public class CityResponse : IBaseResponse
    { 
        public int id { get; set; }
        public string Title { get; set; }

        public int RegionId { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public List<DistrictResponse>? Districts { get; set; } = new();

    }

}
