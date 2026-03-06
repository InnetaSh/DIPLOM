using Globals.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationContracts
{
    public class CityRequest: IBaseRequest
    {
        public int id { get; set; }

        public int RegionId { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? PostCode { get; set; }
        public bool? IsTop { get; set; }
        public string? Slug { get; set; }
        public string? ImageUrl_Main { get; set; }
        public string? ImageUrl_1 { get; set; }
        public string? ImageUrl_2 { get; set; }
        public string? ImageUrl_3 { get; set; }
        public List<DistrictRequest> Districts { get; set; } = new();

    }
}
