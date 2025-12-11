
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
            return UserRequest.MapToModel(request);
        }

        protected override UserResponse MapToResponse(User model)
        {
            return UserResponse.MapToResponse(model);
        }
    }
}
