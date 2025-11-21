using Globals.Models;

namespace OfferApiService.Models.RentObject
{
    public class Country : EntityBase
    {
        
        public string Title { get; set; }

        public List<City> Cities { get; set; }
    }
}
