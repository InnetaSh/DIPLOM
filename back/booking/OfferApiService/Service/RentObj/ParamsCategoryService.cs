using Globals.Sevices;
using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;


namespace OfferApiService.Services.Interfaces.RentObj
{
    public class ParamsCategoryService : TableServiceBaseNew<ParamsCategory, OfferContext>, IParamsCategoryService
    {
        public ParamsCategoryService(OfferContext context, ILogger<ParamsCategoryService> logger) : base(context, logger)
        {
        }

    }
}
