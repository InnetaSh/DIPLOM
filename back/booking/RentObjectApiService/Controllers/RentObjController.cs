using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RentObjectApiService.Models;
using RentObjectApiService.Services;
using RentObjectApiService.Services.Interfaces;
using RentObjectApiService.Services.Interfaces.RentObjectApiService.Services.Interfaces;
using RentObjectApiService.View;
using System.Diagnostics.Metrics;

namespace RentObjectApiService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Route("api/[controller]")]
    public class RentObjController : BaseController<RentObj, RentObjResponse, RentObjRequest>
    {
        public RentObjController(IRentObjService rentObjService, IRabbitMqService mqService)
    : base(rentObjService, mqService)
        {
        }


        protected override RentObj MapToModel(RentObjRequest request)
        {
            return new RentObj
            {
                id = request.id,
                Title = request.Title,
                CityId = request.CityId,
                ParamCategories = request.ParamCategories?.Select(ro => new ParamsCategory
                {
                    id = ro.id,
                    Title = ro.Title
                }).ToList()
            };
        }

        protected override RentObjResponse MapToResponse(RentObj model)
        {
            return new RentObjResponse
            {
                id = model.id,
                Title = model.Title
            };
        }
    }
}