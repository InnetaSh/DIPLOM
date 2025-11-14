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
    public class CityController : BaseController<City, CityResponse, CityDTO>
    {
        public CityController(ICityService cityService, IRabbitMqService mqService)
            : base(cityService, mqService)
                {
                }


        protected override City MapToModel(CityDTO request)
        {
            return new City
            {
                id = request.id,
                Title = request.Title,
                CountryId = request.CountryId,
                Country = request.Country,
                RentObjs = request.RentObjs?.Select(ro => new RentObj
                {
                    id = ro.id,
                    Title = ro.Title
                }).ToList()
            };
        }

        protected override CityResponse MapToResponse(City model)
        {
            return new CityResponse
            {
                id = model.id,
                Title = model.Title,
                CountryId = model.CountryId,
                Country = model.Country,
                RentObjs = model.RentObjs?.Select(ro => new RentObjResponse
                {
                    Id = ro.id,
                    Title = ro.Title
                }).ToList()
            };
        }
    }
}