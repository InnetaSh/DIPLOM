using Globals.Abstractions;
using Globals.Controllers;
using LocationApiService.Mappers;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;
using LocationContracts;

//using LocationApiService.View;
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
            return DistrictMapper.MapToModel(request);
        }


        protected override DistrictResponse MapToResponse(District model)
        {
            return DistrictMapper.MapToResponse(model);

        }

    }
}