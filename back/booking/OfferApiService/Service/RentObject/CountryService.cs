using Globals.Sevices;
using OfferApiService.Models;
using OfferApiService.Models.RentObject;


namespace OfferApiService.Services.Interfaces.RentObject
{
    public class CountryService : TableServiceBase<Country, OfferContext>, ICountryService
    {

    }
}
