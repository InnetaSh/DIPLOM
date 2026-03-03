using Globals.Abstractions;
using Globals.Controllers;
using Globals.Helpers;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Models.View;
using OfferApiService.Service;
using OfferApiService.Service.Interface;
using OfferApiService.Services.Interfaces.RentObj;
using OfferApiService.View;
using OfferApiService.View.RentObj;

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
        private readonly IRentObjService _rentObjService;
        private readonly GeocodingService _geocodingService;

        public OfferController(IOfferService offerService,
            IRabbitMqService mqService,
            IConfiguration configuration,
            IRentObjParamValueService paramValueService,
            IRentObjService rentObjService,
             GeocodingService geocodingService)
            : base(offerService, mqService)
        {
            _offerService = offerService;
            //_baseUrl = configuration["AppSettings:BaseUrl"];
            _baseUrl = $"{configuration["HostUrl"] ?? "http://localhost"}:5003";
            _paramValueService = paramValueService;
            _rentObjService = rentObjService;
            _geocodingService = geocodingService;
        }

        //===========================================================================================
        //  добавление ссылки на заказ в обьявление
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
        //  получение обьявлений по параметрам поиска
        //===========================================================================================

        [HttpGet("search/all")]
        public async Task<ActionResult<List<OfferShortResponse>>> GetAllOffers()
        {

            var offers = await _offerService.GetEntitiesAsync();


            var result = offers.Select(o => OfferShortResponse.MapToShortResponse(o, _baseUrl)).ToList();
            
            return Ok(result);
        }

        //===========================================================================================
        //  получение обьявлений по параметрам поиска
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
            //foreach (var o in result)
            //{
            //    o.GuestCount = request.Guests;

            //    DateTime startDate = request.StartDate;
            //    DateTime endDate = request.EndDate;
            //    TimeSpan difference = endDate - startDate;
            //    int daysCount = difference.Days;
            //    o.DaysCount = daysCount;

            //    if (daysCount < 7)
            //        o.OrderPrice = daysCount * o.PricePerDay;
            //    else if (daysCount < 30)
            //        o.OrderPrice = daysCount * (o.PricePerWeek / 7);
            //    else
            //        o.OrderPrice = daysCount * (o.PricePerMonth / 30);



            //    // Скидка
            //    var discountPercent = userDiscountPercent;
            //    var discountAmount = o.OrderPrice * discountPercent / 100;


            //    // Налог на аренду
            //    var taxAmount = (o.OrderPrice - discountAmount) * o.Tax / 100;
            //    o.TaxAmount = (decimal)taxAmount;
            //    // Итоговая стоимость
            //   o.TotalPrice = (o.OrderPrice - discountAmount) + taxAmount;

            //}


            return Ok(result);
        }


        //===========================================================================================
        //  получение обьявлений по региону и параметрам поиска
        //===========================================================================================

        [HttpGet("search/offers/fromRegion")]
        public async Task<ActionResult<List<OfferShortResponse>>> GetSearchOffersFromRegion(
            [FromQuery] OfferSearchRequestByRegionAndCountGuest request,
            [FromQuery] decimal userDiscountPercent)
        {

            if (request.StartDate >= request.EndDate)
                throw new ArgumentException("Invalid date range");

            var offers = await _offerService.SearchOffersFromRegion(request);

            //var baseUrl = $"{Request.Scheme}://{Request.Host}";

            var result = offers.Select(o => OfferShortResponse.MapToShortResponse(o, _baseUrl)).ToList();
           
            return Ok(result);
        }


        //===========================================================================================
        //  получение обьявлений по стране и параметрам поиска
        //===========================================================================================

        [HttpGet("search/offers/fromCountry")]
        public async Task<ActionResult<List<OfferShortResponse>>> GetSearchOffersFromCountry(
            [FromQuery] OfferSearchRequestByCountryAndCountGuest request,
            [FromQuery] decimal userDiscountPercent)
        {

            if (request.StartDate >= request.EndDate)
                throw new ArgumentException("Invalid date range");

            var offers = await _offerService.SearchOffersFromCountry(request);

            //var baseUrl = $"{Request.Scheme}://{Request.Host}";

            var result = offers.Select(o => OfferShortResponse.MapToShortResponse(o, _baseUrl)).ToList();

            return Ok(result);
        }




        //===========================================================================================
        //  получение обьявлений для списка популярных обьявлений
        //===========================================================================================

        [HttpPost("search/offers/populars")]
        public async Task<ActionResult<List<OfferShortPopularResponse>>> GetSearchPopularOffers(
            [FromBody] List<int> idList)
        {

            
            var result = new List<OfferShortPopularResponse>();
            foreach (var offerId in idList)
            {
                var exists = await _offerService.ExistsEntityAsync(offerId);
                if (!exists)
                    continue;

                var offerRez = await _offerService.GetEntityAsync(offerId);
                var offer =OfferShortPopularResponse.MapToResponse(offerRez, _baseUrl);
                result.Add(offer);
            }
           
            return Ok(result);
        }


        //===========================================================================================
        //  получение id заказов связанных с обьявлением
        //===========================================================================================

        [HttpGet("{offerId}/get/orders")]
        public async Task<ActionResult<List<int>>> GetOrdersIdLinkToOffer(
            int offerId)
        {
            var ordersIdList = await _offerService.GetOrdersIdLinkToOffer(offerId);
            return Ok(ordersIdList);
        }

        //===========================================================================================
        // получение обьявления по id с расчётом цены по параметрам запроса
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
          
            // Налог на аренду
            //var taxAmount = (response.OrderPrice - discountAmount) * response.Tax / 100;
            //response.TaxAmount = (decimal)taxAmount;
             //response.GuestCount = request.Adults+request.Children;
            response.Adults = request.Adults;
            response.Children = request.Children;
            response.DaysCount = daysCount;

            var totalPrice = orderPrice - discountAmount;



            response.OrderPrice = orderPrice;
            response.DiscountPercent = discountPercent;
            response.DiscountAmount = discountAmount;
           // response.TaxAmount = taxAmount;
            response.TotalPrice = totalPrice;

       
            return Ok(response);
        }



        //===========================================================================================
        // создание обьявления с обьектом оренды с параметрами
        //===========================================================================================

        [HttpPost("create/offer-with-rentobj-with-param-values")]
        public async Task<ActionResult<OfferResponse>> CreateOffer(
         [FromBody] OfferRequest Offer
            )
        {
            var offerRequest = Offer;
            var rentObjRequest = Offer.RentObj;

            var coords = await GetCoordinatesAsync(rentObjRequest);

            var latitude = coords?.lat ?? 0;
            var longitude = coords?.lon ?? 0;
            if (coords == null)
            {
                Console.WriteLine("Адрес не найден");
            }

            rentObjRequest.Latitude = latitude;
            rentObjRequest.Longitude = longitude;
            double cityLatitude = rentObjRequest.CityLatitude ?? 0;
            double cityLongitude = rentObjRequest.CityLongitude ?? 0;
            rentObjRequest.DistanceToCenter = (int)Helper.CalculateDistanceMeters(latitude, longitude, cityLatitude, cityLongitude);

            if (rentObjRequest.DistanceToCenter < 1000)
            {
                rentObjRequest.ParamValues.Add(new RentObjParamValueRequest
                {
                    ParamItemId = 26,
                    ValueBool = true
                });
            }
            else if (rentObjRequest.DistanceToCenter < 3000)
            {
                rentObjRequest.ParamValues.Add(new RentObjParamValueRequest
                {
                    ParamItemId = 27, // "Менше 3 км" 
                    ValueBool = true
                });
            }
            else if (rentObjRequest.DistanceToCenter < 5000)
            {
                rentObjRequest.ParamValues.Add(new RentObjParamValueRequest
                {
                    RentObjId = rentObjRequest.id,
                    ParamItemId = 28, // "Менше 5 км" 
                    ValueBool = true
                });
            }

            rentObjRequest.DistanceToCenter = (int)(rentObjRequest.DistanceToCenter);


            var rentObjModel = RentObjRequest.MapToModel(rentObjRequest);

            //var idRentObj = await _rentObjService.AddRentObjWithParamValuesAsync(rentObjModel);

            //if (idRentObj == -1)
            //    return StatusCode(500, new { message = "Error creating item" });

            //offerRequest.RentObjId = idRentObj;
            //var modelOffer = OfferRequest.MapToModel(offerRequest);

            offerRequest.RentObj = rentObjRequest;
            var modelOffer = OfferRequest.MapToModel(offerRequest,_baseUrl);

            var idOffer = await _offerService.AddOfferWithRentObjAndParamValuesAsync(modelOffer);
            if (idOffer == -1)
                return StatusCode(500, new { message = "Error creating item" });

            return Ok(new { idOffer });
        }

        //===========================================================================================
        // редактирование обьявления с обьектом оренды с параметрами
        //===========================================================================================

        [HttpPut("update/offer-with-rentobj-with-param-values")]
        public async Task<ActionResult<OfferResponse>> UpdateOffer(
         [FromBody] OfferRequest Offer
            )
        {
            var offerId = Offer.id;
            var rentObjId = Offer.RentObj.id;
            var offerRequest = Offer;
            var rentObjRequest = Offer.RentObj;



            var existingRentObj = await _rentObjService.GetEntityAsync(rentObjId);
            if (existingRentObj == null)
                return NotFound(new { message = "Item not found" });

            var coords = await GetCoordinatesAsync(rentObjRequest);

            var latitude = coords?.lat ?? 0;
            var longitude = coords?.lon ?? 0;
            if (coords == null)
            {
                Console.WriteLine("Адрес не найден");
            }
            rentObjRequest.Latitude = latitude;
            rentObjRequest.Longitude = longitude;

            double cityLatitude = rentObjRequest.CityLatitude ?? 0;
            double cityLongitude = rentObjRequest.CityLongitude ?? 0;
            rentObjRequest.DistanceToCenter = (int)Helper.CalculateDistanceMeters(latitude, longitude, cityLatitude, cityLongitude);


            //PatchHelper.ApplyPatch<RentObject, RentObjRequest>(
            //     existingRentObj,
            //     rentObjRequest,
            //     nameof(RentObject.id),
            //     nameof(RentObject.Images)
            // );

            // var success = await _rentObjService.UpdateEntityAsync(existingRentObj);
            // if (!success)
            //     return StatusCode(500, new { message = "Error updating item" });


            // var existingOffer = await _offerService.GetOnlyOfferAsync(offerId);
            // if (existingOffer == null)
            //     return NotFound(new { message = "offer not found" });

            // PatchHelper.ApplyPatch<Offer, OfferRequest>(
            //    existingOffer,
            //    offerRequest,
            //    nameof(Offer.id),
            //    nameof(Offer.OwnerId)
            //    //nameof(Offer.RentObjId)
            //);

            // var offerUpdated = await _offerService.UpdateEntityAsync(existingOffer);
            // if (!offerUpdated)
            //     return StatusCode(500, new { message = "Error updating offer" });

            

            var modelOffer = OfferRequest.MapToModel(offerRequest,_baseUrl);
            var offerUpdId = await _offerService
                .UpdateOfferWithRentObjAndParamValuesAsyn(modelOffer);
            return Ok(MapToResponse( modelOffer));
        }


        //==========================================================================================
        //       заблокировать обьявление
        //==========================================================================================


        [HttpPut("block/booking-offer/{offerId}")]
        public async Task<ActionResult> BlockOffer(int offerId)
        {
            var existOffer = await _offerService.ExistsEntityAsync(offerId);
            if (!existOffer)
                return NotFound(new { message = "offer not found" });

            var existingOffer = await _offerService.GetEntityAsync(offerId);
            if (existingOffer == null)
                return NotFound(new { message = "Item not found in DB" });

            existingOffer.IsBlocked = true;
            var successOffer = await _offerService.UpdateEntityAsync(existingOffer);

            if (!successOffer)
                return StatusCode(500, new { message = "Error updating offer" });
            
            return Ok(new { message = "Offer blocked successfully" });
        }


        //==========================================================================================
        //       разблокировать обьявление
        //==========================================================================================


        [HttpPut("unblock/booking-offer/{offerId}")]
        public async Task<ActionResult> UnBlockOffer(int offerId)
        {
            var existOffer = await _offerService.ExistsEntityAsync(offerId);
            if (!existOffer)
                return NotFound(new { message = "offer not found" });

            var existingOffer = await _offerService.GetEntityAsync(offerId);
            if (existingOffer == null)
                return NotFound(new { message = "Item not found in DB" });

            existingOffer.IsBlocked = false;
            var successOffer = await _offerService.UpdateEntityAsync(existingOffer);

            if (!successOffer)
                return StatusCode(500, new { message = "Error updating offer" });

            return Ok(new { message = "Offer blocked successfully" });
        }



        //===========================================================================================
        // редактирование цены обьявления
        //===========================================================================================

        [HttpPut("update/price/booking-offer/{offerId}")]
        public async Task<ActionResult<OfferResponse>> UpdateOfferPrice(int offerId,
         [FromBody] UpdateOfferPriceRequest updateOfferPriceRequest
            )
        {
           
            var existOffer = await _offerService.ExistsEntityAsync(offerId);
            if (!existOffer)
                return NotFound(new { message = "offer not found" });

            var existingOffer = await _offerService.GetEntityAsync(offerId);
            if (existingOffer == null)
                return NotFound(new { message = "Item not found in DB" });

            PatchHelper.ApplyPatch(
               existingOffer,
               updateOfferPriceRequest,
               nameof(Offer.id),
               nameof(Offer.OwnerId)
               //nameof(Offer.RentObjId)
           );

            var successOffer = await _offerService.UpdateEntityAsync(existingOffer);
            if (!successOffer)
                return StatusCode(500, new { message = "Error updating offer" });


            return Ok(new { offerId });
        }


        //===========================================================================================
        //    получение id обьекта оренды по обьявлений
        //===========================================================================================
        [HttpGet("get/rentobjid/{offerId}")]
        public async Task<ActionResult<int>> GetRentObjIdByOfferId(
        int offerId)
        {
            var existOffer = await _offerService.ExistsEntityAsync(offerId);
            if (!existOffer)
                return NotFound(new { message = "offer not found" });

            var existingOffer = await _offerService.GetEntityAsync(offerId);
            if (existingOffer == null)
                return NotFound(new { message = "offer not found in DB" });


            return Ok(existingOffer.RentObj.id);
        
        }


        //===========================================================================================
        //  получение обьявлений по id владельца
        //===========================================================================================

        [HttpGet("get/offersByOwner/{ownerId}")]
        public async Task<ActionResult<OfferResponse>> GetOfferByOwnerId(
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
                _baseUrl);
                responseList.Add(response);
            }

            return Ok(responseList);
        }

        //[HttpGet("get/offers/{ids}")]
        //public async Task<ActionResult<OfferResponse>> GetOfferById(
        //int ownerId)
        //{

        //    var offerList = await _offerService.GetOffersByIdAsync(ownerId);

        //    if (offerList.Count() == 0)
        //        return NotFound();

        //    var baseUrl = $"{Request.Scheme}://{Request.Host}";
        //    var responseList = new List<OfferResponse>();
        //    foreach (var offer in offerList)
        //    {
        //        var response = OfferResponse.MapToResponse(
        //        offer,
        //        _baseUrl);
        //        responseList.Add(response);
        //    }

        //    return Ok(responseList);
        //}

        //===========================================================================================
        //  получение обьявлений по id владельца и городу
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
                _baseUrl);
                responseList.Add(response);
            }
           
            return Ok(responseList);
        }


        //===========================================================================================
        //  получение обьявлений по id владельца и стране
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
                _baseUrl);
                responseList.Add(response);
            }

            return Ok(responseList);
        }

        //===========================================================================================
        protected override Offer MapToModel(OfferRequest request)
        {
            return  OfferRequest.MapToModel(request, _baseUrl);
        }


        protected override OfferResponse MapToResponse(Offer model)
        {
            return OfferResponse.MapToResponse(model,_baseUrl);

        }

        private async Task<(double lat, double lon)?> GetCoordinatesAsync(RentObjRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.Street) &&
            !string.IsNullOrWhiteSpace(request.CityTitle) &&
            !string.IsNullOrWhiteSpace(request.CountryTitle))
                    {
                var coords = await _geocodingService.GetCoordinatesAsync(
                    request.Street,
                    request.HouseNumber ?? "",
                    request.CityTitle,
                    request.Postcode ?? "",
                    request.CountryTitle
                );

                return coords;
            }
            else
            {
                Console.WriteLine("Недостаточно данных для геокодинга");
                return null;
            }

        }

    }
}
