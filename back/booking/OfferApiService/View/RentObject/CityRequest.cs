

using Globals.Controllers;

namespace OfferApiService.View.RentObject
{
    public class CityRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Title { get; set; }

        public int CountryId { get; set; }

    }
}
