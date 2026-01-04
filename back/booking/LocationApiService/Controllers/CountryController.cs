using Globals.Abstractions;
using Globals.Controllers;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;
using LocationApiService.View;
using Microsoft.AspNetCore.Mvc;

namespace LocationApiService.Controllers
{
    public class CountryController : EntityControllerBase<Country, CountryResponse, CountryRequest>
    {
        public CountryController(ICountryService countryService, IRabbitMqService mqService)
            : base(countryService, mqService)
        {
        }

        [HttpGet("get-countries-by-district/{id}")]
        public async Task<ActionResult<CountryResponse>> GetByDistrictId(int id)
        {
            var countries = await _service.GetEntitiesAsync();
     
            var country = countries
                .FirstOrDefault(c => c.Regions
                    .SelectMany(r => r.Cities)
                    .SelectMany(ci => ci.Districts)
                    .Any(d => d.id == id)
                );


            if (country == null)
                return NotFound(new { message = "country not found" });

            return Ok(MapToResponse(country));
        }


        [HttpGet("get-countries-by-city/{id}")]
        public async Task<ActionResult<CountryResponse>> GetByCityId(int id)
        {
            var countries = await _service.GetEntitiesAsync();
            var country = countries
                .FirstOrDefault(c => c.Regions
                    .SelectMany(r => r.Cities)
                    .Any(ci => ci.id == id));

            if (country == null)
                return NotFound(new { message = "country not found" });

            return Ok(MapToResponse(country));
        }


        [HttpGet("get-cities-from-country/{countryId}")]
        public async Task<ActionResult<IEnumerable<CityResponse>>> GetCitiesByCountryId(int countryId)
        {
            var countries = await _service.GetEntitiesAsync();
            var country = countries.FirstOrDefault(c => c.id == countryId);

            if (country == null)
                return NotFound(new { message = "country not found" });

            var cities = country.Regions
                .SelectMany(r => r.Cities)
                .Select(c => new CityResponse
                {
                    id = c.id,
                    RegionId = c.RegionId,
                    Latitude = c.Latitude,
                    Longitude = c.Longitude,
                    Districts = c.Districts?.Select(d => new DistrictResponse
                    {
                        id = d.id,
                        CityId = c.id,
                        Latitude = d.Latitude,
                        Longitude = d.Longitude,
                    }).ToList() ?? new List<DistrictResponse>()
                }).ToList();

            return Ok(cities);
        }

        [HttpGet("get-all-cities")]
        public async Task<ActionResult<IEnumerable<CityResponse>>> GetAllCities()
        {
            var countries = await _service.GetEntitiesAsync();

            var cities = countries
                .SelectMany(c => c.Regions)
                .SelectMany(r => r.Cities)
                .Select(c => new CityResponse
                {

                    id = c.id,
                    RegionId = c.RegionId,
                    Latitude = c.Latitude,
                    Longitude = c.Longitude
                })
                .ToList();

            if (!cities.Any())
                return NotFound(new { message = "No cities found" });

            return Ok(cities);
        }




        protected override Country MapToModel(CountryRequest request)
        {
            return CountryRequest.MapToModel(request);
        }


        protected override CountryResponse MapToResponse(Country model)
        {
            return CountryResponse.MapToResponse(model);

        }

    }
}