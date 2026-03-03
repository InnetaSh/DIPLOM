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
            //_baseUrl = configuration["AppSettings:BaseUrl"];

            _baseUrl = $"{configuration["HostUrl"] ?? "http://localhost"}:5001";
        }

        //===========================================================================================
        //  получение городов для списка популярных 
        //===========================================================================================

        [HttpPost("search/cities/populars")]
        public async Task<ActionResult<List<CityResponseForPupularList>>> GetSearchPopularCities(
          [FromBody] List<int> idList)
        {


            var result = new List<CityResponseForPupularList>();
            foreach (var cityId in idList)
            {
                var exists = await _cityService.ExistsEntityAsync(cityId);
                if (!exists)
                    continue;

                var cityRez = await _cityService.GetEntityAsync(cityId);
                var city = CityResponseForPupularList.MapToResponse(cityRez, _baseUrl);
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