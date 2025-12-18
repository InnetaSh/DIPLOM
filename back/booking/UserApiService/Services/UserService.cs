using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using UserApiService.Models;
using UserApiService.Models.Enums;
using UserApiService.Services.Interfaces;

namespace UserApiService.Services
{
    public class UserService : ServiceBase<User, UserContext>, IUserService
    {
        // =====================================================================
        // CLIENT → добавить заказ
        // =====================================================================
        public async Task<bool> AddOrderToClient(int userId, int orderId)
        {
            await using var db = new UserContext();

            var client = await db.Clients
                .FirstOrDefaultAsync(x => x.id == userId);

            if (client == null)
                return false;

            var exists = await db.ClientOrderLinks
                .AnyAsync(x => x.ClientId == client.id && x.OrderId == orderId);

            if (exists)
                return false;

            db.ClientOrderLinks.Add(new ClientOrderLink
            {
                ClientId = client.id,
                OrderId = orderId
            });

            await db.SaveChangesAsync();
            return true;
        }

        // =====================================================================
        // OWNER → добавить объявление
        // =====================================================================
        public async Task<bool> AddOfferToOwner(int userId, int offerId)
        {
            await using var db = new UserContext();

            var owner = await db.Owners
                .FirstOrDefaultAsync(x => x.id == userId);

            if (owner == null)
                return false;

            var exists = await db.OwnerOfferLinks
                .AnyAsync(x => x.OwnerId == owner.id && x.OfferId == offerId);

            if (exists)
                return false;

            db.OwnerOfferLinks.Add(new OwnerOfferLink
            {
                OwnerId = owner.id,
                OfferId = offerId
            });

            await db.SaveChangesAsync();
            return true;
        }

        // =====================================================================
        // Получить пользователя по id
        // =====================================================================
        public async Task<User?> GetByIdAsync(int userId)
        {
            await using var db = new UserContext();
            return await db.Users.FirstOrDefaultAsync(x => x.id == userId);
        }

        // =====================================================================
        // Проверка: принадлежит ли offer владельцу
        // =====================================================================
        public async Task<bool> ValidOfferIdByOwner(int userId, int offerId)
        {
            await using var db = new UserContext();

            return await db.OwnerOfferLinks
                .AnyAsync(x => x.OwnerId == userId && x.OfferId == offerId);
        }
    }
}
