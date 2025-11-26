using Globals.Sevices;
using OfferApiService.Models;
using OfferApiService.Models.RentObject;
using OfferApiService.Services.Interfaces.RentObject;

namespace OfferApiService.Services.RentObject
{
    public class CityService : TableServiceBase<City, OfferContext>, ICityService
    {
        
    }
}
