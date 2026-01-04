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
        // CLIENT → добавить заказ в избранное
        // =====================================================================
        public async Task<bool> AddOfferToClientFavorite(int userId, int offerId, bool isFavorite)
        {
            await using var db = new UserContext();

            var client = await db.Clients
              .FirstOrDefaultAsync(x => x.id == userId);


            if (client == null)
                return false;

            var exists = await db.HistoryOfferLinks
                .AnyAsync(x => x.ClientId == client.id && x.OfferId == offerId);

            if (exists)
                return false;

            db.HistoryOfferLinks.Add(new HistoryOfferLink
            {
                ClientId = client.id,
                OfferId = offerId,
                IsFavorites = isFavorite
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
        //              Получить пользователя по id
        // =====================================================================
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            await using var db = new UserContext();
            return await db.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.id == userId);
        }


        // =====================================================================
        //              Client — полные данные
        // =====================================================================

        public async Task<Client?> GetClientFullByIdAsync(int userId)
        {
            await using var db = new UserContext();

            return await db.Clients
                .AsNoTracking()
                .Include(c => c.ClientOrderLinks)
                .Include(c => c.HistoryOfferLinks)
                .FirstOrDefaultAsync(c => c.id == userId);
        }


        // =====================================================================
        //             Owner — полные данные
        // =====================================================================

        public async Task<Owner?> GetOwnerFullByIdAsync(int userId)
        {
            await using var db = new UserContext();

            return await db.Owners
                .AsNoTracking()
                .Include(o => o.OwnerOfferLinks)
                .FirstOrDefaultAsync(o => o.id == userId);
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
