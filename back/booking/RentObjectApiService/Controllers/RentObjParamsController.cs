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
    public class RentObjParamsController : BaseController<RentObjParam, RentObjParamResponse, RentObjParamRequest>
    {
        public RentObjParamsController(IRentObjParamsService rentObjParamService, IRabbitMqService mqService)
    : base(rentObjParamService, mqService)
        {
        }


        protected override RentObjParam MapToModel(RentObjParamRequest request)
        {
            return new RentObjParam
            {
                id = request.id,
                Title = request.Title,
                Value = request.Value
            };
        }

        protected override RentObjParamResponse MapToResponse(RentObjParam model)
        {
            return new RentObjParamResponse
            {
                id = model.id,
                Title = model.Title,
                Value = model.Value
            };
        }
    }
}