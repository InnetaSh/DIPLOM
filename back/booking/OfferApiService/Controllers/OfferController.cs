using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models;
using OfferApiService.Models.Dto;
using OfferApiService.Models.View;
using OfferApiService.Service.Interface;
using OfferApiService.View;

namespace OfferApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferController
        : BaseController<Offer, OfferResponse, OfferRequest>
    {
        private IOfferService _offerService;
        public OfferController(IOfferService offerService, IRabbitMqService mqService)
            : base(offerService, mqService)
        {
            _offerService = offerService;
        }


        [HttpGet("by-mainparams")]
        public async Task<ActionResult<List<RentObjResponse>>> GetMainSearch([FromQuery] string city, DateTime start, DateTime end, int bedroomsCount)
        {
            if (string.IsNullOrWhiteSpace(city))
                return BadRequest("City name is required");

            var rentObjs = await _offerService.GetMainAvailableOffers(city, start, end, bedroomsCount);

            var response = new List<RentObjResponse>();

            return Ok(response);
        }

        protected Offer MapToModel(OfferRequest request)
        {
            return new Offer
            {
                id = request.id,
                Title = request.Title,
                Description = request.Description,
                PricePerDay = request.PricePerDay,
                PricePerWeek = request.PricePerWeek,
                PricePerMonth = request.PricePerMonth,
                Deposit = request.Deposit,
                PaymentStatus = request.PaymentStatus,
                Tax = request.Tax,
                MinRentDays = request.MinRentDays,
                AllowPets = request.AllowPets,
                AllowSmoking = request.AllowSmoking,
                AllowChildren = request.AllowChildren,
                CheckInTime = request.CheckInTime ?? new TimeSpan(15, 0, 0),
                CheckOutTime = request.CheckOutTime ?? new TimeSpan(11, 0, 0),
                OwnerId = request.OwnerId,
                RentObjId = request.RentObjId
            };
        }


        protected OfferResponse MapToResponse(Offer model)
        {
            return new OfferResponse
            {
                id = model.id,
                Title = model.Title,
                Description = model.Description,
                PricePerDay = model.PricePerDay,
                PricePerWeek = model.PricePerWeek,
                PricePerMonth = model.PricePerMonth,
                Deposit = model.Deposit,
                PaymentStatus = model.PaymentStatus,
                Tax = model.Tax,
                MinRentDays = model.MinRentDays,
                AllowPets = model.AllowPets,
                AllowSmoking = model.AllowSmoking,
                AllowChildren = model.AllowChildren,
                CheckInTime = model.CheckInTime,
                CheckOutTime = model.CheckOutTime,
                OwnerId = model.OwnerId,
                RentObjId = model.RentObjId,
                BookedDates = model.BookedDates?.Select(bd => new BookedDateResponse
                {
                    id = bd.id,
                    Start = bd.Start,
                    End = bd.End,
                    OfferId = bd.OfferId
                }).ToList() ?? new List<BookedDateResponse>()
            };
        }

    }
}
