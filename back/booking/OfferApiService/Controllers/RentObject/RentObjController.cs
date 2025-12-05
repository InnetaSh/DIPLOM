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
        private IRentObjService _service;
        private readonly IRentObjParamValueService _paramValueService;
        public RentObjController(IRentObjService rentObjService, IRabbitMqService mqService, IConfiguration configuration, IRentObjParamValueService paramValueService)
            : base(rentObjService, mqService)
        {
            _baseUrl = configuration["AppSettings:BaseUrl"];
            _service = rentObjService;
            _paramValueService = paramValueService;
        }



        protected override Models.RentObject.RentObject MapToModel(RentObjRequest request)
        {
           
            return new Models.RentObject.RentObject
            {
                id = request.id,
                Title = request.Title,
                Description = request.Description,
                CountryId = request.CountryId,
                RegionId = request.RegionId,
                CityId = request.CityId,
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

                ParamValues = request.ParamValues?.Select(p => new RentObjParamValue
                {
                    id = p.id,
                    ParamItemId = p.ParamItemId,
                    ValueBool =  p.ValueBool ,
                    ValueInt =  p.ValueInt ,
                    ValueString =  p.ValueString,
                }).ToList() ?? new List<RentObjParamValue>(),

                Images = request.Images?.Select(url => new RentObjImage { Url = url }).ToList() ?? new List<RentObjImage>()
            };
        }


        protected override RentObjResponse MapToResponse(Models.RentObject.RentObject model)
        {
            return RentObjResponse.MapToResponse(model, _paramValueService, _baseUrl);

            //return new RentObjResponse
            //{
            //    id = model.id,
            //    Title = model.Title,
            //    Description = model.Description,
            //    CountryId = model.CountryId,
            //    RegionId = model.RegionId,
            //    CityId= model.CityId,
            //    DistrictId = model.DistrictId,
            //    Address = model.Address,

            //    RoomCount = model.RoomCount,
            //    BathroomCount = model.BathroomCount,
            //    Area = model.Area,
            //    Floor = model.Floor,
            //    TotalFloors = model.TotalFloors,
            //    RentObjType = model.RentObjType,

            //    Latitude = model.Latitude,
            //    Longitude = model.Longitude,

            //    BedroomsCount = model.BedroomsCount,
            //    BedsCount = model.BedsCount,
            //    HasBabyCrib = model.HasBabyCrib,

            //    ParamValues = model.ParamValues?.Select(p => new RentObjParamValueResponse
            //    {
            //        id = p.id,
            //        ParamItemId = p.ParamItemId,
            //        ParamItemTitle = _service.GetTitleParamItem(p.ParamItemId).Result,
            //        ValueBool = p.ValueBool,
            //        ValueInt = p.ValueInt,
            //        ValueString = p.ValueString,
            //    })?.ToList() ?? new List<RentObjParamValueResponse>(),

          
            //    Images = model.Images
            //            ?.Select(i => $"{_baseUrl}/images/rentobj/{model.id}/{Path.GetFileName(i.Url)}")
            //            .ToList() ?? new List<string>(),
            //};
        }

    }
}