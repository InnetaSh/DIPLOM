
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
        public UserController(IUserService userService, IRabbitMqService mqService)
            : base(userService, mqService)
        {

        }



        protected override User MapToModel(UserRequest request)
        {
            return new User
            {
                Username = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                RoleName = Enum.TryParse<UserRole>(request.RoleName, true, out var role) ? role : UserRole.Client,
            };
        }

        protected override UserResponse MapToResponse(User model)
        {
            return new UserResponse
            {
                id = model.id,
                Username = model.Username,
                Email = model.Email ?? string.Empty,
                PhoneNumber = model.PhoneNumber,
                RoleName = model.RoleName.ToString()
            };
        }
    }
}
