
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using UserApiService.Models;
using UserApiService.Services;
using UserApiService.Services.Interfaces;
using UserApiService.View;

namespace UserApiService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var items = await _userService.GetEntitiesAsync();
            if (items == null || !items.Any())
                return NotFound(new { message = "No users found" });

            var responseList = new List<UserResponse>();
            foreach (var item in items) {
                responseList.Add(new UserResponse
                {
                    id = item.id,
                    Username = item.Username,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    RoleName = item.RoleName.ToString()
                });
            }

            return Ok(responseList);
        }


        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(GetByIdRequest request)
        {
            var item = await _userService.GetEntityAsync(request.id);

            if (item == null)
                return NotFound(new { message = "User not found" });

            var response = new UserResponse
            {
                id = item.id,
                Username = item.Username,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                RoleName = item.RoleName.ToString()
            };

            return Ok(response);
        }
        

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userExists = await _userService.ExistsEntityAsync(request.id);
            if (userExists)
                return NotFound(new { message = "User alredy exist" });

            _passwordHasher.CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);
            var token = _tokenService.GenerateJwtToken(request);

            var user = new User
            {
                id = request.id,
                Username = request.Username,
                Email = request.Email,
                PasswordHash = hash, 
                PasswordSalt = salt,
                RoleName = request.RoleName,
                Token = token,
                LastLogin = DateTime.UtcNow
            };

            var result = await _userService.AddEntityAsync(user);

            if (!result)
                return StatusCode(500, new { message = "Error creating user" });

            var response = new UserResponse
            {
                id = user.id,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                RoleName = user.RoleName.ToString()
            };

            return CreatedAtAction(nameof(GetUserById), new { id = user.id }, response);

        }


        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaster(int id, [FromBody] UserRequest request)
        {
            if (id != request.id)
                return BadRequest(new { message = "ID in URL does not match ID in body" });

            var userEntity = await _userService.GetEntityAsync(id);
            if (userEntity == null)
                return NotFound(new { message = "User not found" });

            userEntity.Username = request.Username ?? userEntity.Username;
            userEntity.Email = request.Email ?? userEntity.Email;
            userEntity.PhoneNumber = request.PhoneNumber ?? userEntity.PhoneNumber;

            if (!string.IsNullOrEmpty(request.Password))
            {
                _passwordHasher.CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);
                userEntity.PasswordHash = hash;
                userEntity.PasswordSalt = salt;
            }

            userEntity.Token = _tokenService.GenerateJwtToken(userEntity);

            var success = await _userService.UpdateEntityAsync(userEntity);
            if (!success)
                return StatusCode(500, new { message = "Error updating user" });

            return NoContent();
        }






        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(DeleteRequest deleteRequest)
        {
            var existingMaster = await _userService.ExistsEntityAsync(deleteRequest.id);
            if (existingMaster == null)
                return NotFound(new { message = "User not found" });


            var success = await _userService.DelEntityAsync(deleteRequest.id);
            if (!success)
                return StatusCode(500, new { message = "Error deleting master" });

            return NoContent();
        }
    }
}
