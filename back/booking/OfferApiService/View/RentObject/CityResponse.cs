
using Globals.Controllers;

namespace OfferApiService.View.RentObject
{
    public class CityResponse : IBaseResponse
    { 
        public int id { get; set; }
        public string Title { get; set; }

        public int CountryId { get; set; }
        public string Country { get; set; }

    }

}
