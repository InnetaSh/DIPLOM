using UserApiService.Models;
using Globals.Abstractions;
using Microsoft.AspNetCore.Identity.Data;

namespace UserApiService.Services.Interfaces
{
    public interface IUserService : IServiceBase<User>
    {
        Task<bool> AddOrderToUser(int userId, int orderId, params string[] includeProperties);
    }
}
