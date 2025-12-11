using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;


namespace OfferApiService.Services.Interfaces.RentObj
{
    public class RentObjService : TableServiceBase<RentObject, OfferContext>, IRentObjService
    {
        
    }
}
