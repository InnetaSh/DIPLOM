using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UserApiService.Models;
using UserApiService.Models.Enums;
using UserApiService.Services.Interfaces;
using UserApiService.View;

namespace UserApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
        : EntityControllerBase<User, UserResponse, UserRequest>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IRabbitMqService mqService)
            : base(userService, mqService)
        {
            _userService = userService;
        }

        // =====================================================================
        // CLIENT: добавить заказ пользователю
        // =====================================================================
        [Authorize]
        [HttpPost("client/orders/add/{orderId}")]
        public async Task<IActionResult> AddOrderToClient(int orderId)
        {
            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();

            var result = await _userService.AddOrderToClient(userId.Value, orderId);

            if (!result)
                return BadRequest("Не удалось добавить заказ пользователю");

            return Ok(new { message = "Заказ добавлен" });
        }



        // =====================================================================
        // CLIENT: добавить заказ в избранное
        // =====================================================================
        [Authorize]
        [HttpPost("client/offer/isfavorite/add/{offerId}")]
        public async Task<IActionResult> AddOfferToClientFavorite(
            int offerId,
            [FromQuery] bool isFavorite)
        {
            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();

            var result = await _userService.AddOfferToClientFavorite(userId.Value, offerId, isFavorite);

            if (!result)
                return BadRequest("Не удалось добавить заказ пользователю");

            return Ok(new { message = "Заказ добавлен" });
        }


        // =====================================================================
        // OWNER: добавить объявление
        // =====================================================================
        [Authorize(Roles = "Owner")]
        [HttpPost("owner/offers/add/{offerId}")]
        public async Task<IActionResult> AddOfferToOwner(int offerId)
        {
            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();

            var result = await _userService.AddOfferToOwner(userId.Value, offerId);

            if (!result)
                return BadRequest("Не удалось добавить объявление пользователю");

            return Ok(new { message = "Объявление добавлено" });
        }

        // =====================================================================
        // Получить текущего пользователя
        // =====================================================================

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();

            var user = await _userService.GetUserByIdAsync(userId.Value);
            if (user == null)
                return NotFound();

            return user.RoleName switch
            {
                UserRole.Client => Ok(await _userService.GetClientFullByIdAsync(userId.Value)),
                UserRole.Owner => Ok(await _userService.GetOwnerFullByIdAsync(userId.Value)),
                _ => Ok(user)
            };
        }



        // =====================================================================
        // Проверка: принадлежит ли offer текущему владельцу
        // =====================================================================
        [Authorize(Roles = "Owner")]
        [HttpGet("valid/offers/{offerId}")]
        public async Task<ActionResult<bool>> ValidOffer(int offerId)
        {
            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();

            var result = await _userService.ValidOfferIdByOwner(userId.Value, offerId);
            if (!result)
                return Forbid();

            return Ok(true);
        }

        // =====================================================================
        // Helpers
        // =====================================================================
        private int? GetUserId()
        {
            var id =
                User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            return int.TryParse(id, out var parsed) ? parsed : null;
        }

        // =====================================================================
        protected override User MapToModel(UserRequest request)
            => UserRequest.MapToModel(request);

        protected override UserResponse MapToResponse(User model)
            => UserResponse.MapToResponse(model);
    }
}
