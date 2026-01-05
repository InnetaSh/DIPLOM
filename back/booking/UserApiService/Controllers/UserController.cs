using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
        // CLIENT: добавить заказ в историю просмотров
        // =====================================================================
        [Authorize]
        [HttpPost("client/offer/history/add/{offerId}")]
        public async Task<IActionResult> AddOfferToClientHistory(
            int offerId)
        {
            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();

            var result = await _userService.AddOfferToClientFavorite(userId.Value, offerId);

            if (!result)
                return BadRequest("Не удалось добавить в просмотренные пользователю");

            return Ok(new { message = "Обьявление добавлено" });
        }


        // =====================================================================
        // CLIENT: добавить заказ в избранное
        // =====================================================================
        [Authorize]
        [HttpPost("client/offer/isfavorite/add/{offerId}")]
        public async Task<IActionResult> AddOfferToClientFavorite(
            int offerId)
        {
            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();

            var result = await _userService.AddOfferToClientFavorite(userId.Value, offerId);

            if (!result)
                return BadRequest("Не удалось добавить в избранное пользователю");

            return Ok(new { message = "Обьявление добавлено" });
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
        // Редактировать текущего пользователя
        // =====================================================================

        [HttpPost("me/update")]
        [Authorize]
        public async Task<IActionResult> UpdateMe([FromBody] UserRequest request)
        {
            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();

            var user = await _userService.GetUserByIdAsync(userId.Value);
            if (user == null)
                return NotFound();

           
            user.Username = request.Username ?? user.Username;
            user.Email = request.Email ?? user.Email;
            user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
            user.Discount = request.Discount;
            user.CountryId = request.CountryId;

            await _userService.UpdateEntityAsync(user);

            
            var userDto = UserResponse.MapToResponse(user);
      
            return Ok(userDto);
        }



        // =====================================================================
        // Изменить пароль текущего пользователя
        // =====================================================================
        [HttpPost("me/change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();

            var user = await _userService.GetUserByIdAsync(userId.Value);
            if (user == null)
                return NotFound();

            // --- Проверка старого пароля ---
            using var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.OldPassword));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    return BadRequest("Old password is incorrect");
            }

            // --- Установка нового пароля ---
            using var newHmac = new System.Security.Cryptography.HMACSHA512();
            user.PasswordSalt = newHmac.Key;
            user.PasswordHash = newHmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.NewPassword));

            await _userService.UpdateEntityAsync(user);

            return Ok(new { message = "Password updated successfully" });
        }




        // =====================================================================
        // Сменить почту текущего пользователя
        // =====================================================================
        [HttpPost("me/change-email")]
        [Authorize]
        public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailRequest request)
        {
            var userId = GetUserId();
            if (userId == null)
                return Unauthorized();

            var user = await _userService.GetUserByIdAsync(userId.Value);
            if (user == null)
                return NotFound();

            if (string.IsNullOrWhiteSpace(request.NewEmail))
                return BadRequest("Email cannot be empty.");
  
            user.Email = request.NewEmail;

            await _userService.UpdateEntityAsync(user);

            var userDto = UserResponse.MapToResponse(user);
            return Ok(userDto);
        }



        // =====================================================================
        // Проверка: принадлежит ли offer текущему владельцу
        // =====================================================================
        [Authorize]
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
