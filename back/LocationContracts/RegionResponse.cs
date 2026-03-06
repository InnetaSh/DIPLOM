using Globals.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationContracts
{
    public class RegionResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int CountryId { get; set; }
        public List<CityResponse> Cities { get; set; } = new();
    }
}
