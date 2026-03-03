
    using Globals.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

namespace AttractionApiService.Models
{
        
        public class Attraction : EntityBase
        {
            //[Required]
            //public string Title { get; set; }

            //public string Description { get; set; }

            public double? Latitude { get; set; }

            public double? Longitude { get; set; }

            [Required]
            public string? Address { get; set; }
            public int CountryId { get; set; }
            public int RegionId { get; set; }
            public int CityId { get; set; }
            public string? Slug { get; set; }
            public string? ImageUrl_Main { get; set; }
            public string? ImageUrl_1 { get; set; }
            public string? ImageUrl_2 { get; set; }
            public string? ImageUrl_3 { get; set; }
        public List<AttractionImage> Images { get; set; }
        }
    }


