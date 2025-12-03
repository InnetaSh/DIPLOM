using Globals.Sevices;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;

namespace LocationApiService.Services
{
    public class RegionService : TableServiceBase<Region, LocationContext>, IRegionService
    {

    }
}
