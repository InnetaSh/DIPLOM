using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Services.Interfaces.RentObj;
using OfferApiService.View.RentObj;

namespace OfferApiService.Controllers.RentObj
{
    public class ParamsCategoryController : EntityControllerBase<ParamsCategory, ParamsCategoryResponse, ParamsCategoryRequest>
    {
        public ParamsCategoryController(IParamsCategoryService paramsCategoryService, IRabbitMqService mqService)
    : base(paramsCategoryService, mqService)
        {
        }


        protected override ParamsCategory MapToModel(ParamsCategoryRequest request)
        {
            return ParamsCategoryRequest.MapToModel(request);
        }


        protected override ParamsCategoryResponse MapToResponse(ParamsCategory model)
        {
            return ParamsCategoryResponse.MapToResponse(model);

        }

    }
}