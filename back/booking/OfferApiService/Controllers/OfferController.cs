using Globals.Abstractions;
using Globals.Controllers;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models;
using OfferApiService.Models.Dto;
using OfferApiService.Models.View;
using OfferApiService.Service.Interface;
using OfferApiService.Services.Interfaces.RentObj;
using OfferApiService.View;

namespace OfferApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferController
        : EntityControllerBase<Offer, OfferResponse, OfferRequest>
    {
        private IOfferService _offerService;
        private readonly string _baseUrl;
        private readonly IRentObjParamValueService _paramValueService;

        public OfferController(IOfferService offerService, IRabbitMqService mqService, IConfiguration configuration, IRentObjParamValueService paramValueService)
            : base(offerService, mqService)
        {
            _offerService = offerService;
            _baseUrl = configuration["AppSettings:BaseUrl"];
            _paramValueService = paramValueService;
        }


        [HttpGet("search/main")]
        public async Task<ActionResult<List<OfferShortResponse>>> GetMainSearch(
            [FromQuery] OfferMainSearchRequest request,
            [FromQuery] decimal userDiscountPercent)
        {
            var offers = await _offerService.SearchAvailableOffersAsync(request);

            //var baseUrl = $"{Request.Scheme}://{Request.Host}";

            var result = offers.Select(o => OfferShortResponse.MapToShortResponse(o, _baseUrl)).ToList();
            foreach (var o in result)
            {
                o.GuestCount = request.Guests;

                DateTime startDate = request.StartDate;
                DateTime endDate = request.EndDate;
                TimeSpan difference = endDate - startDate;
                int daysCount = difference.Days;
                o.DaysCount = daysCount;

                if (daysCount < 7)
                    o.OrderPrice = daysCount * o.PricePerDay;
                else if (daysCount < 30)
                    o.OrderPrice = daysCount * (o.PricePerWeek / 7);
                else
                    o.OrderPrice = daysCount * (o.PricePerMonth / 30);



                // Скидка
                var discountPercent = userDiscountPercent;
                var discountAmount = o.OrderPrice * discountPercent / 100;


                // Налог на аренду
                var taxAmount = (o.OrderPrice - discountAmount) * o.Tax / 100;
                o.TaxAmount = (decimal)taxAmount;
                // Итоговая стоимость
               o.TotalPrice = (o.OrderPrice - discountAmount) + taxAmount;

            }


            return Ok(result);
        }


        [HttpGet("get-offer/{id}")]
        public async Task<ActionResult<OfferResponse>> GetOfferById(
            int id,
             [FromQuery] OfferByIdRequest request,
            [FromQuery] decimal userDiscountPercent)
        {

            var offer = await _offerService.GetEntityAsync(id);

           

            DateTime startDate = request.StartDate;
            DateTime endDate = request.EndDate;
            TimeSpan difference = endDate - startDate;
            int daysCount = difference.Days;

            if (offer == null)
                return NotFound();

            //var baseUrl = $"{Request.Scheme}://{Request.Host}";
   

            var fullResponse = OfferResponse.MapToFullResponse(
                offer,
                userDiscountPercent,
                 daysCount,
                _baseUrl);

            fullResponse.GuestCount = request.Guests;
            if (daysCount < 7)
                fullResponse.OrderPrice = daysCount * fullResponse.PricePerDay;
            else if (daysCount < 30)
                fullResponse.OrderPrice = daysCount * (fullResponse.PricePerWeek / 7);
            else
                fullResponse.OrderPrice = daysCount * (fullResponse.PricePerMonth / 30);


            // Скидка
            var discountPercent = userDiscountPercent;
            var discountAmount = fullResponse.OrderPrice * discountPercent / 100;


            // Налог на аренду
            var taxAmount = (fullResponse.OrderPrice - discountAmount) * fullResponse.Tax / 100;
            fullResponse.TaxAmount = (decimal)taxAmount;
            fullResponse.GuestCount = request.Guests;
            fullResponse.DaysCount = daysCount;
            // Итоговая стоимость
            //fullResponse.TotalPrice = fullResponse.OrderPrice - discountAmount + taxAmount;


            return Ok(fullResponse);
        }





        protected override Offer MapToModel(OfferRequest request)
        {
            return  OfferRequest.MapToModel(request);
        }


        protected override OfferResponse MapToResponse(Offer model)
        {
            return OfferResponse.MapToResponse(model,_baseUrl);

        }

    }
}
