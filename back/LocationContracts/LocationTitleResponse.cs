using Globals.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationContracts
{
    public class LocationTitleResponse
    {
        public string CountryTitle { get; set; }
        public string RegionTitle { get; set; }
        public string CityTitle { get; set; }
        public string DistrictTitle { get; set; }
    }
}
