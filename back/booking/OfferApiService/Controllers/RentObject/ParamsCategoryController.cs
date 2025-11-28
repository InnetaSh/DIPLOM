using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObject;
using OfferApiService.Services.Interfaces.RentObject;
using OfferApiService.View.RentObject;

namespace OfferApiService.Controllers.RentObject
{
    public class ParamsCategoryController : EntityControllerBase<ParamsCategory, ParamsCategoryResponse, ParamsCategoryRequest>
    {
        public ParamsCategoryController(IParamsCategoryService paramsCategoryService, IRabbitMqService mqService)
    : base(paramsCategoryService, mqService)
        {
        }


        protected override ParamsCategory MapToModel(ParamsCategoryRequest request)
        {
            return new ParamsCategory
            {
                id = request.id,
                Title = request.Title,
                Items = request.Items?.Select(item => new ParamItem
                {
                    id = item.id,
                    Title = item.Title,
                    CategoryId = request.id,
                    ValueType = item.ValueType
                }).ToList() ?? new List<ParamItem>()
            };
        }

        protected override ParamsCategoryResponse MapToResponse(ParamsCategory model)
        {
            return new ParamsCategoryResponse
            {
                id = model.id,
                Title = model.Title,
                Items = model.Items?.Select(item => new ParamItemResponse
                {
                    id = item.id,
                    Title = item.Title,
                    ValueType = item.ValueType
                }).ToList() ?? new List<ParamItemResponse>()
            };
        }

    }
}