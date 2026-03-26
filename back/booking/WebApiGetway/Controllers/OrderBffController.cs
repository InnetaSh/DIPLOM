using AttractionContracts;
using LocationContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderContracts;
using ReviewContracts;
using System.ComponentModel.DataAnnotations;
using TranslationContracts;
using WebApiGetway.Clients;
using WebApiGetway.Helpers;
using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("orders")]
    public class OrderBffController : ControllerBase
    {
        private readonly IOrderBffService _orderService;
        private readonly IUserBffService _userService;
        public OrderBffController(
            IOrderBffService orderService,
            IUserBffService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }


        //===============================================================================================================
        //     	  CREATE ORDER
        //===============================================================================================================
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> CreateOrder(
             [FromBody] CreateOrderRequest request,
             [FromQuery] string lang)
        {
            var userId = User.GetUserId();
            var user = await _userService.GetById(userId);
            var discount = user?.Discount ?? 0m;
            var result = await _orderService.CreateOrder(
                request,
                userId,
                discount,
                lang);

            return Ok(result);
        }

        //===============================================================================================================
        //          GET ALL orders BY offerId
        //===============================================================================================================
        [HttpGet("by-offer/{offerId}")]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrdersByOfferId(
            [FromRoute] int offerId,
            [FromQuery] string lang)
        {
            var result = await _orderService.GetOrdersByOfferId(offerId, lang);
            return Ok(result);
        }

        //===============================================================================================================
        //          GET ALL orders BY userId
        //===============================================================================================================
        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OrderResponseForUserCard>>> GetOrdersByUserId(
            [FromQuery] string lang)
        {
            var userId = User.GetUserId();
            var result = await _orderService.GetOrdersByUserId(userId, lang);
            return Ok(result);
        }



        //===============================================================================================================
        //         EDIT ORDER STATUS
        //===============================================================================================================
        [HttpPut("me/{orderId}/status")]
        [Authorize]
        public async Task<ActionResult<bool>> UpdateOrderStatus(
         [FromRoute] int orderId,
         [FromBody] UpdateOrderStatusRequest request)
        {
            var result = await _orderService.UpdateStateOrder(orderId, request.OrderState);
            return Ok(result);
        }


    }
}
