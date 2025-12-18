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
    public class BookedDateController
        : EntityControllerBase<BookedDate, BookedDateResponse, BookedDateRequest>
    {
        public BookedDateController(IBookedDateService bookedDateService, IRabbitMqService mqService)
            : base(bookedDateService, mqService) 
        { 
        }


        //=============================================================================
        protected override BookedDate MapToModel(BookedDateRequest request)
        {
            return new BookedDate
            {
                id = request.id,
                Start = request.Start,
                End = request.End,
                OfferId = request.OfferId
            };
        }

        //=============================================================================
        protected override BookedDateResponse MapToResponse(BookedDate model)
        {
            return new BookedDateResponse
            {
                id = model.id,
                Start = model.Start,
                End = model.End,
                OfferId = model.OfferId
            };
        }

    }

}
