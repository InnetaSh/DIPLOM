
    using Globals.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    namespace OfferApiService.Models.RentObject
    {
        
        public class Attraction : EntityBase
        {
            [Required]
            public string Name { get; set; }

            public string Description { get; set; }

            [Required]
            public double? Latitude { get; set; }

            [Required]
            public double? Longitude { get; set; }

           
            public int CityId { get; set; }
            public City City { get; set; }
        }
    }


