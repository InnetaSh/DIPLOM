using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;


namespace OfferApiService.Services.Interfaces.RentObj
{
    public class RentObjService : TableServiceBase<RentObject, OfferContext>, IRentObjService
    {


        public async Task<int> AddRentObjWithParamValuesAsync(RentObject rentObj)
        {
           
            if (rentObj.ParamValues != null)
            {
                foreach (var param in rentObj.ParamValues)
                {
                    param.ValueString ??= ""; 
                }
            }

            using var db = new OfferContext();
            {
                var res = db.RentObjects.Add(rentObj);
                await db.SaveChangesAsync(); 
                return res.Entity.id;
            }
        }

    }
}
