using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Service.Interface;
using OfferApiService.Services.Interfaces.RentObj;
using OfferApiService.View.RentObj;

namespace OfferApiService.Controllers.RentObj
{

    public class RentObjParamValueController : EntityControllerBase<RentObjParamValue, RentObjParamValueResponse, RentObjParamValueRequest>
    {
   
        public RentObjParamValueController(IRentObjParamValueService rentObjParamValueService, IRabbitMqService mqService)
    : base(rentObjParamValueService, mqService)
        { 
           
        }


        protected override RentObjParamValue MapToModel(RentObjParamValueRequest request)
        {
            return RentObjParamValueRequest.MapToModel(request);
        }

        protected override RentObjParamValueResponse MapToResponse(RentObjParamValue model)
        {

            return RentObjParamValueResponse.MapToResponse(model);

        }

    }
}