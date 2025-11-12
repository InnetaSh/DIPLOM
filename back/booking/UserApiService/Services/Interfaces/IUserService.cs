using UserApiService.Models;
using Globals.Abstractions;
using Microsoft.AspNetCore.Identity.Data;

namespace UserApiService.Services.Interfaces
{
    public interface IUserService : IServiceBase<User>
    {
    }
}
