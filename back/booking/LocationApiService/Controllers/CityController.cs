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
        private readonly string _baseUrl;
        private readonly ICityService _cityService;
        public CityController(
            ICityService cityService,
            IRabbitMqService mqService,
            IConfiguration configuration)
            : base(cityService, mqService)
        {
            _cityService = cityService;
            _baseUrl = configuration["AppSettings:BaseUrl"];
        }

        //===========================================================================================
        //  получение городов для списка популярных 
        //===========================================================================================

        [HttpGet("search/cities/populars")]
        public async Task<ActionResult<List<CityResponse>>> GetSearchPopularCities(
            [FromQuery] List<int> idList)
        {


            var result = new List<CityResponse>();
            foreach (var cityId in idList)
            {
                var exists = await _cityService.ExistsEntityAsync(cityId);
                if (!exists)
                    return NotFound(new { message = $"offerId {cityId} not found" });

                var cityRez = await _cityService.GetEntityAsync(cityId);
                var city = CityResponse.MapToResponse(cityRez, _baseUrl);
                result.Add(city);
            }

            return Ok(result);
        }



        protected override City MapToModel(CityRequest request)
        {
            return CityRequest.MapToModel(request);
        }


        protected override CityResponse MapToResponse(City model)
        {
            return CityResponse.MapToResponse(model, _baseUrl);

        }
    }
}