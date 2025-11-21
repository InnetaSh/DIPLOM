
using Globals.Controllers;
using OfferApiService.Models.RentObject;

namespace OfferApiService.View.RentObject
{
    public class CountryResponse  : IBaseResponse
    {
        public int id { get; set; }
        public string Title { get; set; }
        public List<CityResponse> Cities { get; set; }
    }

}
