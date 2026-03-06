using Globals.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationContracts
{
    public class CityResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }

        public string? RegionTitle { get; set; }
        public string? CountryTitle { get; set; }
        public int? RegionId { get; set; }
        public int? CountryId { get; set; }
        public string? Description { get; set; }
        public string? History { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string PostCode { get; set; }
        public bool? IsTop { get; set; }
        public string? Slug { get; set; }
        public string? ImageUrl_Main { get; set; }
        public string? ImageUrl_1 { get; set; }
        public string? ImageUrl_2 { get; set; }
        public string? ImageUrl_3 { get; set; }
        public List<DistrictResponse>? Districts { get; set; } = new();


        
    }
}
