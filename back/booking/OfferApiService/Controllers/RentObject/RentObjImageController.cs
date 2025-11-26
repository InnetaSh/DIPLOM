using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObject;
using OfferApiService.Services.Interfaces.RentObject;
using OfferApiService.View.RentObject;

namespace OfferApiService.Controllers.RentObject
{

    public class RentObjImageController : EntityControllerBase<RentObjImage, RentObjImageResponse, RentObjImageRequest>
    {
        public RentObjImageController(IRentObjImageService rentObjImageService, IRabbitMqService mqService)
    : base(rentObjImageService, mqService)
        {
        }


        protected RentObjImage MapToModel(RentObjImageRequest request)
        {
            return new RentObjImage
            {
                id = request.id,
                Url = request.Url,
                RentObjId = request.RentObjId
            };
        }

        protected RentObjImageResponse MapToResponse(RentObjImage model)
        {
            return new RentObjImageResponse
            {
                id = model.id,
                Url = model.Url,
                RentObjId = model.RentObjId
            };
        }


    }
}