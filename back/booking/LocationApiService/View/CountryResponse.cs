
using Globals.Controllers;

namespace LocationApiService.View
{
    public class CountryResponse  : IBaseResponse
    {
        public int id { get; set; }
        public string Title { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public List<RegionResponse> Regions { get; set; }
    }

}
