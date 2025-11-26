using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObject;
using OfferApiService.Services.Interfaces.RentObject;
using OfferApiService.View.RentObject;

namespace OfferApiService.Controllers.RentObject
{

   
    public class ParamItemController : EntityControllerBase<ParamItem, ParamItemResponse, ParamItemRequest>
    {
        public ParamItemController(IParamItemService paramItemService, IRabbitMqService mqService)
    : base(paramItemService, mqService)
        {
        }


        protected ParamItem MapToModel(ParamItemRequest request)
        {
            return new ParamItem
            {
                id = request.id,
                Title = request.Title,
                CategoryId = request.CategoryId,
                ValueType = request.ValueType
            };
        }

        protected ParamItemResponse MapToResponse(ParamItem model)
        {
            return new ParamItemResponse
            {
                id = model.id,
                Title = model.Title,
                ValueType = model.ValueType
            };
        }

    }
}