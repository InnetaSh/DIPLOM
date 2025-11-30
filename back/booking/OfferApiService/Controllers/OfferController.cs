using Globals.Abstractions;
using Globals.Controllers;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models;
using OfferApiService.Models.Dto;
using OfferApiService.Models.RentObject.Enums;
using OfferApiService.Models.View;
using OfferApiService.Service.Interface;
using OfferApiService.View;
using OfferApiService.View.RentObject;

namespace OfferApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferController
        : EntityControllerBase<Offer, OfferResponse, OfferRequest>
    {
        private IOfferService _offerService;
        private readonly string _baseUrl;

        public OfferController(IOfferService offerService, IRabbitMqService mqService, IConfiguration configuration)
            : base(offerService, mqService)
        {
            _offerService = offerService;
            _baseUrl = configuration["AppSettings:BaseUrl"];
        }


        [HttpGet("by-mainparams")]
        public async Task<ActionResult<List<OfferResponse>>> GetMainSearch(
            [FromQuery] OfferMainSearchRequest request,
            [FromQuery] decimal UserDiscountPercent)
        {
            if (string.IsNullOrWhiteSpace(request.City))
                return BadRequest("City name is required");

          

            // Преобразуем даты в UTC
            var startDateUtc = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc);
            var endDateUtc = DateTime.SpecifyKind(request.EndDate, DateTimeKind.Utc);

            // Получаем предложения
            var offers = await _offerService.GetMainAvailableOffers(request);

            var response = new List<OfferResponse>();

            foreach (var offer in offers)
            {
                var dto = MapToResponse(offer);

                // Количество дней аренды
                int totalDays = (endDateUtc - startDateUtc).Days;
                if (totalDays <= 0) totalDays = 1;

                decimal orderPrice = 0;

                // Считаем по месяцам
                if (totalDays >= 30 && offer.PricePerMonth.HasValue)
                {
                    int months = totalDays / 30;
                    orderPrice += months * offer.PricePerMonth.Value;
                    totalDays -= months * 30;
                }

                // Считаем по неделям
                if (totalDays >= 7 && offer.PricePerWeek.HasValue)
                {
                    int weeks = totalDays / 7;
                    orderPrice += weeks * offer.PricePerWeek.Value;
                    totalDays -= weeks * 7;
                }

                // Остаток по дням
                orderPrice += totalDays * offer.PricePerDay;

                // Заполняем DTO
                dto.OrderPrice = orderPrice;
                dto.DiscountPercent = UserDiscountPercent;
                dto.DiscountAmount = orderPrice * UserDiscountPercent / 100;
                dto.TotalPrice = orderPrice - dto.DiscountAmount;

                // Используем фиксированный депозит (например 10%) или передаваемый через сервис
                //decimal depositPercent = 10;
                //dto.DepositAmount = dto.TotalPrice * depositPercent / 100;

                // Если Tax есть в DTO/Offer
                dto.TaxAmount = (dto.TotalPrice * (dto.Tax ?? 0)) / 100;

                response.Add(dto);
            }

            return Ok(response);
        }



        protected override Offer MapToModel(OfferRequest request)
        {
            return new Offer
            {
                id = request.id,
                Title = request.Title,
                Description = request.Description,
                PricePerDay = request.PricePerDay,
                PricePerWeek = request.PricePerWeek,
                PricePerMonth = request.PricePerMonth,
                DepositPersent = request.DepositPersent,
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


        protected override OfferResponse MapToResponse(Offer model)
        {
           
            return new OfferResponse
            {
                id = model.id,
                Title = model.Title,
                Description = model.Description,
                PricePerDay = model.PricePerDay,
                PricePerWeek = model.PricePerWeek,
                PricePerMonth = model.PricePerMonth,
                DepositPersent = model.DepositPersent,
                PaymentStatus = model.PaymentStatus,
                Tax = model.Tax,
                MinRentDays = model.MinRentDays,
                AllowPets = model.AllowPets,
                AllowSmoking = model.AllowSmoking,
                AllowChildren = model.AllowChildren,
                CheckInTime = model.CheckInTime,
                CheckOutTime = model.CheckOutTime,
                OwnerId = model.OwnerId,
                RentObj = model.RentObj == null ? null : new RentObjResponse
                {
                    id = model.RentObj.id,
                    Title = model.RentObj.Title,
                    Description = model.RentObj.Description,
                    CityId = model.RentObj.CityId,
                    CityTitle = model.RentObj.City?.Title,
                    Address = model.RentObj.Address,

                    RoomCount = model.RentObj.RoomCount,
                    BathroomCount = model.RentObj.BathroomCount,
                    Area = model.RentObj.Area,
                    Floor = model.RentObj.Floor,
                    TotalFloors = model.RentObj.TotalFloors,
                    RentObjType = model.RentObj.RentObjType,

                    Latitude = model.RentObj.Latitude,
                    Longitude = model.RentObj.Longitude,

                    BedroomsCount = model.RentObj.BedroomsCount,
                    BedsCount = model.RentObj.BedsCount,
                    HasBabyCrib = model.RentObj.HasBabyCrib,

                    ParamItems = model.RentObj.ParamValues?.Select(p => new ParamItemResponse
                    {
                        id = p.ParamItemId,
                        Title = p.ParamItem?.Title,
                        ValueType = p.ParamItem?.ValueType ?? ParamValueType.Boolean
                    }).ToList() ?? new List<ParamItemResponse>(),

                    Images = model.RentObj.Images
                        ?.Select(i => $"{_baseUrl}/images/rentobj/{model.RentObj.id}/{Path.GetFileName(i.Url)}")
                        .ToList() ?? new List<string>(),



                },
                    
                BookedDates = model.BookedDates?.Select(bd => new BookedDateResponse
                    {
                    id = bd.id,
                    Start = bd.Start,
                    End = bd.End,
                    OfferId = bd.OfferId
                }).ToList() ?? new List<BookedDateResponse>(),
                Reviews = model.Reviews?.Select(r => new ReviewResponse
                {
                    id = r.id,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    OfferId = r.OfferId,
                    UserId = r.UserId,
                    Response = r.Response,
                    CreatedAt = r.CreatedAt,
                    IsApproved = r.IsApproved,
                    IsAnonymous = r.IsAnonymous,
                    Photos = r.Photos ?? new List<string>(),
                    Cleanliness = r.Cleanliness,
                    Comfort = r.Comfort,
                    Location = r.Location,
                    Service = r.Service,
                    ValueForMoney = r.ValueForMoney
                }).ToList() ?? new List<ReviewResponse>(),
                Rating = model.Rating
            };
        }

    }
}
