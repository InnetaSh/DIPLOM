using Globals.Sevices;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;


namespace LocationApiService.Services
{
    public class DistrictService : TableServiceBaseNew<District, LocationContext>, IDistrictService
    {
        public DistrictService(LocationContext context, ILogger<DistrictService> logger) : base(context, logger)
        {
        }

    }
}
