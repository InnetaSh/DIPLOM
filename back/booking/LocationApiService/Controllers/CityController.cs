using Globals.Abstractions;
using Globals.Controllers;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;
using LocationApiService.View;
using Microsoft.AspNetCore.Mvc;

namespace LocationApiService.Controllers
{
    public class CityController : EntityControllerBase<City, CityResponse, CityRequest>
    {
        public CityController(ICityService cityService, IRabbitMqService mqService)
            : base(cityService, mqService)
        {
        }


        protected override City MapToModel(CityRequest request)
        {
            return CityRequest.MapToModel(request);
        }


        protected override CityResponse MapToResponse(City model)
        {
            return CityResponse.MapToResponse(model);

        }
    }
}