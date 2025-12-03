

using Globals.Controllers;

namespace LocationApiService.View
{
    public class RegionRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Title { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public List<CityRequest> Cities { get; set; }
    }

}
