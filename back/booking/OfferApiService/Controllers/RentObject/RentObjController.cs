using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObject;
using OfferApiService.Models.RentObject.Enums;
using OfferApiService.Services.Interfaces.RentObject;
using OfferApiService.View.RentObject;

namespace OfferApiService.Controllers.RentObject
{

    [ApiController]
    [Route("api/[controller]")]
    public class RentObjController : BaseController<RentObj, RentObjResponse, RentObjRequest>
    {
        public RentObjController(IRentObjService rentObjService, IRabbitMqService mqService)
    : base(rentObjService, mqService)
        {
        }

        [HttpGet("by-city")]
        public async Task<ActionResult<List<RentObjResponse>>> GetByCity([FromQuery] string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return BadRequest("City name is required");

            var rentObjs = await (_service as IRentObjService).GetByCityAsync(city);

            var response = rentObjs.Select(model => new RentObjResponse
            {
                id = model.id,
                Title = model.Title,
                Description = model.Description,
                CityId = model.CityId,
                Address = model.Address,
                ParamItems = model.ParamValues?.Select(pv => new ParamItemResponse
                {
                    id = pv.ParamItemId,
                    Title = pv.ParamItem?.Title,
                    ValueType = pv.ParamItem?.ValueType ?? ParamValueType.Boolean
                }).ToList(),


                Images = model.Images?.Select(img => img.Url).ToList() ?? new List<string>()
            }).ToList();

            return Ok(response);
        }



        protected RentObj MapToModel(RentObjRequest request)
        {
            return new RentObj
            {
                id = request.id,
                Title = request.Title,
                Description = request.Description,
                CityId = request.CityId,
                Address = request.Address,

                RoomCount = request.RoomCount,
                BathroomCount = request.BathroomCount,
                Area = request.Area,
                Floor = request.Floor,
                TotalFloors = request.TotalFloors,
                RentObjType = request.RentObjType,

                Latitude = request.Latitude,
                Longitude = request.Longitude,

                BedroomsCount = request.BedroomsCount,
                BedsCount = request.BedsCount,
                HasBabyCrib = request.HasBabyCrib,

                ParamValues = request.ParamItems?.Select(p => new RentObjParamValue
                {
                    ParamItemId = p.id,
                    ValueBool = p.ValueType == ParamValueType.Boolean ? p.ValueBool : null,
                    ValueInt = p.ValueType == ParamValueType.Integer ? p.ValueInt : null,
                    ValueString = p.ValueType == ParamValueType.String ? p.ValueString : null
                }).ToList() ?? new List<RentObjParamValue>(),


                Images = request.Images?.Select(url => new RentObjImage { Url = url }).ToList() ?? new List<RentObjImage>()
            };
        }


        protected RentObjResponse MapToResponse(RentObj model)
        {
            return new RentObjResponse
            {
                id = model.id,
                Title = model.Title,
                Description = model.Description,
                CityId = model.CityId,
                CityTitle = model.City?.Title,
                Address = model.Address,

                RoomCount = model.RoomCount,
                BathroomCount = model.BathroomCount,
                Area = model.Area,
                Floor = model.Floor,
                TotalFloors = model.TotalFloors,
                RentObjType = model.RentObjType,

                Latitude = model.Latitude,
                Longitude = model.Longitude,

                BedroomsCount = model.BedroomsCount,
                BedsCount = model.BedsCount,
                HasBabyCrib = model.HasBabyCrib,

                ParamItems = model.ParamValues?.Select(p => new ParamItemResponse
                {
                    id = p.ParamItemId,
                    Title = p.ParamItem?.Title,
                    ValueType = p.ParamItem?.ValueType ?? ParamValueType.Boolean
                }).ToList() ?? new List<ParamItemResponse>(),

                Images = model.Images?.Select(i => i.Url).ToList() ?? new List<string>()
            };
        }

    }
}