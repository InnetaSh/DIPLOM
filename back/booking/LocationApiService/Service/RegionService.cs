using Globals.Sevices;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;

namespace LocationApiService.Services
{
    public class RegionService : TableServiceBaseNew<Region, LocationContext>, IRegionService
    {
        public RegionService(LocationContext context, ILogger<RegionService> logger) : base(context, logger)
        {
        }
    }
}
