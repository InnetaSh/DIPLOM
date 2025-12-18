using Globals.Abstractions;
using Microsoft.AspNetCore.Identity.Data;
using UserApiService.Models;
using UserApiService.Models.Enums;

namespace UserApiService.Services.Interfaces
{
    public interface IUserService : IServiceBase<User>
    {
        Task<bool> AddOrderToClient(int userId, int orderId);
        Task<bool> AddOfferToOwner(int userId, int offerId);
        Task<User?> GetByIdAsync(int userId);

       Task<bool> ValidOfferIdByOwner(int userId, int offerId);
    }
}
