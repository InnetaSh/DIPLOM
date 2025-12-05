using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using OfferApiService.Models;
using OfferApiService.Models.RentObject;


namespace OfferApiService.Services.Interfaces.RentObject
{
    public class RentObjService : TableServiceBase<Models.RentObject.RentObject, OfferContext>, IRentObjService
    {
        public async Task<string> GetTitleParamItem(int id)
        {
            ParamItem fitParamsItem = null;
            try
            {
                using (var db = new OfferContext())
                {
                    fitParamsItem = db.ParamItems.FirstOrDefault(p => p.id == id);
                }
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                //throw new Exception("An error occurred while retrieving offers", ex);
            }
            return fitParamsItem?.Title ?? String.Empty;

        }
    }
}
