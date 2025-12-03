using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObject;
using OfferApiService.Models.RentObject.Enums;
using OfferApiService.Services.Interfaces.RentObject;
using OfferApiService.View.RentObject;

namespace OfferApiService.Controllers.RentObject
{

    public class RentObjController : EntityControllerBase<Models.RentObject.RentObject, RentObjResponse, RentObjRequest>
    {
        private readonly string _baseUrl;
        public RentObjController(IRentObjService rentObjService, IRabbitMqService mqService, IConfiguration configuration)
            : base(rentObjService, mqService)
        {
            _baseUrl = configuration["AppSettings:BaseUrl"];
        }

 

        protected override Models.RentObject.RentObject MapToModel(RentObjRequest request)
        {
            return new Models.RentObject.RentObject
            {
                id = request.id,
                Title = request.Title,
                Description = request.Description,
                DistrictId = request.DistrictId,
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
                    ValueString = p.ValueType == ParamValueType.String ? p.ValueString : String.Empty
                }).ToList() ?? new List<RentObjParamValue>(),


                Images = request.Images?.Select(url => new RentObjImage { Url = url }).ToList() ?? new List<RentObjImage>()
            };
        }


        protected override RentObjResponse MapToResponse(Models.RentObject.RentObject model)
        {
            return new RentObjResponse
            {
                id = model.id,
                Title = model.Title,
                Description = model.Description,
                DistrictId = model.DistrictId,
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

                Images = model.Images
                        ?.Select(i => $"{_baseUrl}/images/rentobj/{model.id}/{Path.GetFileName(i.Url)}")
                        .ToList() ?? new List<string>(),
            };
        }

    }
}