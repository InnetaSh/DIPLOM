using Microsoft.AspNetCore.Mvc;
using UserApiService.Services.Interfaces;
using UserApiService.View;

namespace UserApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController :  ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = await _authService.LoginAsync(request);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("register/client")]
        public async Task<IActionResult> RegisterClient([FromBody] RegisterRequest request)
        {
            try
            {
                if (request.BirthDate == null)
                    return BadRequest("Дата рождения обязательна");

                var today = DateTime.UtcNow.Date;
                var age = today.Year - request.BirthDate.Value.Year;

                if (request.BirthDate.Value.Date > today.AddYears(-age))
                    age--;

                if (age < 18)
                    return BadRequest("Регистрация доступна только для пользователей старше 18 лет");

                request.RoleName = "Client";
                request.Discount = 0;

                var response = await _authService.RegisterAsync(request);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register/owner")]
        public async Task<IActionResult> RegisterOwner([FromBody] RegisterRequest request)
        {
            try
            {
                if (request.BirthDate == null)
                    return BadRequest("Дата рождения обязательна");

                var today = DateTime.UtcNow.Date;
                var age = today.Year - request.BirthDate.Value.Year;

                if (request.BirthDate.Value.Date > today.AddYears(-age))
                    age--;

                if (age < 18)
                    return BadRequest("Регистрация доступна только для пользователей старше 18 лет");

                request.RoleName = "Owner";
                request.Discount = 0;

                var response = await _authService.RegisterAsync(request);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _authService.DeleteUserAsync(id);
            if (!success)
                return NotFound(new { message = "Пользователь не найден" });

            return Ok(new { message = "Пользователь успешно удалён" });
        }
    }
}
