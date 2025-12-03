

using Globals.Controllers;

namespace LocationApiService.View
{
    public class CityRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Title { get; set; }

        public int RegionId { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public List<DistrictRequest> Districts { get; set; }

    }
}
