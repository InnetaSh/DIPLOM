using Globals.Sevices;
using RentObjectApiService.Models;
using RentObjectApiService.Services.Interfaces;
using RentObjectApiService.Services.Interfaces.RentObjectApiService.Services.Interfaces;


namespace RentObjectApiService.Services
{
    public class RentObjService : TableServiceBase<RentObj, RentObjectContext>, IRentObjService
    {

    }
}
