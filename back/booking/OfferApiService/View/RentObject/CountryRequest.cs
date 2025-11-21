

using Globals.Controllers;
using OfferApiService.Models.RentObject;

namespace OfferApiService.View.RentObject
{
    public class CountryRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Title { get; set; }
        public List<CityRequest> Cities { get; set; }
    }

}
