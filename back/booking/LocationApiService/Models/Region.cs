using Globals.Models;

namespace LocationApiService.Models
{
    public class Region : EntityBase
    {
        //public string Title { get; set; }


        public int CountryId { get; set; }
        public Country Country { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
