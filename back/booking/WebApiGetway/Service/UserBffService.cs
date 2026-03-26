using AttractionContracts;
using Globals.Exceptions;
using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using OfferContracts;
using ReviewContracts;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using TranslationContracts;
using UserContracts;
using WebApiGetway.Clients;
using WebApiGetway.Clients.Interface;
using WebApiGetway.Helpers;
using WebApiGetway.Models.Enum;
using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Service
{
    public class UserBffService : IUserBffService
    {
        private readonly ITranslationApiClient _translationClient;
        private readonly ILocationApiClient _locationClient;
        private readonly IStatisticApiClient _statisticClient;
        private readonly IOfferApiClient _offerApiClient;
        private readonly IUserApiClient _userApiClient;
        private readonly IOrderApiClient _orderApiClient;
        private readonly IReviewApiClient _reviewApiClient;
        private readonly ILogger<OfferBffService> _logger;
        private readonly HelpersFunctions _helpers;

        public UserBffService
                (ITranslationApiClient translationClient,
                ILocationApiClient locationClient,
                IStatisticApiClient statisticClient,
                IUserApiClient userApiClient,
                IOfferApiClient offerApiClient,
                IOrderApiClient orderApiClient,
                IReviewApiClient reviewApiClient,
                ILogger<OfferBffService> logger,
                HelpersFunctions helpers)
        {
            _translationClient = translationClient;
            _locationClient = locationClient;
            _statisticClient = statisticClient;
            _userApiClient = userApiClient;
            _offerApiClient = offerApiClient;
            _orderApiClient = orderApiClient;
            _reviewApiClient = reviewApiClient;
            _logger = logger;
            _helpers = helpers;
        }



        //===============================================================================================================
        //		(FOR ADMIN) - GET ALL USERS
        //===============================================================================================================
        /// <summary>
        /// Получает всех пользователей системы.
        /// </summary>
        /// <returns>Коллекция пользователей или пустой список, если пользователей нет.</returns>
        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            _logger.LogInformation("Start fetching all users for admin.");

            var users = await _userApiClient.GetAll();

            if (users == null || !users.Any())
            {
                _logger.LogWarning("No users found in the system.");
                return Enumerable.Empty<UserResponse>();
            }

            _logger.LogInformation("Retrieved {Count} users.", users.Count());

            return users;
        }

        //===========================================================================================
        //		(FOR ADMIN) - GET FULL USER INFORMATION BY userId
        //===========================================================================================
        /// <summary>
        /// Получает полную информацию о пользователе по его идентификатору.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Информация о пользователе или пустой объект UserResponse, если пользователь не найден.</returns>
        /// <exception cref="ArgumentException">Если userId <= 0.</exception>
        public async Task<UserResponse> GetById(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Invalid userId", nameof(userId));
            }

            _logger.LogInformation("Start fetching full information for userId: {UserId}", userId);

            var user = await _userApiClient.GetById(userId);

            if (user == null)
            {
                _logger.LogWarning("User not found for userId: {UserId}", userId);
                return new UserResponse();
            }

            _logger.LogInformation("Successfully retrieved information for userId: {UserId}", userId);

            return user;
        }

        //===========================================================================================
        //		(FOR ADMIN) - GET FULL USER INFORMATION BY EMAIL
        //===========================================================================================
        /// <summary>
        /// Получает полную информацию о пользователе по email.
        /// </summary>
        /// <param name="email">Email пользователя.</param>
        /// <returns>Информация о пользователе или пустой объект UserResponse, если пользователь не найден.</returns>
        /// <exception cref="ArgumentException">Если email пустой или null.</exception>
        public async Task<UserResponse> GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email is required", nameof(email));
            }

            _logger.LogInformation("Start fetching full information for user with email: {Email}", email);

            var user = await _userApiClient.GetByEmail(email);

            if (user == null)
            {
                _logger.LogWarning("User not found for email: {Email}", email);
                return new UserResponse();
            }

            _logger.LogInformation("Successfully retrieved information for user with email: {Email}", email);

            return user;
        }

        //===========================================================================================
        //		(FOR AUTHORIZED USER) - GET FULL INFORMATION ABOUT CURRENT USER
        //===========================================================================================
        /// <summary>
        /// Получает полную информацию о текущем авторизованном пользователе.
        /// </summary>
        /// <param name="lang">Код языка для перевода страны (например: "en", "uk", "ru").</param>
        /// <returns>Информация о пользователе с переводом страны или пустой объект UserResponse, если пользователь не найден.</returns>
        public async Task<UserResponse> GetMeAsync(string lang)
        {
            if (string.IsNullOrWhiteSpace(lang))
            {
                throw new ArgumentException("Language code is required", nameof(lang));
            }

            _logger.LogInformation("Start fetching current user information. Lang: {Lang}", lang);

            var user = await _userApiClient.GetMeAsync();

            if (user == null)
            {
                _logger.LogWarning("Current user not found.");
                return new UserResponse();
            }

            int userId = user.id;
            int countryId = user.CountryId;

            var countryTranslate = await _translationClient.GetCountryTranslationByIdAsync(countryId, lang);
            user.CountryTitle = countryTranslate?.Title ?? "N/A";

            _logger.LogInformation("Successfully retrieved information for userId: {UserId}", userId);

            return user;
        }

        //===========================================================================================
        //		(FOR AUTHORIZED USER) - GET OFFERS BY ownerId (WITHOUT ADDITIONAL CALCULATIONS)
        //===========================================================================================
        /// <summary>
        /// Получает объявления текущего пользователя (собственника) без дополнительных расчетов.
        /// </summary>
        /// <param name="lang">Код языка для перевода объявлений (например: "en", "uk", "ru").</param>
        /// <returns>Коллекция объявлений с переводами и рейтингами.</returns>
        /// <exception cref="UnauthorizedAccessException">Если текущий пользователь не является собственником.</exception>

        public async Task<IEnumerable<OfferResponse>> GetMyOffers( string lang)
        {
            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language code is required", nameof(lang));

            _logger.LogInformation("Start fetching offers for current owner. Lang: {Lang}", lang);

            var user = await _userApiClient.GetMeAsync();
            if (user == null)
            {
                _logger.LogWarning("Current user not found.");
                return Enumerable.Empty<OfferResponse>();
            }

            int userId = user.id;
            var userRole = user.RoleName;
            if (string.IsNullOrWhiteSpace(userRole) ||
                !string.Equals(userRole, "owner", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogWarning("Access denied. UserId {UserId} is not an owner.", userId);
                throw new UnauthorizedAccessException("Вы не собственник имущества");
            }

            var offersTask = _offerApiClient.GetOfferByOwnerId(userId);
            var translationsTask = _translationClient.GetAllOffersTranslationAsync(lang);

            await Task.WhenAll(offersTask, translationsTask);
            var offers = offersTask.Result ?? Enumerable.Empty<OfferResponse>();
            var translations = translationsTask.Result ?? Enumerable.Empty<TranslationResponse>();

            if (!offers.Any())
            {
                _logger.LogWarning("No offers found for owner userId {UserId}", userId);
                return Enumerable.Empty<OfferResponse>();
            }

            if (!translations.Any())
                _logger.LogWarning("No translations found for offers for lang {Lang}", lang);


            MergeHelper.Merge(
              offers,
              translations,
              c => c.id,
              t => t.EntityId);
            _logger.LogInformation("Merge completed for offers translations.");

            var idList = offers.Select(x => x.id).ToList();
            if (idList.Any())
            {
                var offersRatings = await _reviewApiClient.GetOffersRatingAsync(idList);
                MergeHelper.Merge(
                    offers,
                    offersRatings ?? Enumerable.Empty<RatingResponse>(),
                    c => c.id,
                    r => r.OfferId
                );
                _logger.LogInformation("Merge completed for offers ratings.");
            }
            _logger.LogInformation("Merge completed for offers ratings.");

            return offers;
        }

        //===========================================================================================
        //		(FOR AUTHORIZED USER) - GET OFFERS BY ownerId AND cityId (WITHOUT ADDITIONAL CALCULATIONS)
        //===========================================================================================
        /// <summary>
        /// Получает объявления текущего пользователя (собственника) по указанному cityId без дополнительных расчетов.
        /// </summary>
        /// <param name="cityId">Идентификатор города.</param>
        /// <param name="lang">Код языка для перевода объявлений (например: "en", "uk", "ru").</param>
        /// <returns>Коллекция объявлений с переводами и рейтингами.</returns>
        /// <exception cref="UnauthorizedAccessException">Если текущий пользователь не является собственником.</exception>

        public async Task<IEnumerable<OfferResponse>> GetMyOffersByCityId(int cityId, string lang)
        {
            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language code is required", nameof(lang));

            _logger.LogInformation("Start fetching offers for current owner in cityId: {CityId}, Lang: {Lang}", cityId, lang);

            var user = await _userApiClient.GetMeAsync();
            if (user == null)
            {
                _logger.LogWarning("Current user not found.");
                return Enumerable.Empty<OfferResponse>();
            }

            int userId = user.id;
            var userRole = user.RoleName;
            if (string.IsNullOrWhiteSpace(userRole) ||
                  !string.Equals(userRole, "owner", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogWarning("Access denied. UserId {UserId} is not an owner.", userId);
                throw new UnauthorizedAccessException("Вы не собственник имущества");
            }

            var offersTask = _offerApiClient.GetOfferByOwnerIdAndCityId(userId, cityId);
            var translationsTask = _translationClient.GetAllOffersTranslationAsync(lang);

            await Task.WhenAll(offersTask, translationsTask);
            var offers = offersTask.Result ?? Enumerable.Empty<OfferResponse>();
            var translations = translationsTask.Result ?? Enumerable.Empty<TranslationResponse>();

            if (!offers.Any())
            {
                _logger.LogWarning("No offers found for owner userId {UserId} in cityId {CityId}", userId, cityId);
                return Enumerable.Empty<OfferResponse>();
            }

            if (!translations.Any())
                _logger.LogWarning("No translations found for offers for lang {Lang}", lang);


            MergeHelper.Merge(
              offers,
              translations,
              c => c.id,
              t => t.EntityId);
            _logger.LogInformation("Merge completed for offers translations.");

            var idList = offers.Select(x => x.id).ToList();
            if (idList.Any())
            {
                var offersRatings = await _reviewApiClient.GetOffersRatingAsync(idList);
                MergeHelper.Merge(
                    offers,
                    offersRatings ?? Enumerable.Empty<RatingResponse>(),
                    c => c.id,
                    r => r.OfferId
                );
                _logger.LogInformation("Merge completed for offers ratings.");
            }
            return offers;
        }

        //===========================================================================================
        //		GET OFFERS BY ownerId AND countryId (WITHOUT ADDITIONAL CALCULATIONS)
        //===========================================================================================
        /// <summary>
        /// Получает объявления текущего пользователя (собственника) по указанному countryId без дополнительных расчетов.
        /// </summary>
        /// <param name="countryId">Идентификатор страны.</param>
        /// <param name="lang">Код языка для перевода объявлений (например: "en", "uk", "ru").</param>
        /// <returns>Коллекция объявлений с переводами и рейтингами.</returns>
        /// <exception cref="UnauthorizedAccessException">Если текущий пользователь не является собственником.</exception>

        public async Task<IEnumerable<OfferResponse>> GetMyOffersByCountryId(int countryId, string lang)
        {
            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language code is required", nameof(lang));

            _logger.LogInformation("Start fetching offers for current owner in countryId: {CountryId}, Lang: {Lang}", countryId, lang);

            var user = await _userApiClient.GetMeAsync();
            if (user == null)
            {
                _logger.LogWarning("Current user not found.");
                return Enumerable.Empty<OfferResponse>();
            }

            int userId = user.id;
            var userRole = user.RoleName;
            if (string.IsNullOrWhiteSpace(userRole) ||
                !string.Equals(userRole, "owner", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogWarning("Access denied. UserId {UserId} is not an owner.", userId);
                throw new UnauthorizedAccessException("Вы не собственник имущества");
            }


            var offersTask = _offerApiClient.GetOfferByOwnerIdAndCountryId(userId, countryId);
            var translationsTask = _translationClient.GetAllOffersTranslationAsync(lang);

            await Task.WhenAll(offersTask, translationsTask);
            var offers = offersTask.Result ?? Enumerable.Empty<OfferResponse>();
            var translations = translationsTask.Result ?? Enumerable.Empty<TranslationResponse>();

            if (!offers.Any())
            {
                _logger.LogWarning("No offers found for owner userId {UserId} in countryId {CountryId}", userId, countryId);
                return Enumerable.Empty<OfferResponse>();
            }

            if (!translations.Any())
                _logger.LogWarning("No translations found for offers for lang {Lang}", lang);

            MergeHelper.Merge(
              offers,
              translations,
              c => c.id,
              t => t.EntityId);
            _logger.LogInformation("Merge completed for offers translations.");

            var idList = offers.Select(x => x.id).ToList();
            if (idList.Any())
            {
                var offersRatings = await _reviewApiClient.GetOffersRatingAsync(idList);
                MergeHelper.Merge(
                    offers,
                    offersRatings ?? Enumerable.Empty<RatingResponse>(),
                    c => c.id,
                    r => r.OfferId
                );
                _logger.LogInformation("Merge completed for offers ratings.");
            }


            return offers;
        }



        //===============================================================================================================
        //		CLIENT: ADD OFFER TO FAVORITES
        //===============================================================================================================

        /// <summary>
        ///		Добавляет объявление в список избранного пользователя.
        /// </summary>
        /// <param name="offerId">Идентификатор объявления</param>
        /// <returns>true — если успешно добавлено, иначе false</returns>
        public async Task<bool> AddOfferToClientFavorite(int offerId)
        {
            _logger.LogInformation("Start adding offer to favorites. OfferId: {OfferId}", offerId);

            var result = await _userApiClient.AddOfferToFavoriteForUserAsync(offerId);

            if (!result)
            {
                _logger.LogWarning("Failed to add offer to favorites. OfferId: {OfferId}", offerId);
                return false;
            }

            _logger.LogInformation("Offer successfully added to favorites. OfferId: {OfferId}", offerId);

            return true;
        }

        //===============================================================================================================
        //		CLIENT: GET ALL OFFERS FROM HISTORY
        //===============================================================================================================

        /// <summary>
        ///		Получает все объявления из истории пользователя.
        ///		Метод загружает список связей истории, подтягивает объявления и их переводы,
        ///		а также формирует краткую информацию (заголовок, изображение, избранное).
        /// </summary>
        /// <param name="lang">Код языка (например: "en", "uk", "ru")</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Коллекция HistoryOfferLinkResponse</returns>
        public async Task<IEnumerable<HistoryOfferLinkResponse>> GetOffersFromClientHistory(string lang, int userId)
        {
            _logger.LogInformation("Start fetching client history. UserId: {UserId}, Lang: {Lang}", userId, lang);

            var historyLinks = await _userApiClient.GetOffersFromClientHistory();

            if (historyLinks == null || !historyLinks.Any())
            {
                _logger.LogWarning("No history found for UserId: {UserId}", userId);
                return Enumerable.Empty<HistoryOfferLinkResponse>();
            }

            _logger.LogInformation("Retrieved {Count} history records", historyLinks.Count());


            var tasks = historyLinks.Select(async historyOf =>
            {
                var offerId = historyOf.OfferId;

                var offerTask = _offerApiClient.GetOfferById(offerId);
                var translationTask = _translationClient.GetOfferTranslationByIdAsync(offerId, lang);

                await Task.WhenAll(offerTask, translationTask);

                var offer = await offerTask;
                var translateOffer = await translationTask;

                if (offer == null)
                {
                    _logger.LogWarning("Offer not found for OfferId: {OfferId}", offerId);
                }

                var mainImgUrl = offer?.RentObj?.Images?.FirstOrDefault()?.Url;

                return new HistoryOfferLinkResponse
                {
                    OfferId = offerId,
                    ClientId = userId,
                    Title = translateOffer?.Title ?? "N/A",
                    IsFavorites = historyOf.IsFavorites,
                    MainImageUrl = mainImgUrl
                };
            });

            var result = await Task.WhenAll(tasks);
            _logger.LogInformation("Completed fetching client history. UserId: {UserId}, ResultCount: {Count}", userId, result.Length);

            return result ?? Enumerable.Empty<HistoryOfferLinkResponse>();
        }


        //===============================================================================================================
        //		CLIENT: GET OFFER IDS FROM HISTORY AND FAVORITES
        //===============================================================================================================

        /// <summary>
        ///		Получает список идентификаторов объявлений из истории пользователя и избранного.
        /// </summary>
        /// <param name="lang">Код языка (не используется, но сохранён для совместимости)</param>
        /// <returns>Коллекция идентификаторов объявлений</returns>
        public async Task<IEnumerable<int>> GetOffersIdFromClientHistory(string lang)
        {
            _logger.LogInformation("Start fetching offer IDs from client history");

            var historyLinks = await _userApiClient.GetOffersFromClientHistory();

            if (historyLinks == null || !historyLinks.Any())
            {
                _logger.LogWarning("No history links found");
                return Enumerable.Empty<int>();
            }

            var ids = historyLinks.Select(x => x.OfferId).ToList();

            _logger.LogInformation("Retrieved {Count} offer IDs from history", ids.Count);

            return ids;
        }




        // =====================================================================
        //		CHECK IF OWNER HAS PENDING ORDERS
        // =====================================================================
        /// <summary>
        /// Проверяет, есть ли новые неподтвержденные брони у собственника.
        /// </summary>
        /// <param name="userId">Идентификатор владельца (owner).</param>
        /// <returns>Список идентификаторов заказов, которые находятся в состоянии pending.</returns>
        public async Task<IEnumerable<int>> HasPendingOrder(int userId)
        {
            if (userId <= 0)
                throw new ValidationException("Некорректный идентификатор пользователя");

            _logger.LogInformation("Checking pending orders for userId: {UserId}", userId);

            var result = await _orderApiClient.HasPendingOrder(userId);

            if (result == null || !result.Any())
            {
                _logger.LogInformation("No pending orders found for userId: {UserId}", userId);
                return Enumerable.Empty<int>();
            }

            _logger.LogInformation("Found {Count} pending orders for userId: {UserId}", result.Count(), userId);
            return result;
        }



        // ==========================================================================================
        //		AUTH METHODS - GOOGLE LOGIN
        // ==========================================================================================
        /// <summary>
        /// Выполняет вход через Google по данным запроса.
        /// </summary>
        /// <param name="request">Данные для входа через Google.</param>
        /// <returns>Информация о пользователе после успешного входа через Google.</returns>
        public async Task<GoogleLoginResponse> GoogleLogin(GoogleLoginRequest request)
        {
            if (request == null)
            {
                _logger.LogWarning("GoogleLogin called with null request.");
                throw new ArgumentNullException(nameof(request));
            }

            _logger.LogInformation("Attempting Google login");

            var result = await _userApiClient.GoogleLogin(request);

            if (result == null)
            {
                _logger.LogWarning("Google login failed or returned null");
                return new GoogleLoginResponse();
            }

            _logger.LogInformation("Google login successful");
            return result;
        }

        //===========================================================================================
        //		AUTH METHODS - LOGIN
        //===========================================================================================
        /// <summary>
        /// Выполняет вход пользователя по данным запроса (email/password или другие креды).
        /// </summary>
        /// <param name="request">Данные для входа пользователя.</param>
        /// <returns>Информация о пользователе после успешного входа.</returns>
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            if (request == null)
            {
                _logger.LogWarning("Login called with null request.");
                throw new ArgumentNullException(nameof(request));
            }

            _logger.LogInformation("Attempting login for email: {Email}", request.Login);

            var result = await _userApiClient.Login(request);

            if (result == null)
            {
                _logger.LogWarning("Login failed for email: {Email}", request.Login);
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            _logger.LogInformation("Login successful for email: {Email}", request.Login);
            return result;
        }

        //===========================================================================================
        //		REGISTRATION METHODS - REGISTER CLIENT / REGISTER OWNER
        //===========================================================================================
        /// <summary>
        /// Регистрирует нового пользователя.
        /// </summary>
        /// <param name="request">Данные для регистрации пользователя.</param>
        /// <returns>Результат регистрации пользователя.</returns>
        private async Task<RegisterResponse> RegisterUser(RegisterRequest request, Func<RegisterRequest, Task<RegisterResponse>> registerFunc, string role)
        {
            if (request == null)
            {
                _logger.LogWarning("Register{Role} called with null request.", role);
                throw new ArgumentNullException(nameof(request));
            }

            _logger.LogInformation("Attempting to register {Role} with email: {Email}", role, request.Email);

            var result = await registerFunc(request);

            if (result == null)
            {
                _logger.LogWarning("{Role} registration failed or returned null for email: {Email}", role, request.Email);
                return new RegisterResponse();
            }

            _logger.LogInformation("{Role} registration successful for email: {Email}", role, request.Email);
            return result;
        }
        //===========================================================================================
        public Task<RegisterResponse> RegisterClient(RegisterRequest request) =>
            RegisterUser(request, _userApiClient.RegisterClient, "Client");

        public Task<RegisterResponse> RegisterOwner(RegisterRequest request) =>
            RegisterUser(request, _userApiClient.RegisterOwner, "Owner");


        //===========================================================================================
        //		UPDATE ME
        //===========================================================================================
        /// <summary>
        /// Обновляет информацию о текущем пользователе.
        /// </summary>
        /// <param name="request">Данные для обновления пользователя.</param>
        /// <returns>Обновлённая информация о пользователе.</returns>
        public async Task<UserResponse> UpdateMe(UserRequest request, int userId)
        {
            if (request == null)
            {
                _logger.LogWarning("UpdateMe called with null request.");
                throw new ArgumentNullException(nameof(request));
            }

            _logger.LogInformation("Updating current user information for userId: {UserId}", userId);

            var result = await _userApiClient.UpdateMe(request);

            if (result == null)
            {
                _logger.LogWarning("UpdateMe returned null for userId: {UserId}", userId);
                return new UserResponse();
            }

            _logger.LogInformation("User updated successfully for userId: {UserId}", userId);
            return result;
        }


        //===========================================================================================
        //		UPDATE PASSWORD
        //===========================================================================================
        /// <summary>
        /// Изменяет пароль текущего пользователя.
        /// </summary>
        /// <param name="request">Данные для смены пароля (старый и новый пароль).</param>
        /// <returns>True, если пароль успешно изменён.</returns>
        public async Task<bool> ChangePassword(ChangePasswordRequest request, int userId)
        {
            if (request == null)
            {
                _logger.LogWarning("ChangePassword called with null request.");
                throw new ArgumentNullException(nameof(request));
            }

            _logger.LogInformation("Changing password for userId: {UserId}", userId);

            var result = await _userApiClient.ChangePassword(request);

            if (!result)
            {
                _logger.LogWarning("Password change failed for userId: {UserId}", userId);
                throw new ValidationException("Old password is incorrect");
            }

            _logger.LogInformation("Password changed successfully for userId: {UserId}", userId);
            return result;
        }

        //===========================================================================================
        //		UPDATE EMAIL
        //===========================================================================================
        /// <summary>
        /// Изменяет email текущего пользователя.
        /// </summary>
        /// <param name="request">Данные для смены email.</param>
        /// <returns>True, если email успешно изменён.</returns>
        public async Task<bool> ChangeEmail(ChangeEmailRequest request, int userId)
        {
            if (request == null)
            {
                _logger.LogWarning("ChangeEmail called with null request.");
                throw new ArgumentNullException(nameof(request));
            }

            _logger.LogInformation("Changing email for userId: {UserId}", userId);

            var result = await _userApiClient.ChangeEmail(request);

            if (!result)
            {
                _logger.LogWarning("Email change failed for userId: {UserId}", userId);
                throw new ValidationException("Email cannot be empty");
            }

            _logger.LogInformation("Email changed successfully for userId: {UserId}", userId);
            return result;
        }

        //===========================================================================================
        //		DELETE
        //===========================================================================================
        /// <summary>
        /// Удаляет пользователя по userId.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>True, если пользователь успешно удалён.</returns>
        public async Task<bool> DeleteAsync(int userId)
        {
            _logger.LogInformation("Attempting to delete user with userId: {UserId}", userId);

            var result = await _userApiClient.DeleteAsync(userId);

            if (!result)
            {
                _logger.LogWarning("User not found or deletion failed for userId: {UserId}", userId);
                throw new Exception("Пользователь не найден");
            }

            _logger.LogInformation("User successfully deleted with userId: {UserId}", userId);
            return result;
        }
    }
}
