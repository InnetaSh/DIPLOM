using Globals.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationContracts
{
    public class DistrictRequest : IBaseRequest
    {
        public int id { get; set; }
        public int CityId { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
