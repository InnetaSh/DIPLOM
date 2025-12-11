using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Services.Interfaces.RentObj;
using OfferApiService.View.RentObj;

namespace OfferApiService.Controllers.RentObj
{

    public class RentObjController : EntityControllerBase<RentObject, RentObjResponse, RentObjRequest>
    {
        private readonly string _baseUrl;
        public RentObjController(IRentObjService rentObjService, IRabbitMqService mqService, IConfiguration configuration )
            : base(rentObjService, mqService)
        {
            _baseUrl = configuration["AppSettings:BaseUrl"];
        }



        protected override RentObject MapToModel(RentObjRequest request)
        {

            return RentObjRequest.MapToModel(request);

        }


        protected override RentObjResponse MapToResponse(RentObject model)
        {
            return RentObjResponse.MapToResponse(model, _baseUrl);
        }

    }
}