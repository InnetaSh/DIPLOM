using Globals.Sevices;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;


namespace LocationApiService.Services
{
    public class AttractionService : TableServiceBase<Attraction, LocationContext>, IAttractionService
    {
        
    }
}
