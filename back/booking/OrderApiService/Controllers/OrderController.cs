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

        private IOrderService _orderService;
        public OrderController(IOrderService orderService, IRabbitMqService mqService)
            : base(orderService, mqService)
        {
            _orderService = orderService;
        }


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
                // логируем и возвращаем ошибку сервера
                // _logger.LogError(ex, "Ошибка при создании заказа");
                return StatusCode(StatusCodes.Status500InternalServerError, "Внутренняя ошибка сервера");
            }
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
