using Globals.Sevices;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;


namespace LocationApiService.Services
{
    public class DistrictService : TableServiceBase<District, LocationContext>, IDistrictService
    {
        
    }
}
