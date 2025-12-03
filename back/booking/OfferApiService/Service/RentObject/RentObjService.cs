using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using OfferApiService.Models;
using OfferApiService.Models.RentObject;


namespace OfferApiService.Services.Interfaces.RentObject
{
    public class RentObjService : TableServiceBase<Models.RentObject.RentObject, OfferContext>, IRentObjService
    {
       
    }
}
