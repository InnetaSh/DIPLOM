using Globals.Abstractions;
using Globals.Controllers;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;
using LocationApiService.View;
using Microsoft.AspNetCore.Mvc;

namespace LocationApiService.Controllers
{
    public class DistrictController : EntityControllerBase<District, DistrictResponse, DistrictRequest>
    {
        public DistrictController(IDistrictService districtService, IRabbitMqService mqService)
            : base(districtService, mqService)
        {
        }

        protected override District MapToModel(DistrictRequest request)
        {
            return DistrictRequest.MapToModel(request);
        }


        protected override DistrictResponse MapToResponse(District model)
        {
            return DistrictResponse.MapToResponse(model);

        }

    }
}