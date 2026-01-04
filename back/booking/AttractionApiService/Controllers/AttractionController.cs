
using AttractionApiService.Models;
using AttractionApiService.Service;
using AttractionApiService.Service.Interfaces;
using AttractionApiService.View;
using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AttractionApiService.Controllers
{
    public class AttractionController : EntityControllerBase<Attraction, AttractionResponse, AttractionRequest>
    {
        private readonly string _baseUrl;
        private readonly GeocodingService _geocodingService;
        public AttractionController(
                  IAttractionService attractionService, 
                  IRabbitMqService mqService,
                  IConfiguration configuration,
                  GeocodingService geocodingService)
            : base(attractionService, mqService)
        {
            _baseUrl = configuration["AppSettings:BaseUrl"];
            _geocodingService = geocodingService;
        }


        [HttpPost]
        public override async Task<ActionResult<AttractionResponse>> Create(AttractionRequest request)
        {
            var coords = await GetCoordinatesAsync(request);

            if (coords == null)
                return BadRequest("Адрес не найден");

            var model = AttractionRequest.MapToModelWithCoords(
                request,
                coords.Value.lat,
                coords.Value.lon
            );

            var result = await _service.AddEntityGetIdAsync(model);

            if (result == -1)
                return StatusCode(500, new { message = "Error creating item" });

            PublishMqEvent("Created", model);
            model.id = result;

            return Ok(MapToResponse(model));
        }




        [HttpPut("update/{id}")]
        public override async Task<IActionResult> Update(int id, [FromBody] AttractionRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _service.ExistsEntityAsync(id);
            if (!exists)
                return NotFound(new { message = "Item not found" });

            var coords = await GetCoordinatesAsync(request);
            if (coords == null)
                return BadRequest("Адрес не найден");

            var updatedModel = AttractionRequest.MapToModelWithCoords(
                request,
                coords.Value.lat,
                coords.Value.lon
            );

            if (updatedModel.id != id)
                updatedModel.id = id;

            var existingEntity = await _service.GetEntityAsync(id);
            if (existingEntity == null)
                return NotFound(new { message = "Item not found in DB" });

            foreach (var prop in typeof(Attraction).GetProperties())
            {
                if (prop.CanWrite)
                {
                    var value = prop.GetValue(updatedModel);
                    prop.SetValue(existingEntity, value);
                }
            }

            var success = await _service.UpdateEntityAsync(existingEntity);
            if (!success)
                return StatusCode(500, new { message = "Error updating item" });

            PublishMqEvent("Updated", existingEntity);

            return Ok(new
            {
                id = existingEntity.id,
                data = MapToResponse(existingEntity)
            });
        }


        [HttpGet("near/by-distance/{latitude}/{longitude}/{distance}")]
        public  async Task<ActionResult<List<AttractionResponse>>> GetByDistance(decimal latitude,decimal longitude,
        decimal distance)
        {
            var responseList = await (_service as IAttractionService).GetAttractionsByDistanceAsync(
                latitude,
                longitude,
                distance
            );
            if (responseList == null || !responseList.Any())
                return NotFound(new { message = "No items found" });
            return Ok(responseList);
        }



        protected override Attraction MapToModel(AttractionRequest request)
        {
            return AttractionRequest.MapToModel(request);
        }


        protected override AttractionResponse MapToResponse(Attraction model)
        {
            return AttractionResponse.MapToResponse(model, _baseUrl);

        }

        private async Task<(double lat, double lon)?> GetCoordinatesAsync(AttractionRequest request)
        {
            return await _geocodingService.GetCoordinatesAsync(
                request.Street,
                request.HouseNumber,
                request.CityTitle,
                request.Postcode,
                request.CountryTitle
            );
        }

    }
}