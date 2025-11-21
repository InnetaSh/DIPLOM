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
    public class RentObjController : BaseController<RentObj, RentObjResponse, RentObjRequest>
    {
        public RentObjController(IRentObjService rentObjService, IRabbitMqService mqService)
    : base(rentObjService, mqService)
        {
        }

        [HttpGet("by-city")]
        public async Task<ActionResult<List<RentObjResponse>>> GetByCity([FromQuery] string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return BadRequest("City name is required");

            var rentObjs = await (_service as IRentObjService).GetByCityAsync(city);

            var response = rentObjs.Select(model => new RentObjResponse
            {
                Id = model.id,
                Title = model.Title,
                Description = model.Description,
                CityId = model.CityId,
                Address = model.Address,
                ParamCategories = model.ParamCategories?.Select(pc => new ParamsCategory
                {
                    id = pc.id,
                    Title = pc.Title
                }).ToList(),
                Images = model.Images?.Select(img => img.Url).ToList() ?? new List<string>()
            }).ToList();

            return Ok(response);
        }



        protected override RentObj MapToModel(RentObjRequest request)
        {
            return new RentObj
            {
                id = request.id,
                Title = request.Title,
                Description = request.Description,
                CityId = request.CityId,
                Address = request.Address,
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
                Id = model.id,
                Title = model.Title,
                Description = model.Description,
                CityId = model.CityId,
                Address = model.Address,
                ParamCategories = model.ParamCategories?.Select(pc => new ParamsCategory
                {
                    id = pc.id,
                    Title = pc.Title
                }).ToList(),
                Images = model.Images?.Select(img => img.Url).ToList()
                 ?? new List<string>()
            };
        }
    }
}