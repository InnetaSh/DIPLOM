using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OrderApiService.Models;
using OrderApiService.Service.Interface;
using OrderApiService.Services;
using OrderApiService.View;

namespace OrderApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController
        : EntityControllerBase<Order, OrderResponse, OrderRequest>
    {
        public OrderController(IOrderService orderService, IRabbitMqService mqService)
            : base(orderService, mqService)
        {
        }

        protected override Order MapToModel(OrderRequest request)
        {

            // забираем Offer, чтобы сделать snapshot цен
            //var offer = orderService.GetById(request.OfferId);


            return new Order
            {
              
                   OfferId = request.OfferId,
                   ClientId = request.ClientId,

                   TotalPersons = request.TotalPersons,

                   StartDate = request.StartDate,
                   EndDate = request.EndDate,

                   CheckInTime = request.CheckInTime,
                   CheckOutTime = request.CheckOutTime,

                   ClientNote = request.ClientNote,
                   PaymentMethod = request.PaymentMethod,

                   CreatedAt = DateTime.UtcNow,

               };
        }

        protected override OrderResponse MapToResponse(Order model)
        {
            return new OrderResponse
            {
                id = model.id,
                OfferId = model.OfferId,
                ClientId = model.ClientId,

                TotalPersons = model.TotalPersons,

                StartDate = model.StartDate,
                EndDate = model.EndDate,

                // Финансы
                BasePrice = model.BasePrice,
                DiscountPercent = model.DiscountPercent,
                DiscountAmount = model.DiscountAmount,
                DepositAmount = model.DepositAmount,
                TaxAmount = model.TaxAmount,
                TotalPrice = model.TotalPrice,

                // Оплата
                PaymentMethod = model.PaymentMethod,
                IsPaid = model.IsPaid,
                PaidAt = model.PaidAt,

                // Время
                CheckInTime = model.CheckInTime,
                CheckOutTime = model.CheckOutTime,

                // Другое
                ClientNote = model.ClientNote,
                Status = model.Status,
                CreatedAt = model.CreatedAt
            };
        }
    }
}
