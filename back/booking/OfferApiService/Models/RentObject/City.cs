using Globals.Models;

using System.ComponentModel.DataAnnotations;

namespace OfferApiService.Models.RentObject
{
    public class City : EntityBase
    {
        [Required]
        public string Title { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

    
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

  
        public ICollection<Attraction>? Attractions { get; set; } = new List<Attraction>();

    }

}
