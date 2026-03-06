using Globals.Sevices;
using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;




namespace OfferApiService.Services.Interfaces.RentObj
{
    public class ParamItemService : TableServiceBaseNew<ParamItem, OfferContext>, IParamItemService
    {
        public ParamItemService(OfferContext context, ILogger<ParamItemService> logger) : base(context, logger)
        {
        }

    }
}
