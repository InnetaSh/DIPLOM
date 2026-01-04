
using Globals.Models;

namespace LocationApiService.Models
{
        public class District : EntityBase
        {

            public int CityId { get; set; }
            public City City { get; set; }

            public double? Latitude { get; set; }
            public double? Longitude { get; set; }

           
    }
}


