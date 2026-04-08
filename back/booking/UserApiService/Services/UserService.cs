using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using UserApiService.Models;
//using UserApiService.Models.Enums;
using UserApiService.Services.Interfaces;
using UserContracts;
using UserContracts.Enums;
//using UserApiService.View;

namespace UserApiService.Services
{
    public class UserService : TableServiceBaseNew<User, UserContext>, IUserService
    {

        public UserService(UserContext context, ILogger<UserService> logger) : base(context, logger)
        {
        }
        // =====================================================================
        // CLIENT → добавить заказ
        // =====================================================================
        public async Task<bool> AddOrderToClient(int userId, int orderId)
        {
            _logger.LogInformation("User {UserId} adding order {OrderId}", userId, orderId);

            var client = await _context.Clients.FirstOrDefaultAsync(x => x.id == userId);
            if (client == null)
            {
                _logger.LogWarning("AddOrder failed: client {UserId} not found", userId);
                return false;
            }

            var exists = await _context.ClientOrderLinks
                .AnyAsync(x => x.ClientId == client.id && x.OrderId == orderId);

            if (exists)
            {
                _logger.LogInformation("Order {OrderId} already exists for client {UserId}", orderId, userId);
                return false;
            }

            _context.ClientOrderLinks.Add(new ClientOrderLink { ClientId = client.id, OrderId = orderId });
            await _context.SaveChangesAsync();

            _logger.LogInformation("Order {OrderId} added to client {UserId}", orderId, userId);
            return true;
        }


        // =====================================================================
        // CLIENT → добавить заказ в историю просмотров
        // =====================================================================
        public async Task<bool> AddOfferToClientHistory(int userId, int offerId)
        {
            _logger.LogInformation("Adding offer {OfferId} to history of client {UserId}", offerId, userId);

            var client = await _context.Clients.FirstOrDefaultAsync(x => x.id == userId);
            if (client == null)
            {
                _logger.LogWarning("Client {UserId} not found", userId);
                return false;
            }

            var exists = await _context.HistoryOfferLinks
                .AnyAsync(x => x.ClientId == client.id && x.OfferId == offerId);

            if (exists)
            {
                _logger.LogInformation("Offer {OfferId} already in history for client {UserId}", offerId, userId);
                return false;
            }

            _context.HistoryOfferLinks.Add(new HistoryOfferLink
            {
                ClientId = client.id,
                OfferId = offerId,
                IsFavorites = false
            });

            await _context.SaveChangesAsync();
            _logger.LogInformation("Offer {OfferId} added to history for client {UserId}", offerId, userId);
            return true;
        }

        // =====================================================================
        // CLIENT → добавить заказ в избранное
        // =====================================================================
        public async Task<bool> AddOfferToClientFavorite(int userId, int offerId)
        {
            _logger.LogInformation("Adding offer {OfferId} to favorites of client {UserId}", offerId, userId);

            var client = await _context.Users.FirstOrDefaultAsync(x => x.id == userId);
            if (client == null)
            {
                _logger.LogWarning("Client {UserId} not found", userId);
                return false;
            }

            var historyLink = await _context.HistoryOfferLinks
                .FirstOrDefaultAsync(x => x.ClientId == client.id && x.OfferId == offerId);

            if (historyLink != null)
            {
                historyLink.IsFavorites = true;
                _logger.LogInformation("Offer {OfferId} marked as favorite for client {UserId}", offerId, userId);
            }
            else
            {
                _context.HistoryOfferLinks.Add(new HistoryOfferLink
                {
                    ClientId = client.id,
                    OfferId = offerId,
                    IsFavorites = true
                });
                _logger.LogInformation("Offer {OfferId} added and marked as favorite for client {UserId}", offerId, userId);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        // =====================================================================
        // CLIENT →получить все заказы из истории и  избранное
        // =====================================================================
        public async Task<List<HistoryOfferLink>> GetOffersToClientHistory(int userId)
        {
            var client = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == userId);
            if (client == null)
            {
                _logger.LogWarning("Client {UserId} not found", userId);
                return null;
            }

            var historyOffers = await _context.HistoryOfferLinks
                .Where(x => x.ClientId == client.id)
                .AsNoTracking()
                .ToListAsync();


            _logger.LogInformation("Retrieved {Count} history offers for client {UserId}", historyOffers.Count, userId);
            return historyOffers;
        }

        // =====================================================================
        // OWNER → добавить объявление
        // =====================================================================
        public async Task<bool> AddOfferToOwner(int userId, int offerId)
        {
            _logger.LogInformation("Adding offer {OfferId} to owner {UserId}", offerId, userId);

            var owner = await _context.Owners.FirstOrDefaultAsync(x => x.id == userId);
            if (owner == null)
            {
                _logger.LogWarning("Owner {UserId} not found", userId);
                return false;
            }

            var exists = await _context.OwnerOfferLinks
                .AnyAsync(x => x.OwnerId == owner.id && x.OfferId == offerId);

            if (exists)
            {
                _logger.LogInformation("Offer {OfferId} already exists for owner {UserId}", offerId, userId);
                return false;
            }

            _context.OwnerOfferLinks.Add(new OwnerOfferLink
            {
                OwnerId = owner.id,
                OfferId = offerId
            });

            await _context.SaveChangesAsync();
            _logger.LogInformation("Offer {OfferId} added successfully to owner {UserId}", offerId, userId);
            return true;
        }

        // =====================================================================
        //              Получить пользователя по id
        // =====================================================================
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            _logger.LogInformation("Fetching user by id {UserId}", userId);

            var user = await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.id == userId);

            if (user == null)
                _logger.LogWarning("User with id {UserId} not found", userId);
            else
                _logger.LogInformation("User with id {UserId} retrieved successfully", userId);

            return user;
        }



        // =====================================================================
        //              Получить пользователя по email
        // =====================================================================
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            _logger.LogInformation("Fetching user by email {Email}", email);

            var user = await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                _logger.LogWarning("User with email {Email} not found", email);
            else
                _logger.LogInformation("User with email {Email} retrieved successfully", email);

            return user;
        }

        // =====================================================================
        //              Client — полные данные
        // =====================================================================

        public async Task<ClientResponse?> GetClientFullByIdAsync(int userId)
        {
            _logger.LogInformation("Fetching full client data for user id {UserId}", userId);

            var client = await _context.Clients
                .Where(c => c.id == userId)
                .Select(c => new ClientResponse
                {
                    id = c.id,
                    Username = c.Username,
                    Lastname = c.Lastname,
                    BirthDate = c.BirthDate,
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
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (client == null)
                _logger.LogWarning("Full client data not found for user id {UserId}", userId);
            else
                _logger.LogInformation("Full client data retrieved for user id {UserId}", userId);

            return client;
        }



        // =====================================================================
        //             Owner — полные данные
        // =====================================================================

        public async Task<OwnerResponse?> GetOwnerFullByIdAsync(int userId)
        {
            _logger.LogInformation("Fetching full owner data for user id {UserId}", userId);
            var owner = await _context.Owners
                .Where(o => o.id == userId)
                .Select(o => new OwnerResponse
                {
                    id = userId,
                    Username = o.Username,
                    Lastname = o.Lastname,
                    BirthDate = o.BirthDate,
                    Email = o.Email,
                    PhoneNumber = o.PhoneNumber,
                    CountryId = o.CountryId,
                    RoleName = "Owner",
                    Discount = o.Discount,

                    OwnerOfferLinks = o.OwnerOfferLinks
                        .Select(ol => new OwnerOfferResponse
                        {
                            Id = ol.Id,
                            OwnerId = ol.OwnerId,
                            OfferId = ol.OfferId
                        })
                        .ToList()
                })
                 .AsNoTracking()
                 .FirstOrDefaultAsync();

            if (owner == null)
                _logger.LogWarning("Full owner data not found for user id {UserId}", userId);
            else
                _logger.LogInformation("Full owner data retrieved for user id {UserId}", userId);

            return owner;
        }



        // ==============================================================================
        // Проверка: принадлежит ли offer владельцу (или же это супер админ или админ)
        // ==============================================================================
        public async Task<bool> ValidOfferIdByOwner(int userId, int offerId)
        {
            _logger.LogInformation("Checking if user {UserId} has access to offer {OfferId}", userId, offerId);

            var user = await _context.Users
                .Where(u => u.id == userId)
                .Select(u => new { u.id, u.RoleName })
                .FirstOrDefaultAsync();


            if (user == null)
            {
                _logger.LogWarning("User {UserId} not found when checking offer access for offer {OfferId}", userId, offerId);
                return false;
            }
            if (user.RoleName == UserRole.SuperAdmin || user.RoleName == UserRole.Admin)
            {
                _logger.LogInformation("User {UserId} has admin privileges, access granted for offer {OfferId}", userId, offerId);
                return true;
            }

            if (user.RoleName == UserRole.Owner)
            {
                var hasAccess = await _context.OwnerOfferLinks
                    .AnyAsync(x => x.OwnerId == userId && x.OfferId == offerId);

                if (hasAccess)
                    _logger.LogInformation("Owner {UserId} owns offer {OfferId}, access granted", userId, offerId);
                else
                    _logger.LogWarning("Owner {UserId} does not own offer {OfferId}, access denied", userId, offerId);

                return hasAccess;
            }

            _logger.LogWarning("User {UserId} with role {Role} attempted access to offer {OfferId}, access denied", userId, user.RoleName, offerId);
            return false;
        }
        // ==============================================================================
        // Проверка:  это супер админ или админ
        // ==============================================================================
        public async Task<bool> ValidAdminById(int userId)
        {
            _logger.LogInformation("Checking if user {UserId} is admin or super admin", userId);

            var user = await _context.Users
                .Where(u => u.id == userId)
                .Select(u => new { u.id, u.RoleName })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                _logger.LogWarning("User {UserId} not found when checking admin privileges", userId);
                return false;
            }

            var isAdmin = user.RoleName == UserRole.SuperAdmin || user.RoleName == UserRole.Admin;

            if (isAdmin)
                _logger.LogInformation("User {UserId} is admin or super admin", userId);
            else
                _logger.LogWarning("User {UserId} is not admin, access denied", userId);

            return isAdmin;
        }
    }
}
