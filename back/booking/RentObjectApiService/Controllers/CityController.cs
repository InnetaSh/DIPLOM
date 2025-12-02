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
    public class CityController : EntityControllerBase<City, CityResponse, CityRequest>
    {
        public CityController(ICityService cityService, IRabbitMqService mqService)
            : base(cityService, mqService)
                {
                }


        protected override City MapToModel(CityRequest request)
        {
            return new City
            {
                id = request.id,
                Title = request.Title,
                CountryId = request.CountryId,
                Country = request.Country,
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
            };
        }
    }
}