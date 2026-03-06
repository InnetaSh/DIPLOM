using Globals.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LocationContracts
{
    public class DistrictResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }


    }
}
