using Globals.Sevices;
using RentObjectApiService.Models;
using RentObjectApiService.Services.Interfaces;


namespace RentObjectApiService.Services
{
    public class CountryService : TableServiceBase<Country, RentObjectContext>, ICountryService
    {

    }
}
