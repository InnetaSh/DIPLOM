using Globals.Sevices;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;


namespace LocationApiService.Services
{
    public class CityService : TableServiceBaseNew<City, LocationContext>, ICityService
    {
        public CityService(LocationContext context, ILogger<CityService> logger) : base(context, logger)
        {
        }
    }
}
