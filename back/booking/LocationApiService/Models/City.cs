using Globals.Models;

using System.ComponentModel.DataAnnotations;

namespace LocationApiService.Models
{
    public class City : EntityBase
    {
        //[Required]
        //public string Title { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

    
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public string PostCode { get; set; }

        public bool? IsTop { get; set; }

        public string? Slug { get; set; }
        public string? ImageUrl_Main { get; set; }
        public string? ImageUrl_1 { get; set; }
        public string? ImageUrl_2 { get; set; }
        public string? ImageUrl_3 { get; set; }
        public ICollection<District> Districts { get; set; } = new List<District>();

    }

}
