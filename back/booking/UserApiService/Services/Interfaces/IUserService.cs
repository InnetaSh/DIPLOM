using Globals.Abstractions;
using Microsoft.AspNetCore.Identity.Data;
using UserApiService.Models;
using UserApiService.Models.Enums;
using UserApiService.View;

namespace UserApiService.Services.Interfaces
{
    public interface IUserService : IServiceBase<User>
    {
        Task<bool> AddOrderToClient(int userId, int orderId);
        Task<bool> AddOfferToOwner(int userId, int offerId);
        Task<bool> AddOfferToClientFavorite(int userId, int offerId, bool isFavorite);
        Task<User?> GetUserByIdAsync(int userId);
        Task<ClientResponse?> GetClientFullByIdAsync(int userId);
        Task<OwnerResponse?> GetOwnerFullByIdAsync(int userId);

       Task<bool> ValidOfferIdByOwner(int userId, int offerId);
    }
}
