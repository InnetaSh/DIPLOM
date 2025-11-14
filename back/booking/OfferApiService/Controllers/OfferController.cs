using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models;
using OfferApiService.Service.Interface;
using OfferApiService.View;

namespace OfferApiService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OfferController
        : BaseController<Offer, OfferResponse, OfferRequest>
    {
        public OfferController(IOfferService offerService, IRabbitMqService mqService)
            : base(offerService, mqService) 
        { 
        }

        protected override Offer MapToModel(OfferRequest request)
        {
            return new Offer
            {
                Title = request.Title,
                Description = request.Description,
                PricePerDay = request.PricePerDay,
                OwnerId = request.OwnerId,
                RentObjId = request.RentObjId
            };
        }

        protected override OfferResponse MapToResponse(Offer model)
        {
            return new OfferResponse
            {
                id = model.id,
                Title = model.Title,
                Description = model.Description,
                PricePerDay = model.PricePerDay,
                OwnerId = model.OwnerId,
                RentObjId = model.RentObjId,
                BookedDates = model.BookedDates
            };
        }
    }

}
