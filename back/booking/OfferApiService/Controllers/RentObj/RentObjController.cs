using Globals.Abstractions;
using Globals.Controllers;
using Globals.Helpers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Service;
using OfferApiService.Services.Interfaces.RentObj;
using OfferApiService.View.RentObj;
using System.Diagnostics.CodeAnalysis;

namespace OfferApiService.Controllers.RentObj
{

    public class RentObjController : EntityControllerBase<RentObject, RentObjResponse, RentObjRequest>
    {
        private readonly string _baseUrl;
        private readonly GeocodingService _geocodingService;
        private readonly IRentObjService _rentObjService;

        public RentObjController(
            IRentObjService rentObjService,
            IRabbitMqService mqService,
            IConfiguration configuration,
            GeocodingService geocodingService
        )
            : base(rentObjService, mqService)
        {
            _baseUrl = configuration["AppSettings:BaseUrl"];
            _geocodingService = geocodingService;
        }



        [HttpPost]
        public override async Task<ActionResult<RentObjResponse>> Create(RentObjRequest request)
        {
            var coords = await GetCoordinatesAsync(request);

            var latitude = coords?.lat ?? 0;
            var longitude = coords?.lon ?? 0;
            if (coords == null)
            {
                Console.WriteLine("Адрес не найден");
            }
            request.Latitude = latitude;
            request.Longitude = longitude;

            double cityLatitude  = request.CityLatitude ?? 0;
            double cityLongitude = request.CityLongitude ?? 0;
            request.DistanceToCenter = (int)Helper.CalculateDistanceMeters(latitude, longitude, cityLatitude, cityLongitude);

            var model = RentObjRequest.MapToModel(request);

            var result = await _service.AddEntityGetIdAsync(model);

            if (result == -1)
                return StatusCode(500, new { message = "Error creating item" });

            PublishMqEvent("Created", model);
            model.id = result;

            return Ok(MapToResponse(model));
        }



        [HttpPut("update/{id}")]
        public override async Task<IActionResult> Update(int id, [FromBody] RentObjRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingRentObj= await _service.GetEntityAsync(id);
            if (existingRentObj == null)
                return NotFound(new { message = "Item not found" });

            var coords = await GetCoordinatesAsync(request);

            var latitude = coords?.lat ?? 0;
            var longitude = coords?.lon ?? 0;
            if (coords == null)
            {
                Console.WriteLine("Адрес не найден");
            }
            request.Latitude = latitude;
            request.Longitude = longitude;

            double cityLatitude = request.CityLatitude ?? 0;
            double cityLongitude = request.CityLongitude ?? 0;
            request.DistanceToCenter = (int)Helper.CalculateDistanceMeters(latitude, longitude, cityLatitude, cityLongitude);

            
            PatchHelper.ApplyPatch<RentObject, RentObjRequest>(
                existingRentObj,
                request,
                nameof(RentObject.id)
            );

            //var existingEntity = await _service.GetEntityAsync(id);
            //if (existingEntity == null)
            //    return NotFound(new { message = "Item not found in DB" });

            //foreach (var prop in typeof(RentObject).GetProperties())
            //{
            //    if (prop.CanWrite)
            //    {
            //        var value = prop.GetValue(updatedModel);
            //        prop.SetValue(existingEntity, value);
            //    }
            //}

            var success = await _service.UpdateEntityAsync(existingRentObj);
            if (!success)
                return StatusCode(500, new { message = "Error updating item" });

            PublishMqEvent("Updated", existingRentObj);

            var rentObjResponse = RentObjResponse.MapToResponse(existingRentObj, _baseUrl);
            if (rentObjResponse == null)
                return NotFound(new { message = "Item not found after update" });

            return Ok(rentObjResponse);
        }


      
        protected override RentObject MapToModel(RentObjRequest request)
        {
            var rentObject = RentObjRequest.MapToModel(
                request
            );
            return rentObject;

        }


        protected override RentObjResponse MapToResponse(RentObject model)
        {
            return RentObjResponse.MapToResponse(model, _baseUrl);
        }


        private async Task<(double lat, double lon)?> GetCoordinatesAsync(RentObjRequest request)
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