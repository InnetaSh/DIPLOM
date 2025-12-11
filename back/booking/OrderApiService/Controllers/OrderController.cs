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


            return OrderRequest.MapToModel(request);
           
        }

        protected override OrderResponse MapToResponse(Order model)
        {
            return  OrderResponse.MapToResponse(model);
           
        }
    }
}
