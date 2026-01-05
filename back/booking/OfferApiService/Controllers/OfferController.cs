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

        //===========================================================================================
        [HttpPost("{offerId}/orders/add/{orderId}")]
        public async Task<ActionResult> AddOrderLinkToOffer(
            int offerId, 
            int orderId)
        {
            var result = await _offerService.AddOrderLinkToOffer(offerId, orderId);

            if (!result)
                return BadRequest("Не удалось добавить заказ для обьявления");

            return Ok(new { message = "Заказ добавлен" });
        }


        //===========================================================================================

        [HttpGet("search/offers")]
        public async Task<ActionResult<List<OfferShortResponse>>> GetSearchOffers(
            [FromQuery] OfferSearchRequestByCityAndCountGuest request,
            [FromQuery] decimal userDiscountPercent)
        {

            if (request.StartDate >= request.EndDate)
                throw new ArgumentException("Invalid date range");

            var offers = await _offerService.SearchOffersAsync(request);

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



        //===========================================================================================

        [HttpGet("{offerId}/get/orders/id")]
        public async Task<ActionResult<List<int>>> GetOrdersIdLinkToOffer(
            int offerId)
        {
            var ordersIdList = await _offerService.GetOrdersIdLinkToOffer(offerId);
            return Ok(ordersIdList);
        }

            //===========================================================================================
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
   

            var response = OfferResponse.MapToResponse(
                offer,
                _baseUrl);

            response.GuestCount = request.Guests;
            decimal? orderPrice;
            if (daysCount < 7)
                orderPrice = daysCount * response.PricePerDay;
            else if (daysCount < 30)
               orderPrice = daysCount * response.PricePerWeek;
            else
                orderPrice = daysCount * response.PricePerMonth;

            response.OrderPrice = orderPrice;
           // Расчёт цен

            var discountPercent = userDiscountPercent;
            var discountAmount = orderPrice * discountPercent / 100;
            var depositAmount = response.DepositPersent.HasValue ? orderPrice * response.DepositPersent.Value / 100 : 0;

            // Налог на аренду
            var taxAmount = (response.OrderPrice - discountAmount) * response.Tax / 100;
            response.TaxAmount = (decimal)taxAmount;
            response.GuestCount = request.Guests;
            response.DaysCount = daysCount;

            var totalPrice = orderPrice - discountAmount + depositAmount + taxAmount;



            response.OrderPrice = orderPrice;
            response.DiscountPercent = discountPercent;
            response.DiscountAmount = discountAmount;
            response.DepositAmount = depositAmount;
            response.TaxAmount = taxAmount;
            response.TotalPrice = totalPrice;

       
            return Ok(response);
        }


        //===========================================================================================
        [HttpGet("get/offers/{ownerId}")]
        public async Task<ActionResult<OfferResponse>> GetOfferById(
        int ownerId)
        {

            var offerList = await _offerService.GetOffersByOwnerIdAsync(ownerId);



            if (offerList.Count() == 0)
                return NotFound();

            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var responseList = new List<OfferResponse>();
            foreach (var offer in offerList)
            {
                var response = OfferResponse.MapToResponse(
                offer,
                baseUrl);
                responseList.Add(response);
            }

            return Ok(responseList);
        }


        //===========================================================================================
        [HttpGet("get/offers/{ownerId}/{cityId}")]
        public async Task<ActionResult<OfferResponse>> GetOfferByIdAndCity(
        int ownerId,
        int cityId)
        {

            var offerList = await _offerService.GetOffersByOwnerIdAndCityAsync(ownerId, cityId);

            if (offerList.Count() == 0)
                return NotFound();

            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var responseList = new List<OfferResponse>();
            foreach (var offer in offerList)
            {
                var response = OfferResponse.MapToResponse(
                offer,
                baseUrl);
                responseList.Add(response);
            }
           
            return Ok(responseList);
        }


        //===========================================================================================
        [HttpGet("get/offers/{ownerId}/{countryId}")]
        public async Task<ActionResult<OfferResponse>> GetOfferByIdAndCountry(
        int ownerId,
        int countryId)
        {

            var offerList = await _offerService.GetOffersByOwnerIdAndCountryAsync(ownerId, countryId);

            if (offerList.Count() == 0)
                return NotFound();

            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var responseList = new List<OfferResponse>();
            foreach (var offer in offerList)
            {
                var response = OfferResponse.MapToResponse(
                offer,
                baseUrl);
                responseList.Add(response);
            }

            return Ok(responseList);
        }

        //===========================================================================================
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
