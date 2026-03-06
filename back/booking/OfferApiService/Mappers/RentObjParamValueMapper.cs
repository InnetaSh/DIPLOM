using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;
using OfferContracts;
using OfferContracts.RentObj;

namespace OfferApiService.Mappers
{
    public static class RentObjParamValueMapper
    {
        public static RentObjParamValue MapToModel( RentObjParamValueRequest request)
        {
            return new RentObjParamValue
            {
                id = request.id,
                RentObjId = request.RentObjId,
                ParamItemId = request.ParamItemId,
                ValueBool = request.ValueBool,
                ValueInt = request.ValueInt,
                ValueString = request.ValueString,
                IconName = request.IconName,
            };
        }


        public static RentObjParamValueResponse MapToResponse( RentObjParamValue model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            return new RentObjParamValueResponse
            {
                id = model.id,
                RentObjId = model.RentObjId,
                ParamItemId = model.ParamItemId,
                ValueBool = model.ValueBool,
                ValueInt = model.ValueInt,
                ValueString = model.ValueString,
                IconName = model.IconName,
            };
        }
    }
}
