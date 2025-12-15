
using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using UserApiService.Models;
using UserApiService.Models.Enums;
using UserApiService.Services;
using UserApiService.Services.Interfaces;
using UserApiService.View;

namespace UserApiService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController
        : EntityControllerBase<User, UserResponse, UserRequest>
    {
        private IUserService _userService;
        public UserController(IUserService userService, IRabbitMqService mqService)
            : base(userService, mqService)
        {
            _userService = userService;
        }



        [HttpPost]
        [HttpPost("{userId}/orders")]
        public async Task<ActionResult> AddOrderToUser(
             int userId,
            [FromBody] int orderId)
        {
            var result = await _userService.AddOrderToUser(userId,orderId);

            if (!result)
                return BadRequest("Не удалось добавить заказ пользователю");

            return Ok(new { message = "Заказ добавлен" });
        }


        protected override User MapToModel(UserRequest request)
        {
            return UserRequest.MapToModel(request);
        }

        protected override UserResponse MapToResponse(User model)
        {
            return UserResponse.MapToResponse(model);
        }
    }
}
