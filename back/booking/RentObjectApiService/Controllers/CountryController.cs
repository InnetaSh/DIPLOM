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
    public class CountryController : EntityControllerBase<Country, CountryResponse, CountryRequest>
    {
        public CountryController(ICountryService countryService, IRabbitMqService mqService)
    : base(countryService, mqService)
        {
        }


        protected override Country MapToModel(CountryRequest request)
        {
            return new Country
            {
                id = request.id,
                Title = request.Title,
                Cities = request.Cities?.Select(ro => new City
                {
                    id = ro.id,
                    Title = ro.Title
                }).ToList()
            };
        }

        protected override CountryResponse MapToResponse(Country model)
        {
            return new CountryResponse
            {
                id = model.id,
                Title = model.Title,
                Cities = model.Cities?.Select(ro => new City
                {
                    id = ro.id,
                    Title = ro.Title
                }).ToList()
            };
        }
    }
}