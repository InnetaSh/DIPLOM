using Globals.Sevices;
using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;


namespace OfferApiService.Services.Interfaces.RentObj
{
    public class RentObjParamValueService : TableServiceBaseNew<RentObjParamValue, OfferContext>, IRentObjParamValueService
    {
        public RentObjParamValueService(OfferContext context, ILogger<RentObjParamValueService> logger) : base(context, logger)
        {
        }

    }
}
