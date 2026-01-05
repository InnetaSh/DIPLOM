using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OrderApiGetway.View;
using OrderApiService.Models;
using OrderApiService.Models.Enum;
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

        private IOrderService _orderService;
        public OrderController(IOrderService orderService, IRabbitMqService mqService)
            : base(orderService, mqService)
        {
            _orderService = orderService;
        }
        //===========================================================================================

        [HttpPost("orderAdd")]
        public async Task<ActionResult<int>> AddOrder(
            [FromBody] OrderRequest orderRequest)
        {
            try
            {
                var model = MapToModel(orderRequest);

                var result = await _orderService.AddOrderAsync(model);

                if (result == -1)
                {
                    return BadRequest("Не удалось создать заказ");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "Ошибка при создании заказа");
                return StatusCode(StatusCodes.Status500InternalServerError, "Внутренняя ошибка сервера");
            }
        }


        //===========================================================================================

        [HttpPost("update/status/{orderId}")]
        public async Task<IActionResult> UpdateOrderStatus(
        int orderId,
        [FromQuery] OrderStatus orderState) 
        {

            var result = await _orderService.UpdateOrderStatus(orderId, orderState);
            if (result == -1)
                return BadRequest("Не удалось изменить заказ");

            return Ok(result);
        }

        //===========================================================================================

        [HttpGet("get/orders/{clientId}")]
        public async Task<ActionResult<List<OrderResponse>>> GetOrderById(
        int clientId)
        {

            var orders = await _orderService.GetOrdersByClientIdAsync(clientId);

            if (orders == null || !orders.Any())
                return NotFound();

            return Ok(orders);
        }

        //===========================================================================================
        [HttpPost("{offerId}/valid/date-time")]
        public async Task<ActionResult<bool>> HasDateConflict(
           int offerId,
             [FromBody] DateValidationRequest request)
        {
            var ordersIdList = request.OrdersIdList;
            var start = request.Start;
            var end = request.End;
            foreach (var orderId in ordersIdList)
            {
                var result = await _orderService.HasDateConflict(orderId, offerId, start, end);
                if (result)
                    return false;
            }
            return true;
        }

        //===========================================================================================

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
