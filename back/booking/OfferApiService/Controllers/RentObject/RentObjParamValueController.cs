using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObject;
using OfferApiService.Services.Interfaces.RentObject;
using OfferApiService.View.RentObject;

namespace OfferApiService.Controllers.RentObject
{

    public class RentObjParamValueController : EntityControllerBase<RentObjParamValue, RentObjParamValueResponse, RentObjParamValueRequest>
    {
        public RentObjParamValueController(IRentObjParamValueService rentObjParamValueService, IRabbitMqService mqService)
    : base(rentObjParamValueService, mqService)
        {
        }


        protected override RentObjParamValue MapToModel(RentObjParamValueRequest request)
        {
            return new RentObjParamValue
            {
                id = request.id,
                RentObjId = request.RentObjId,
                ParamItemId = request.ParamItemId,
                ValueBool = request.ValueBool,
                ValueInt = request.ValueInt,
                ValueString = request.ValueString
            };
        }

        protected override RentObjParamValueResponse MapToResponse(RentObjParamValue model)
        {
            return new RentObjParamValueResponse
            {
                id = model.id,
                RentObjId = model.RentObjId,
                ParamItemId = model.ParamItemId,
                ParamItemTitle = model.ParamItem?.Title,
                ValueBool = model.ValueBool,
                ValueInt = model.ValueInt,
                ValueString = model.ValueString
            };
        }

    }
}