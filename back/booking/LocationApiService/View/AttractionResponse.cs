
using Globals.Controllers;

namespace LocationApiService.View
{
    public class AttractionResponse : IBaseResponse
    { 
        public int id { get; set; }
        public string Title { get; set; }

        public int DistrictId { get; set; }
        public string Country { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }


    }

}
