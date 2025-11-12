using Globals.Models;

namespace RentObjectApiService.Models
{
    public class Country : EntityBase
    {
        
        public string Title { get; set; }

        public List<City> Cities { get; set; }
    }
}
