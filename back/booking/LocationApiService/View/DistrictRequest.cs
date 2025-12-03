

using Globals.Controllers;

namespace LocationApiService.View
{
    public class DistrictRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Title { get; set; }

        public int CityId { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public List<AttractionRequest> Attractions { get; set; }

    }
}
