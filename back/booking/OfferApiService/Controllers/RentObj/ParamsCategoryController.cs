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

        //========================================================================================== 
        //                        получение для фильтра категории
        //==========================================================================================

        [HttpGet("get-all/filtered")]
        public virtual async Task<ActionResult<List<ParamsCategoryResponse>>> GetAllForFilter()
        {
            var items = await _service.GetEntitiesAsync();
            if (items == null || !items.Any())
                return NotFound(new { message = "No items found" });

            // Фильтрация по IsFilterable = true
            var filteredItems = items.Where(item => item.IsFilterable).ToList();

            if (!filteredItems.Any())
                return NotFound(new { message = "No filterable items found" });

            var responseList = filteredItems.Select(item => MapToResponse(item)).ToList();
            return Ok(responseList);
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