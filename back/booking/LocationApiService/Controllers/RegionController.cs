using Globals.Abstractions;
using Globals.Controllers;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;
using LocationApiService.View;
using Microsoft.AspNetCore.Mvc;

namespace LocationApiService.Controllers
{
    public class RegionController : EntityControllerBase<Region, RegionResponse, RegionRequest>
    {
        public RegionController(IRegionService regionService, IRabbitMqService mqService)
            : base(regionService, mqService)
        {
        }


        protected override Region MapToModel(RegionRequest request)
        {
            return RegionRequest.MapToModel(request);
        }


        protected override RegionResponse MapToResponse(Region model)
        {
            return RegionResponse.MapToResponse(model);

        }
    }
}