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

        [HttpPost("order/add")]
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
                Console.WriteLine(ex.ToString());
                throw;
            }
        }


        //===========================================================================================

        [HttpPost("update/status/{orderId}")]
        public async Task<IActionResult> UpdateOrderStatus(
             int orderId,
         [FromQuery] string orderState) 
        {
            if (!Enum.TryParse<OrderStatus>(orderState, true, out var statusEnum))
            {
                return BadRequest($"Неверный статус: {orderState}");
            }

            var result = await _orderService.UpdateOrderStatus(orderId, statusEnum);

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

        [HttpGet("{orderId}/get/offerId")]
        public async Task<ActionResult<int>> GetOfferByIdFromOrder(
        int orderId)
        {

            var order = await _orderService.GetEntityAsync(orderId);

            if (order == null )
                return NotFound();

            return Ok(new {offerId = order.OfferId});
        }

        //===========================================================================================

        [HttpGet("get/byOfferId/{offerId}")]
        public async Task<ActionResult<List<OrderResponse>>> GetOrdersByOfferIdAsync(
        int offerId)
        {

            var orders = await _orderService.GetOrdersByOfferIdAsync(offerId);

            if (orders == null)
                return NotFound();

            return Ok(orders);
        }




        //===========================================================================================

        [HttpGet("has-pending/{ownerId}")]
        public async Task<ActionResult<List<int>>> GetPendingOfferIds(int ownerId)
        {
            var offerIds = await _orderService.GetPendingOfferIdsAsync(ownerId);

            return Ok(offerIds);
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
                var isExist = await _orderService.HasDateConflict(orderId, offerId, start, end);
                if (!isExist)
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
