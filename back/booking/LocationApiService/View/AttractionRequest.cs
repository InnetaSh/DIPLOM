

using Globals.Controllers;

namespace LocationApiService.View
{
    public class AttractionRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Title { get; set; }

        public int DistrictId { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }


    }
}
