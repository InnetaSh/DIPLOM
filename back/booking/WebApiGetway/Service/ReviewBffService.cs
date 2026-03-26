
using Microsoft.AspNetCore.Mvc;
using OfferContracts;
using OfferContracts.RentObj;
using OrderContracts;
using ReviewContracts;
using StatisticContracts;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using TranslationContracts;
using UserContracts;
using WebApiGetway.Clients.Interface;
using WebApiGetway.Helpers;
using WebApiGetway.Service.Interfase;
using WebApiGetway.View;
using static WebApiGetway.Helpers.TranslatorHelper;



namespace WebApiGetway.Service
{
    public class ReviewBffService : IReviewBffService
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
        public ReviewBffService
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



        //============================================================================================
        //      CREATING A REVIEW
        //============================================================================================
        /// <summary>
        /// Создает отзыв пользователя по заказу:
        /// 1. Проверяет, принадлежит ли заказ пользователю.
        /// 2. Создает отзыв через Review API.
        /// 3. Добавляет переводы (оригинал + авто-перевод).
        /// 4. Обогащает отзыв данными пользователя (имя, страна).
        /// 5. Начисляет пользователю скидку за оставленный отзыв.
        /// </summary>
        /// <param name="request">Данные для создания отзыва (UserId, OrderId, Comment, OfferId).</param>
        /// <param name="lang">Язык отзыва ("uk" или "en").</param>
        /// <returns>Созданный отзыв с дополнительной информацией.</returns>
        /// <exception cref="ArgumentNullException">Если request == null.</exception>
        /// <exception cref="ArgumentException">Если переданы некорректные данные.</exception>
        /// <exception cref="UnauthorizedAccessException">Если пользователь не владеет заказом.</exception>
        /// <exception cref="Exception">Если произошла ошибка при побочных операциях.</exception>
        public async Task<ReviewResponse> CreateReview(
              ReviewRequest request,
              string lang)
        {
            if (request.UserId <= 0)
                throw new ArgumentException("Invalid UserId");

            if (request.OrderId <= 0)
                throw new ArgumentException("Invalid OrderId");

            if (string.IsNullOrWhiteSpace(request.Comment))
                throw new ArgumentException("Comment cannot be empty");

            if (lang != "uk" && lang != "en")
                throw new ArgumentException("Unsupported language");

            _logger.LogInformation("Start CreateReview. UserId: {UserId}, OrderId: {OrderId}", request.UserId, request.OrderId);

            var (userIdRequest, status) = await _helpers.GetClientIdAndStatusFromOrder(request.OrderId);

            if (userIdRequest != request.UserId)
            {
                _logger.LogWarning("User {UserId} попытался оставить отзыв на чужой заказ {OrderId}", request.UserId, request.OrderId);
                throw new UnauthorizedAccessException("Order does not belong to user");
            }
            
            var user = await _userApiClient.GetUserByIdAsync(request.UserId);
            if (user == null)
                throw new Exception("User not found");

            var userName = user.Username;
            int countryId = user.CountryId;

            var translationsCountry = await _translationClient.GetCountryTranslationByIdAsync(countryId, lang);
            var countryTitle = translationsCountry.Title ?? "N/A";

            var review = await _reviewApiClient.CreateReviewAsync(request);
            var reviewId = review.id;

            var sourceLang = lang; // "uk" или "en"
            var targetLang = sourceLang == "uk" ? "en" : "uk";

            var sourceTranslation = new TranslationRequest
            {
                EntityId = reviewId,
                Lang = sourceLang,
                Title = request.Comment,
            };

            var translatedTranslation = new TranslationRequest
            {
                EntityId = reviewId,
                Lang = targetLang,

            };

            translatedTranslation.Title = await Translator.TranslateAsync(request.Comment, sourceLang, targetLang);

            var sourceTask = _translationClient.AddReviewTranslationAsync(sourceTranslation, sourceLang);
            var translatedTask = _translationClient.AddReviewTranslationAsync(translatedTranslation, targetLang);

            await Task.WhenAll(sourceTask, translatedTask);

            var sourceTranslationResult = await sourceTask;
            var translatedTranslationResult = await translatedTask;

            review.UserName = userName;
            review.UserCountry = countryTitle;
            review.Title = request.Comment;
            review.OfferId = request.OfferId;

            decimal discountCount = 0.1m;

            review.OfferId = request.OfferId;
            var discount = await _userApiClient.UpdateDiscount(request.UserId, discountCount);

            if (!discount)
            {
                _logger.LogError("Не удалось обновить скидку для пользователя {UserId}", request.UserId);
                throw new Exception("Ошибка при обновлении скидки");
            }

            _logger.LogInformation("Review успешно создан. ReviewId: {ReviewId}", reviewId);

            return review;
        }


        //===============================================================================================================
        //      GET REVIEW BY offerId
        //===============================================================================================================
        /// <summary>
        /// Получает список отзывов по OfferId:
        /// 1. Загружает отзывы.
        /// 2. Подтягивает переводы для указанного языка.
        /// 3. Мержит переводы с отзывами.
        /// 4. Обогащает каждый отзыв данными пользователя (имя, email, страна).
        /// </summary>
        /// <param name="offerId">Идентификатор оффера.</param>
        /// <param name="lang">Язык ("uk" или "en").</param>
        /// <returns>Коллекция отзывов.</returns>
        /// <exception cref="ArgumentException">Если переданы некорректные параметры.</exception>
        public async Task<IEnumerable<ReviewResponse>> GetReviewByOffer(
           int offerId,
           string lang)
        {
            if (offerId <= 0)
                throw new ArgumentException("Invalid offerId");

            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language is required");

            _logger.LogInformation("Start GetReviewByOffer. OfferId: {OfferId}, Lang: {Lang}", offerId, lang);

            var reviewsTask = _reviewApiClient.GetOfferReviewsByOfferIdAsync(offerId);
            var translateListTask = _translationClient.GetAllReviewsTranslationsAsync(lang);

            await Task.WhenAll(reviewsTask, translateListTask);

            var reviews = await reviewsTask ?? Enumerable.Empty<ReviewResponse>();
            var reviewsTranslations = await translateListTask ?? Enumerable.Empty<TranslationResponse>();

            if (!reviews.Any())
            {
                _logger.LogInformation("No reviews found for OfferId: {OfferId}", offerId);
                return reviews;
            }

            MergeHelper.Merge(
                reviews,
                reviewsTranslations,
                c => c.id,
                r => r.EntityId
              );

            var semaphore = new SemaphoreSlim(10);
            var tasks = reviews.Select(async review =>
            {
                await semaphore.WaitAsync();
                try
                {
                    var user = await _userApiClient.GetUserByIdAsync(review.UserId);
                    if (user == null)
                    {
                        review.UserName = "Unknown";
                        review.UserEmail = "N/A";
                        review.UserCountry = "N/A";
                        return;
                    }
                    review.UserName = user.Username;
                    review.UserEmail = user.Email;

                    var countryTask = _translationClient
                        .GetCountryTranslationByIdAsync(user.CountryId, lang);

                    var countryTitle = await countryTask;
                    review.UserCountry = countryTitle.Title ?? "N/A";
                }
                finally
                {
                    semaphore.Release();
                }
            });

            await Task.WhenAll(tasks);
            _logger.LogInformation("Finished GetReviewByOffer. Count: {Count}", reviews.Count());

            return reviews;
        }

        //===============================================================================================================
        //        RECEIVING REVIEW BY userId
        //===============================================================================================================
        /// <summary>
        /// Получает список отзывов по UserId:
        /// 1. Загружает отзывы пользователя.
        /// 2. Подтягивает переводы для указанного языка.
        /// 3. Мержит переводы с отзывами.
        /// 4. Обогащает отзывы данными пользователя (имя, email, страна).
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="lang">Язык ("uk" или "en").</param>
        /// <returns>Коллекция отзывов пользователя.</returns>
        /// <exception cref="ArgumentException">Если переданы некорректные параметры.</exception>
        public async Task<IEnumerable<ReviewResponse>> GetReviewByUser(
            int userId,
            string lang)
        {
            if (userId <= 0)
                throw new ArgumentException("Invalid userId");

            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language is required");

            _logger.LogInformation("Start GetReviewByUser. UserId: {UserId}, Lang: {Lang}", userId, lang);

            var reviewsTask = _reviewApiClient.GetOfferReviewsByUserIdAsync(userId);
            var translateListTask = _translationClient.GetAllReviewsTranslationsAsync(lang);

            await Task.WhenAll(reviewsTask, translateListTask);

            var reviews = await reviewsTask ?? Enumerable.Empty<ReviewResponse>();
            var reviewsTranslations = await translateListTask ?? Enumerable.Empty<TranslationResponse>();

            if (!reviews.Any())
            {
                _logger.LogInformation("No reviews found for UserId: {UserId}", userId);
                return reviews;
            }
            MergeHelper.Merge(
                reviews,
                reviewsTranslations,
                c => c.id,
                r => r.EntityId
              );

            var semaphore = new SemaphoreSlim(10);
            var tasks = reviews.Select(async review =>
            {
                await semaphore.WaitAsync();
                try
                {
                    var user = await _userApiClient.GetUserByIdAsync(review.UserId);
                    if (user == null)
                    {
                        review.UserName = "Unknown";
                        review.UserEmail = "N/A";
                        review.UserCountry = "N/A";
                        return;
                    }

                    var countryTask = _translationClient
                        .GetCountryTranslationByIdAsync(user.CountryId, lang);

                    review.UserName = user.Username;
                    review.UserEmail = user.Email;

                    var country = await countryTask;
                    review.UserCountry = country?.Title ?? "N/A";
                }
                finally
                {
                    semaphore.Release();
                }
            });

            await Task.WhenAll(tasks);
            _logger.LogInformation("Finished GetReviewByUser. Count: {Count}", reviews.Count());

            return reviews;
        }


        //===============================================================================================================
        //     EDITING REVIEWS 
        //===============================================================================================================
        /// <summary>
        /// Обновляет отзыв:
        /// 1. Проверяет, принадлежит ли заказ пользователю.
        /// 2. Обновляет отзыв через Review API.
        /// 3. Обновляет переводы (оригинал + авто-перевод).
        /// </summary>
        /// <param name="request">Данные отзыва (UserId, OrderId, Comment и т.д.).</param>
        /// <param name="reviewId">Идентификатор отзыва.</param>
        /// <param name="lang">Язык ("uk" или "en").</param>
        /// <returns>Обновленный отзыв.</returns>
        /// <exception cref="ArgumentNullException">Если request == null.</exception>
        /// <exception cref="ArgumentException">Если переданы некорректные данные.</exception>
        /// <exception cref="UnauthorizedAccessException">Если пользователь не владеет заказом.</exception>

        public async Task<ReviewResponse> UpdateReviewById(
            ReviewRequest request,
             int reviewId,
            string lang)
        {
            if (reviewId <= 0)
                throw new ArgumentException("Invalid reviewId");

            if (request.UserId <= 0)
                throw new ArgumentException("Invalid UserId");

            if (request.OrderId <= 0)
                throw new ArgumentException("Invalid OrderId");

            if (string.IsNullOrWhiteSpace(request.Comment))
                throw new ArgumentException("Comment cannot be empty");

            if (lang != "uk" && lang != "en")
                throw new ArgumentException("Unsupported language");

            _logger.LogInformation(
                "Start UpdateReviewById. ReviewId: {ReviewId}, UserId: {UserId}",
                reviewId,
                request.UserId);

            var (userIdRequest, status) = await _helpers.GetClientIdAndStatusFromOrder(request.OrderId);
            if (userIdRequest != request.UserId)
            {
                _logger.LogWarning(
                    "User {UserId} попытался обновить чужой отзыв. OrderId: {OrderId}",
                    request.UserId,
                    request.OrderId);

                throw new UnauthorizedAccessException("Order does not belong to user");
            }

           
            var review = await _reviewApiClient.UpdateReviewAsync(reviewId, request);
            if (review == null)
                throw new Exception("Failed to update review");


            var sourceLang = lang; // "uk" или "en"
            var targetLang = sourceLang == "uk" ? "en" : "uk";

            var sourceTranslation = new TranslationRequest
            {
                EntityId = reviewId,
                Lang = sourceLang,
                Title = request.Comment,
            };

            var translatedTranslation = new TranslationRequest
            {
                EntityId = reviewId,
                Lang = targetLang,

            };

            translatedTranslation.Title = await Translator.TranslateAsync(request.Comment, sourceLang, targetLang);

            var sourceTask = _translationClient.UpdateReviewTranslationAsync(sourceTranslation, sourceLang);
            var translatedTask = _translationClient.UpdateReviewTranslationAsync(translatedTranslation, targetLang);

            try
            {
                await Task.WhenAll(sourceTask, translatedTask);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save translations for ReviewId: {ReviewId}", reviewId);
                throw new Exception("Failed to save translations", ex);
            }


            return review;
        }

        //===============================================================================================================
        //       DELETE REVIEW BY reviewId
        //===============================================================================================================
        /// <summary>
        /// Удаляет отзыв:
        /// 1. Проверяет, принадлежит ли заказ пользователю.
        /// 2. Удаляет отзыв.
        /// 3. Удаляет связанные переводы.
        /// </summary>
        /// <param name="reviewId">Идентификатор отзыва.</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="orderId">Идентификатор заказа.</param>
        /// <returns>true если удаление выполнено успешно.</returns>
        /// <exception cref="ArgumentException">Если переданы некорректные параметры.</exception>
        /// <exception cref="UnauthorizedAccessException">Если пользователь не владеет заказом.</exception>
        public async Task<bool> DeleteReviewById(
           int userId,
           int reviewId,
           int orderId)
        {
            if (reviewId <= 0)
                throw new ArgumentException("Invalid reviewId");

            if (userId <= 0)
                throw new ArgumentException("Invalid userId");

            if (orderId <= 0)
                throw new ArgumentException("Invalid orderId");

            _logger.LogInformation(
                "Start DeleteReviewById. ReviewId: {ReviewId}, UserId: {UserId}",
                reviewId,
                userId);

            var (userIdRequest, status) = await _helpers.GetClientIdAndStatusFromOrder(orderId);

            if (userIdRequest != userId)
            {
                _logger.LogWarning(
                    "User {UserId} попытался удалить чужой отзыв. OrderId: {OrderId}",
                    userId,
                    orderId);

                throw new UnauthorizedAccessException("Order does not belong to user");
            }

            var deleteReviewTask = _reviewApiClient.DeleteReviewAsync(reviewId);
            var deleteTranslationTask = _translationClient.DeleteReviewTranslationAsync(reviewId);

            await Task.WhenAll(deleteReviewTask, deleteTranslationTask);

            _logger.LogInformation("Review and translations delete requested. ReviewId: {ReviewId}", reviewId);

            return true;
            
        }




    }
}
