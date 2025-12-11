using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Services.Interfaces.RentObj;
using OfferApiService.View.RentObj;

namespace OfferApiService.Controllers.RentObj
{

   
    public class ParamItemController : EntityControllerBase<ParamItem, ParamItemResponse, ParamItemRequest>
    {
        public ParamItemController(IParamItemService paramItemService, IRabbitMqService mqService)
    : base(paramItemService, mqService)
        {
        }


        protected override ParamItem MapToModel(ParamItemRequest request)
        {
            return ParamItemRequest.MapToModel(request);
        }


        protected override ParamItemResponse MapToResponse(ParamItem model)
        {
            return ParamItemResponse.MapToResponse(model);

        }

    }
}