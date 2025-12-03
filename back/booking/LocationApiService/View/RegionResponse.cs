
using Globals.Controllers;

namespace LocationApiService.View
{
    public class RegionResponse : IBaseResponse
    {
        public int id { get; set; }
        public string Title { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public List<CityResponse> Cities { get; set; }
    }

}
