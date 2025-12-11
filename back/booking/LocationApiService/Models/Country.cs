using Globals.Models;

namespace LocationApiService.Models
{
    public class Country : EntityBase
    {

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public ICollection<Region> Regions { get; set; } = new List<Region>();
    }
}
