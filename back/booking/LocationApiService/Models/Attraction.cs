
    using Globals.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    namespace LocationApiService.Models
    {
        
        public class Attraction : EntityBase
        {
            [Required]
            public string Title { get; set; }

            public string Description { get; set; }

            [Required]
            public double? Latitude { get; set; }

            [Required]
            public double? Longitude { get; set; }

           
            public int DistrictId { get; set; }
            public District District { get; set; }
        }
    }


