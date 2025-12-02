using Globals.Models;

namespace OfferApiService.Models.RentObject
{
    public class Country : EntityBase
    {
        
        public string Title { get; set; }

        public ICollection<City> Cities { get; set; } = new List<City>();

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
