using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using UserApiService.Models;
using UserApiService.Models.Enums;
using UserApiService.Services.Interfaces;
using UserApiService.View;

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
        // CLIENT → добавить заказ в историю просмотров
        // =====================================================================
        public async Task<bool> AddOfferToClientHistory(int userId, int offerId)
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
                IsFavorites = false
            });

            await db.SaveChangesAsync();
            return true;
        }

        // =====================================================================
        // CLIENT → добавить заказ в избранное
        // =====================================================================
        public async Task<bool> AddOfferToClientFavorite(int userId, int offerId)
        {
            await using var db = new UserContext();

            var client = await db.Clients
                .FirstOrDefaultAsync(x => x.id == userId);

            if (client == null)
                return false;

            var historyLink = await db.HistoryOfferLinks
                .FirstOrDefaultAsync(x => x.ClientId == client.id && x.OfferId == offerId);

            if (historyLink != null)
            {
                historyLink.IsFavorites = true;
            }
            else
            {
                db.HistoryOfferLinks.Add(new HistoryOfferLink
                {
                    ClientId = client.id,
                    OfferId = offerId,
                    IsFavorites = true
                });
            }

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

        public async Task<ClientResponse?> GetClientFullByIdAsync(int userId)
        {
            await using var db = new UserContext();

            return await db.Clients
                .Where(c => c.id == userId)
                .Select(c => new ClientResponse
                {
                    id = c.id,
                    Username = c.Username,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    RoleName = "Client",
                    CountryId = c.CountryId,
                    Discount = c.Discount,

                    ClientOrderLinks = c.ClientOrderLinks
                        .Select(o => new ClientOrderResponse
                        {
                            Id = o.Id,
                            ClientId = o.ClientId,
                            OrderId = o.OrderId,
                        })
                        .ToList(),

                    HistoryOfferLinks = c.HistoryOfferLinks
                        .Select(h => new HistoryOfferResponse
                        {
                            Id = h.Id,
                            ClientId = h.ClientId,
                            OfferId = h.OfferId,
                            IsFavorites = h.IsFavorites
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }



        // =====================================================================
        //             Owner — полные данные
        // =====================================================================

        public async Task<OwnerResponse?> GetOwnerFullByIdAsync(int userId)
        {
            await using var db = new UserContext();

            return await db.Owners
                .Where(o => o.id == userId)
                .Select(o => new OwnerResponse
                {
                   
                    id = o.id,
                    Username = o.Username,
                    Email = o.Email,
                    PhoneNumber = o.PhoneNumber,
                    RoleName = "Owner",

                 
                    CountryId = o.CountryId,
                    Discount = o.Discount,

                    // ===== OwnerOfferLinks =====
                    OwnerOfferLinks = o.OwnerOfferLinks
                        .Select(ol => new OwnerOfferResponse
                        {
                            Id = ol.Id,
                            OwnerId = ol.OwnerId,
                            OfferId = ol.OfferId
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
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
