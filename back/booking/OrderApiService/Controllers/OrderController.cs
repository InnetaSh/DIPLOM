//using Globals.Abstractions;
//using Globals.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using OrderApiService.Models;
//using OrderApiService.Service.Interface;
//using OrderApiService.View;

//namespace OrderApiService.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class OrderController
//        : BaseController<Order, OrderResponse, OrderRequest>
//    {
//        public OrderController(IOrderService offerService, IRabbitMqService mqService)
//            : base(offerService, mqService)
//        {
//        }

//        protected override Order MapToModel(OrderRequest request)
//        {

//            // забираем Offer, чтобы сделать snapshot цен
//            var offer = _offerService.GetById(request.OfferId);


//            return new Order
//            {
//                Title = request.Title,
//                Description = request.Description,

//                // Цены
//                PricePerDay = request.PricePerDay,
//                PricePerWeek = request.PricePerWeek,
//                PricePerMonth = request.PricePerMonth,

//                // Депозит / налоги
//                Deposit = request.Deposit,
//                PaymentStatus = request.PaymentStatus,
//                Tax = request.Tax,

//                // Правила
//                MinRentDays = request.MinRentDays,
//                AllowPets = request.AllowPets,
//                AllowSmoking = request.AllowSmoking,
//                AllowChildren = request.AllowChildren,

//                // Если пользователь не передал — оставить дефолты из модели Offer
//                CheckInTime = request.CheckInTime ?? new TimeSpan(15, 0, 0),
//                CheckOutTime = request.CheckOutTime ?? new TimeSpan(11, 0, 0),

//                // Связи
//                OwnerId = request.OwnerId,
//                RentObjId = request.RentObjId
//            };
//        }

//        protected override OfferResponse MapToResponse(Offer model)
//        {
//            return new OfferResponse
//            {
//                id = model.id,
//                Title = model.Title,
//                Description = model.Description,

//                // Цены
//                PricePerDay = model.PricePerDay,
//                PricePerWeek = model.PricePerWeek,
//                PricePerMonth = model.PricePerMonth,

//                // Депозит / налог
//                Deposit = model.Deposit,
//                PaymentStatus = model.PaymentStatus,
//                Tax = model.Tax,

//                // Правила
//                MinRentDays = model.MinRentDays,
//                AllowPets = model.AllowPets,
//                AllowSmoking = model.AllowSmoking,
//                AllowChildren = model.AllowChildren,

//                // Время заезда/выезда
//                CheckInTime = model.CheckInTime,
//                CheckOutTime = model.CheckOutTime,

//                // Связи
//                OwnerId = model.OwnerId,
//                RentObjId = model.RentObjId,

//                // Забронированные даты
//                BookedDates = model.BookedDates
//            };
//        }
//    }
//}
