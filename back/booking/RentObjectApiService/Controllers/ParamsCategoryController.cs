using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RentObjectApiService.Models;
using RentObjectApiService.Services;
using RentObjectApiService.Services.Interfaces;
using RentObjectApiService.View;
using System.Diagnostics.Metrics;

namespace RentObjectApiService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Route("api/[controller]")]
    public class ParamsCategoryController : BaseController<ParamsCategory, ParamsCategoryResponse, ParamsCategoryRequest>
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
                Params = request.Params?.Select(ro => new RentObjParam
                {
                    id = ro.id,
                    Title = ro.Title
                }).ToList()
            };
        }

        protected override ParamsCategoryResponse MapToResponse(ParamsCategory model)
        {
            return new ParamsCategoryResponse
            {
                id = model.id,
                Title = model.Title,
                Params = model.Params?.Select(ro => new RentObjParamRequest
                {
                   id = ro.id,
                   Title = ro.Title
               }).ToList()
            };
        }
    }
}