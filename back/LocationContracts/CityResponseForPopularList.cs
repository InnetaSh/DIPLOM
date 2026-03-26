using Globals.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationContracts
{
    public class CityResponseForPopularList : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? ImageUrl_Main { get; set; }
     
    }
}
