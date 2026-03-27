
using Globals.Exceptions;
using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using OfferContracts;
using OfferContracts.RentObj;
using ReviewContracts;
using StatisticContracts;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using TranslationContracts;
using UserContracts;
using WebApiGetway.Clients.Interface;
using WebApiGetway.Helpers;
using WebApiGetway.Service.Interfase;
using static WebApiGetway.Helpers.TranslatorHelper;


namespace WebApiGetway.Service
{
    public class OfferBffService : IOfferBffService
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

        public OfferBffService
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
        //      PARAMS CATEGORIES WITH PARAMS AND TRANSLATION
        //===============================================================================================================
        /// <summary>
        /// Получает категории параметров с параметрами и переводами на указанном языке.
        /// В случае отсутствия переводов используется fallback-язык.
        /// </summary>
        /// <param name="lang">Код языка (например: "en", "uk", "ru").</param>
        /// <returns>Коллекция категорий параметров с параметрами и переводами.</returns>
        public async Task<IEnumerable<ParamsCategoryResponse>> GetAllParamCategoryWithParamsAndTranslations(string lang)
        {
            _logger.LogInformation("Start fetching params categories with params and translations. Lang: {Lang}", lang);

            var categoriesTask =  _offerApiClient.GetAllParamCategoryWithParams();
            var categoriesTranslationTask = _translationClient.GetParamsCategotiesTranslationAsync(lang);
            var paramsItemTranslationTask = _translationClient.GetParamsItemTranslationAsync(lang);
            await Task.WhenAll(categoriesTask, categoriesTranslationTask, paramsItemTranslationTask);

            var categories = categoriesTask.Result ?? Enumerable.Empty<ParamsCategoryResponse>();
            var categoriesTranslation = categoriesTranslationTask.Result ?? Enumerable.Empty<TranslationResponse>();
            var paramsItemTranslation = paramsItemTranslationTask.Result ?? Enumerable.Empty<TranslationResponse>();

            if (!categories.Any())
            {
                _logger.LogWarning("No categories received from Offer service.");
                return Enumerable.Empty<ParamsCategoryResponse>();
            }

            if (!categoriesTranslation.Any())
                _logger.LogWarning("No categories translations received for lang {Lang}", lang);
            if (!paramsItemTranslation.Any())
                _logger.LogWarning("No paramsItem translations received for lang {Lang}", lang);
            MergeHelper.Merge(
                categories,
                categoriesTranslation,
                c => c.id,
                t => t.EntityId);

            var semaphore = new SemaphoreSlim(10);
            var tasks = categories.Select(async category =>
            {
                if (category.Items?.Any() != true) return;

                await semaphore.WaitAsync();
                try
                {
                    MergeHelper.Merge(category.Items, paramsItemTranslation, r => r.id, t => t.EntityId);
                }
                finally
                {
                    semaphore.Release();
                }
            });

            await Task.WhenAll(tasks);

            _logger.LogInformation("Merge completed for categories with paramsItem translations.");
            _logger.LogInformation(
                "Retrieved {Count} categories with paramsItem and translations for lang {Lang}",
                categories.Count(),
                lang
            );
            return categories ;
        }

        //===============================================================================================================
        //      PARAMS WITH TRANSLATIONS
        //===============================================================================================================
        /// <summary>
        /// Получает параметры с переводами на указанном языке.
        /// В случае отсутствия переводов используется fallback-язык.
        /// </summary>
        /// <param name="lang">Код языка (например: "en", "uk", "ru").</param>
        /// <returns>Коллекция параметров с переводами.</returns>
        public async Task<IEnumerable<ParamItemResponse>> GetMainParamItem(string lang)
        {
            _logger.LogInformation("Start fetching params categories with params and translations. Lang: {Lang}", lang);

            var paramsItemsTask = _offerApiClient.GetAllParamsItems();        
            var paramsItemTranslationTask = _translationClient.GetParamsItemTranslationAsync(lang);
            await Task.WhenAll(paramsItemsTask, paramsItemTranslationTask);

            var paramsItems = paramsItemsTask.Result;
            var paramsItemTranslation = paramsItemTranslationTask.Result ?? Enumerable.Empty<TranslationResponse>();

            if (!paramsItems.Any())
            {
                _logger.LogWarning("No paramsItems received from Offer service.");
                return Enumerable.Empty<ParamItemResponse>();
            }

            if (!paramsItemTranslation.Any())
                _logger.LogWarning("No paramsItem translations received for lang {Lang}", lang);

            _logger.LogInformation("Retrieved {Count} paramsItems", paramsItems.Count());
            _logger.LogInformation("Retrieved {Count} paramsItem translations", paramsItemTranslation.Count());

            MergeHelper.Merge(
                paramsItems,
                paramsItemTranslation,
                c => c.id,
                t => t.EntityId);

           
            _logger.LogInformation("Merge completed for categories with paramsItem translations.");
            _logger.LogInformation(
                "Retrieved {Count} categories with paramsItem and translations for lang {Lang}",
                paramsItems?.Count() ?? 0,
                lang
            );

            return paramsItems ?? Enumerable.Empty<ParamItemResponse>();
        }



        //===============================================================================================================
        //                    GET ALL OFFERS (FOR ADMIN)
        //===============================================================================================================
        /// <summary>
        /// Получает все объявления с переводами и рейтингами для админа.
        /// В случае отсутствия переводов используется fallback-язык.
        /// </summary>
        /// <param name="lang">Код языка (например: "en", "uk", "ru").</param>
        /// <returns>Коллекция объявлений с переводами и рейтингами.</returns>
        public async Task<IEnumerable<OfferResponse>> GetAllOffers(string lang, string accessToken)
        {
            _logger.LogInformation("Start aggregation for all offers with translation for admin. Lang: {Lang}", lang);
            var offersListTask = _offerApiClient.GetAllOffers(accessToken);
            var offersTranslationsListTask = _translationClient.GetAllOffersTranslationAsync(lang);
            await Task.WhenAll(offersListTask, offersTranslationsListTask);

            var offers = offersListTask.Result ?? Enumerable.Empty<OfferResponse>();
            var offersTranslations = offersTranslationsListTask.Result ?? Enumerable.Empty<TranslationResponse>();

            if (!offers.Any())
            {
                _logger.LogWarning("No offers received from Offer service.");
                return Enumerable.Empty<OfferResponse>();
            }

            if (!offersTranslations.Any())
                _logger.LogWarning("No offers translations received for lang {Lang}", lang);

            _logger.LogInformation("Retrieved {Count} offers", offers.Count());
            _logger.LogInformation("Retrieved {Count} offers translations", offersTranslations.Count());


            MergeHelper.Merge(
               offers,
               offersTranslations,
               c => c.id,
               t => t.EntityId
             );

            _logger.LogInformation("Merge completed for offers translations.");

            var idList = offers?
               .Where(x => x != null)
               .Select(x => x.id)
               .ToList() ?? new List<int>();
            var offersRatings = await _reviewApiClient.GetOffersRatingAsync(idList);

            MergeHelper.Merge(
               offers,
               offersRatings,
               c => c.id,
               r => r.OfferId
             );

            _logger.LogInformation("Merge completed for offers rating.");

            _logger.LogInformation(
              "Retrieved {Count} offers  with translations ang rating for lang {Lang}",
              offers?.Count() ?? 0,
              lang
          );

            return offers ?? Enumerable.Empty<OfferResponse>();
        }

        //===============================================================================================================
        //      SEARCHES FOR AVAILABLE OFFERS (HOTELS, APARTMENTS, ETC.) based on parameters
        //===============================================================================================================
        /// <summary>
        /// Выполняет поиск объявлений с фильтрацией по городу, региону, стране, датам, количеству гостей и параметрам.
        /// Параметры дат необязательные — если не переданы, используются сегодня и завтра.
        /// Возвращает список объявлений, удовлетворяющих условиям поиска.
        /// </summary>
        /// <param name="lang">Код языка (например: "en", "uk", "ru")</param>
        /// <param name="cityId">Идентификатор города</param>
        /// <param name="regionId">Идентификатор региона</param>
        /// <param name="countryId">Идентификатор страны</param>
        /// <param name="start">Дата заезда (по умолчанию сегодня)</param>
        /// <param name="end">Дата выезда (по умолчанию завтра)</param>
        /// <param name="adults">Количество взрослых</param>
        /// <param name="children">Количество детей</param>
        /// <param name="rooms">Количество комнат</param>
        /// <param name="totalGuests">Общее количество гостей (adults + children)</param>
        /// <param name="userDiscountPercent">Процент скидки для пользователя</param>
        /// <returns>Список объявлений с переводами и рейтингами</returns>

        /// 
        public async Task<IEnumerable<OfferResponse>> GetOffersBySearchCriteria(
           int? userId,
           decimal userDiscountPercent,
           string lang,
           int? cityId,
           int? regionId,
           int? countryId,
           DateOnly? startDate = null,
           DateOnly? endDate = null,
           int adults = 1,
           int children = 0,
           int rooms = 1,
           string? paramItemFilters = null)
        {
            var checkInDateOnly = startDate ?? DateOnly.FromDateTime(DateTime.Today);
            var checkOutDateOnly = endDate ?? checkInDateOnly.AddDays(1);

            var checkIn = checkInDateOnly.ToDateTime(TimeOnly.MinValue);
            var checkOut = checkOutDateOnly.ToDateTime(TimeOnly.MinValue); 

          
            var totalGuests = adults + children;

            _logger.LogInformation(
               "Search offers for lang {Lang}, city {CityId}, region {RegionId}, country {CountryId}, dates {Start}-{End}, guests {Guests}",
               lang, cityId, regionId, countryId, checkIn, checkOut, totalGuests
           );

            var offersTask = (cityId.HasValue && cityId.Value != -1)
               ? _offerApiClient.GetOffersByCityAsync(cityId.Value, checkIn, checkOut, adults, children, rooms, totalGuests, userDiscountPercent)
               : (regionId.HasValue && regionId.Value != -1)
                   ? _offerApiClient.GetOffersByRegionAsync(regionId.Value, checkIn, checkOut, adults, children, rooms, totalGuests, userDiscountPercent)
                   : (countryId.HasValue && countryId.Value != -1)
                       ? _offerApiClient.GetOffersByCountryAsync(countryId.Value, checkIn, checkOut, adults, children, rooms, totalGuests, userDiscountPercent)
                       : throw new ArgumentException("Не указан cityId, regionId или countryId");

            var translationsTask = _translationClient.GetAllOffersTranslationAsync(lang);

            var (entityId, entityType) = cityId.HasValue
              ? (cityId.Value, "City")
              : regionId.HasValue
                  ? (regionId.Value, "Region")
                  : (countryId.Value, "Country");

            _ = _helpers.SendStatEvent(new EntityStatEventRequest
            {
                EntityId = entityId,
                EntityType = entityType,
                ActionType = "Search",
                UserId = userId
            }, entityType);


            await Task.WhenAll(offersTask, translationsTask);

            var offers = offersTask.Result;


            //await _helpers.SendStatEvent(new EntityStatEventRequest
            //{
            //    EntityId = entityId,
            //    EntityType = entityType,
            //    ActionType = "Search",
            //    UserId = userId
            //}, entityType);

            if (offers == null || !offers.Any())
                return Enumerable.Empty<OfferResponse>();

            var offersTranslations = translationsTask.Result ?? Enumerable.Empty<TranslationResponse>();

            _logger.LogInformation("Retrieved {Count} offers and {CountTranslations} translations", offers.Count(), offersTranslations.Count());

            // фильтрация по датам (убираем объявления с конфликтующими датами)
            var offerChecks = await Task.WhenAll(
                 offers.Select(async offer => new
                 {
                     Offer = offer,
                     HasConflict = await _helpers.HasDateConflictAsync(offer.id, checkIn, checkOut)
                 })
             );

            offers = offerChecks
                .Where(x => !x.HasConflict)
                .Select(x => x.Offer)
                .ToList();

            // фильтрация по параметрам
            var filterDicts = _helpers.ParseParamFiltersToDict(paramItemFilters);
            if (filterDicts.Any())
            {
                offers = offers
                    .Where(offer =>
                        offer.RentObj?.ParamValues != null &&
                        _helpers.MatchAllFilters(offer.RentObj.ParamValues, filterDicts)
                    )
                    .ToList();
            }

            MergeHelper.Merge(
                offers,
                offersTranslations,
                c => c.id,
                t => t.EntityId
            );
            _logger.LogInformation("Merge completed for offers translations.");

            await Task.WhenAll(
                offers.Select(offer =>
                    _helpers.SendStatEvent(new EntityStatEventRequest
                    {
                        EntityId = offer.id,
                        EntityType = "Offer",
                        ActionType = "Search",
                        UserId = userId
                    }, "Offer")
                )
            );

        

            var idList = offers.Select(x => x.id).ToList();
            var offersRatings = await _reviewApiClient.GetOffersRatingAsync(idList);
            MergeHelper.Merge(
                offers,
                offersRatings,
                c => c.id,
                r => r.OfferId
            );
            _logger.LogInformation("Merge completed for offers ratings.");

            return offers;
        }




        //===============================================================================================================
        //      GET FULL OFFER DATA BY offerId WITH TRANSLATIONS AND RATINGS
        //===============================================================================================================
        /// <summary>
        /// Получает полные данные об объявлении по его идентификатору.
        /// Включает переводы (Offer, Country, Region, City, District, Params) и рейтинг.
        /// В случае отсутствия данных возвращает новый объект OfferResponse.
        /// </summary>
        /// <param name="offerId">Идентификатор объявления</param>
        /// <param name="lang">Код языка для перевода (например: "en", "uk", "ru")</param>
        /// <param name="startDate">Дата заезда (по умолчанию сегодня)</param>
        /// <param name="endDate">Дата выезда (по умолчанию завтра)</param>
        /// <param name="adults">Количество взрослых</param>
        /// <param name="children">Количество детей</param>
        /// <param name="rooms">Количество комнат</param>
        /// <param name="userDiscountPercent">Процент скидки пользователя</param>
        /// <returns>Полный объект OfferResponse с переводами и рейтингами</returns>
        public async Task<OfferResponse?> GetFullOfferById(
         string? accessToken,
         int userId,
         int offerId,
         string lang,
         DateOnly? startDate = null,
         DateOnly? endDate = null,
         int adults = 1,
         int children = 0,
         int rooms = 1,
         decimal userDiscountPercent = 0)
        {
            var offer = await _offerApiClient.GetFullOfferById(
                   offerId,
                   startDate?.ToString("yyyy-MM-dd"),
                   endDate?.ToString("yyyy-MM-dd"),
                   adults,
                   children,
                   rooms,
                   userDiscountPercent
               );

            if (offer == null)
            {
                _logger.LogWarning("Offer not found for offerId: {OfferId}", offerId);
                return null;
            }

            var countryId = offer.RentObj?.CountryId ?? 0;
            var regionId = offer.RentObj?.RegionId ?? 0;
            var cityId = offer.RentObj?.CityId ?? 0;
            var districtId = offer.RentObj?.DistrictId ?? 0;

            var translationsOfferTask = _translationClient.GetOfferTranslationByIdAsync(offerId, lang);
            var translationsCountryTask = _translationClient.GetCountryTranslationByIdAsync(countryId, lang);
            var translationsRegionTask = _translationClient.GetRegionTranslationByIdAsync(regionId, lang);
            var translationsCityTask = _translationClient.GetCityTranslationByIdAsync(cityId, lang);
            var translationsDistrictTask = _translationClient.GetDistrictyTranslationByIdAsync(districtId, lang);

            var translationsParamsTask = _translationClient.GetParamsItemTranslationAsync(lang);

            await Task.WhenAll(
                translationsOfferTask,
                translationsCountryTask,
                translationsRegionTask,
                translationsCityTask,
                translationsDistrictTask,
                translationsParamsTask
            );
            var offerTranslation = translationsOfferTask.Result ?? new TranslationResponse();
            var countryTranslation = translationsCountryTask.Result ?? new TranslationResponse();
            var regionTranslation = translationsRegionTask.Result ?? new TranslationResponse();
            var cityTranslation = translationsCityTask.Result ?? new TranslationResponse();
            var districtTranslation = translationsDistrictTask.Result ?? new TranslationResponse();
            var paramsItemTranslation = translationsParamsTask.Result ?? Enumerable.Empty<TranslationResponse>();

            if (offer.RentObj?.ParamValues != null)
            {
                MergeHelper.Merge(
                  offer.RentObj.ParamValues,
                  paramsItemTranslation,
                  c => c.ParamItemId,
                  r => r.EntityId
                );
            }
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                _ = Task.Run(() => _userApiClient.AddOffersToClientHistory(offerId, accessToken));
            }
            
            var entityStatEventRequest = new EntityStatEventRequest
            {
                EntityId = offerId,
                EntityType = "Offer",
                ActionType = "View",
                UserId = userId
            };
            var entityStatCityEventRequest = new EntityStatEventRequest
            {
                EntityId = cityId,
                EntityType = "City",
                ActionType = "View",
                UserId = userId
            };
            await Task.WhenAll(
                 _helpers.SendStatEvent(entityStatEventRequest, "Offer"),
                 _helpers.SendStatEvent(entityStatCityEventRequest, "City")
             );



            MergeHelper.MergeSingle(offer, offerTranslation);
            
            offer.RentObj.CountryTitle = countryTranslation.Title ?? "N/A";
            offer.RentObj.CityTitle = cityTranslation.Title ?? "N/A";

            _logger.LogInformation("Fetching reviews for OfferId: {OfferId}", offerId);
            var offerRating = await _reviewApiClient.GetOfferReviewsByOfferIdAsync(offer.id);
            MergeHelper.MergeSingle(
                offer,
                offerRating
            );
            _logger.LogInformation("Merge completed for offer rating and translations. OfferId: {OfferId}", offerId);

            return offer;
        }


        //===============================================================================================================
        //       GET FULL OFFER DETAILS BY offerId AND orderId FOR USER HISTORY 
        //===============================================================================================================
        /// <summary>
        ///		Возвращает полную информацию об обьявлении (Offer) по идентификатору объявления и брони (orderId).
        ///		Метод агрегирует данные о стране, регионе, городе, районе, параметрах, переводах и рейтингах.
        ///		Также добавляет информацию о брони: количество взрослых, детей, даты заезда/выезда и общую стоимость.
        /// </summary>
        /// <param name="offerId">Идентификатор объявления</param>
        /// <param name="orderId">Идентификатор брони (Order)</param>
        /// <param name="lang">Код языка для переводов (например: "en", "uk", "ru")</param>
        /// <returns>Объект OfferResponse с полными данными, переводами и рейтингами</returns>

        [HttpGet("search/booking-offer/{offerId}/{orderId}/{lang}")]
        public async Task<OfferResponse?> GetOfferByIdForOrderHistory(
             int offerId,
             int orderId,
             string lang)
        {
            if (offerId <= 0 || orderId <= 0)
                _logger.LogWarning("Invalid offerId or orderId");

            _logger.LogInformation("Start aggregation for offerId: {OfferId}, orderId: {OrderId}, lang: {Lang}", offerId, orderId, lang);

            var offer = await _offerApiClient.GetOfferById(offerId );
            if (offer == null)
            {
                _logger.LogWarning("Offer not found for offerId: {OfferId}", offerId);
                return null;
            }

            var countryId = offer.RentObj?.CountryId ?? 0;
            var regionId = offer.RentObj?.RegionId ?? 0;
            var cityId = offer.RentObj?.CityId ?? 0;
            var districtId = offer.RentObj?.DistrictId ?? 0;

            var translationsOfferTask = _translationClient.GetOfferTranslationByIdAsync(offerId, lang);
            var translationsCountryTask = _translationClient.GetCountryTranslationByIdAsync(countryId, lang);
            var translationsRegionTask = _translationClient.GetRegionTranslationByIdAsync(regionId, lang);
            var translationsCityTask = _translationClient.GetCityTranslationByIdAsync(cityId, lang);
            var translationsDistrictTask = _translationClient.GetDistrictyTranslationByIdAsync(districtId, lang);

            var translationsParamsTask = _translationClient.GetParamsItemTranslationAsync(lang);

            await Task.WhenAll(
                translationsOfferTask,
                translationsCountryTask,
                translationsRegionTask,
                translationsCityTask,
                translationsDistrictTask,
                translationsParamsTask
            );
            var offerTranslation = translationsOfferTask.Result ?? new TranslationResponse();
            var countryTranslation = translationsCountryTask.Result ?? new TranslationResponse();
            var regionTranslation = translationsRegionTask.Result ?? new TranslationResponse();
            var cityTranslation = translationsCityTask.Result ?? new TranslationResponse();
            var districtTranslation = translationsDistrictTask.Result ?? new TranslationResponse();
            var paramsItemTranslation = translationsParamsTask.Result ?? Enumerable.Empty<TranslationResponse>();

            if (offer.RentObj?.ParamValues != null)
                MergeHelper.Merge(
                  offer.RentObj.ParamValues,
                  paramsItemTranslation,
                  c => c.ParamItemId,
                  r => r.EntityId
                );
            MergeHelper.MergeSingle(offer, offerTranslation);

            offer.RentObj.CountryTitle = countryTranslation.Title;
            offer.RentObj.CityTitle = cityTranslation.Title;

            var offerRating = await _reviewApiClient.GetOfferReviewsByOfferIdAsync(offer.id);
            MergeHelper.MergeSingle(
                offer,
                offerRating
            );
            _logger.LogInformation("Merge completed for offer rating for offerId: {OfferId}", offerId);

            var order = await _orderApiClient.GetOrderByIdAsync(orderId);
            if (order != null)
            {
                offer.Adults = order.Adults;
                offer.Children = order.Children;
                offer.StartDate = order.StartDate.ToString();
                offer.EndDate = order.EndDate.ToString();
                offer.TotalPrice = order.TotalPrice;
            }
            else
            {
                _logger.LogWarning("Order not found for orderId: {OrderId}", orderId);
            }

            return offer;
        }


        ////===============================================================================================================
        ////		GET REVIEWS FOR OFFER BY offerId
        ////===============================================================================================================

        ///// <summary>
        /////		Получает отзывы по объявлению (offerId).
        /////		Метод загружает список отзывов, подтягивает переводы и информацию о пользователях.
        /////		В случае отсутствия отзывов возвращает пустую коллекцию.
        ///// </summary>
        ///// <param name="offerId">Идентификатор объявления</param>
        ///// <param name="lang">Код языка (например: "en", "uk", "ru")</param>
        ///// <returns>Коллекция отзывов с переводами и именами пользователей</returns>
        //public async Task<IEnumerable<ReviewResponse>> GetReviewsByOfferId(
        //   int offerId,
        //   string lang)
        //{
        //    if (offerId <= 0)
        //        _logger.LogWarning("Invalid offerId or orderId");

        //    _logger.LogInformation("Start fetching reviews for OfferId: {OfferId}, Lang: {Lang}", offerId, lang);

        //    var reviewsTask =  _reviewApiClient.GetOfferReviewsByOfferIdAsync(offerId);
        //    var translationsReviewTask = _translationClient.GetAllReviewsTranslationsAsync(lang);
        //    await Task.WhenAll(reviewsTask, translationsReviewTask);

        //    var reviews = reviewsTask.Result ?? Enumerable.Empty<ReviewResponse>();

        //    if (!reviews.Any())
        //    {
        //        _logger.LogWarning("No reviews found for OfferId: {OfferId}", offerId);
        //        return Enumerable.Empty<ReviewResponse>();
        //    }
        //    var reviewsTranslations = translationsReviewTask.Result ?? Enumerable.Empty<TranslationResponse>();
        //    _logger.LogInformation("Retrieved {Count} reviews and {TranslationsCount} translations",
        //         reviews.Count(),
        //         reviewsTranslations.Count());

        //    var userTasks = reviews.Select(async review =>
        //    {
        //        var user = await _userApiClient.GetUserByIdAsync(review.UserId);
        //        review.UserName = user?.Username;
        //    });

        //    await Task.WhenAll(userTasks);

        //    MergeHelper.Merge(
        //       reviews,
        //        reviewsTranslations,
        //        c => c.id,
        //        r => r.EntityId
        //      );
        //    _logger.LogInformation("Merge completed for reviews translations");

        //    return reviews;
        //}


        

        //===============================================================================================================
        //		CREATE OFFER
        //===============================================================================================================

        /// <summary>
        ///		Создает новое объявление.
        ///		Метод валидирует пользователя (должен быть owner), устанавливает координаты города,
        ///		создает объявление, генерирует переводы и сохраняет их.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="offer">Данные объявления</param>
        /// <param name="lang">Язык исходного текста (например: "en", "uk")</param>
        /// <returns>Идентификатор созданного объявления</returns>
        public async Task<int> CreateOffer(
            int userId,
            OfferRequest offer,
            string lang,
            string accessToken)

        {
            _logger.LogInformation("Start creating offer. UserId: {UserId}, Lang: {Lang}", userId, lang);

            if (offer == null)
            {
                _logger.LogWarning("Offer request is null");
                return -1;
            }

            if (offer.RentObj?.ParamValues != null)
            {
                foreach (var param in offer.RentObj.ParamValues)
                {
                    param.ValueString ??= "";
                }
            }
            var (isOwner, error) = await _helpers.ValidateOwnerAsync(userId, accessToken);

            if (!isOwner)
            {
                _logger.LogWarning("User is not owner. UserId: {UserId}", userId);
                throw new UnauthorizedAccessException(error);
            }


            var city = await _locationClient.GetCityByIdAsync(offer.RentObj.CityId);
            offer.RentObj.CityLatitude = city.Latitude;
            offer.RentObj.CityLongitude = city.Longitude;

            var offerId = await _offerApiClient.CreateOffer(offer);
            if (offerId <= 0)
            {
                _logger.LogWarning("Offer creation failed.");
                return -1;
            }
            _logger.LogInformation("Offer created successfully. OfferId: {OfferId}", offerId);

            var sourceLang = lang; // "uk" или "en"
            var targetLang = sourceLang == "uk" ? "en" : "uk";

            var sourceTranslation = new TranslationRequest
            {
                EntityId = offerId,
                Lang = sourceLang,
                Title = offer.Title ?? "",
                TitleInfo = offer.TitleInfo,
                Description = offer.Description
            };

            var translatedTranslation = new TranslationRequest
            {
                EntityId = offerId,
                Lang = targetLang,

            };

            var titleTask = Translator.TranslateAsync(offer.Title ?? "", sourceLang, targetLang);
            var titleInfoTask = Translator.TranslateAsync(offer.TitleInfo ?? "", sourceLang, targetLang);
            var descriptionTask =  Translator.TranslateAsync(offer.Description ?? "", sourceLang, targetLang);

            await Task.WhenAll(titleTask, titleInfoTask, descriptionTask);

            translatedTranslation.Title = await titleTask;
            translatedTranslation.TitleInfo = await titleInfoTask;
            translatedTranslation.Description = await descriptionTask;

            var sourceTask = _translationClient.AddOfferTranslationAsync(sourceTranslation, sourceLang);
            var translatedTask = _translationClient.AddOfferTranslationAsync(translatedTranslation, targetLang);
            var addOfferTask = _userApiClient.AddOfferToClient(offerId, accessToken);

            await Task.WhenAll(sourceTask, translatedTask, addOfferTask);
            if (sourceTask.Result == null || translatedTask.Result == null)
            {
                _logger.LogWarning("Translation saving failed for OfferId: {OfferId}", offerId);
            }

            if (!addOfferTask.Result)
            {
                _logger.LogWarning("Failed to link offer to user. OfferId: {OfferId}, UserId: {UserId}", offerId, userId);
            }
            _logger.LogInformation("Offer creation process completed. OfferId: {OfferId}", offerId);

            //var sourceTranslationResult = await sourceTask;
            //var translatedTranslationResult = await translatedTask;
            //var addOfferToClient = await addOfferTask;

            return offerId;
        }

        //===============================================================================================================
        //		UPDATE OFFER
        //===============================================================================================================

        /// <summary>
        ///		Редактирует объявление.
        ///		Метод проверяет владельца, обновляет данные объявления,
        ///		пересоздает переводы и синхронизирует связанные данные.
        /// </summary>
        /// <param name="offer">Данные объявления</param>
        /// <param name="lang">Язык исходного текста (например: "en", "uk")</param>
        /// <returns>Обновленное объявление</returns>

        public async Task<OfferResponse> UpdateOffer(
              int offerId,
              OfferRequest offer,
              string lang,
              string accessToken)
        {
            if (offer == null)
            {
                _logger.LogWarning("Offer request is null");
                return new OfferResponse();
            }

            _logger.LogInformation("Start updating offer. OfferId: {OfferId}, Lang: {Lang}", offerId, lang);

            var isValid = await _userApiClient.ValidOfferIdByOwner(offerId, accessToken );
            if (!isValid)
            {
                _logger.LogWarning("Unauthorized update attempt. OfferId: {OfferId}", offerId);
                throw new UnauthorizedAccessException("Вы не являетесь владельцем этого объявления");
            }

            if (offer.RentObj == null)
            {
                _logger.LogWarning("RentObj is null for OfferId: {OfferId}", offerId);
                return new OfferResponse();
            }

            var translationsCountryTask = _translationClient.GetCountryTranslationByIdAsync(offer.RentObj.CountryId, lang);
            var translationsCityTask = _translationClient.GetCityTranslationByIdAsync(offer.RentObj.CityId, lang);
           
           
            await Task.WhenAll(
                translationsCountryTask,
                translationsCityTask
            );
            var countryTranslation = translationsCountryTask.Result ?? new TranslationResponse();
            var cityTranslation = translationsCityTask.Result ?? new TranslationResponse();

            offer.RentObj.CountryTitle = countryTranslation.Title ?? "N/A";
            offer.RentObj.CityTitle = cityTranslation.Title ?? "N/A";

            var offerUpdate = await _offerApiClient.UpdateOffer(offerId,offer);

            if (offerUpdate?.id != offerId)
            {
                _logger.LogError("Offer ID mismatch after update. Expected: {OfferId}, Actual: {ActualId}", offerId, offerUpdate?.id);
                throw new Exception("Offer ID mismatch after update.");
            }

            _logger.LogInformation("Offer updated successfully. OfferId: {OfferId}", offerId);

            var sourceLang = lang; // "uk" или "en"
            var targetLang = sourceLang == "uk" ? "en" : "uk";

            var sourceTranslation = new TranslationRequest
            {
                EntityId = offerId,
                Lang = sourceLang,
                Title = offer.Title ?? "",
                TitleInfo = offer.TitleInfo,
                Description = offer.Description
            };

            var translatedTranslation = new TranslationRequest
            {
                EntityId = offerId,
                Lang = targetLang,

            };

            var titleTask = Translator.TranslateAsync(offer.Title ?? "", sourceLang, targetLang);
            var titleInfoTask = Translator.TranslateAsync(offer.TitleInfo ?? "", sourceLang, targetLang);
            var descriptionTask = Translator.TranslateAsync(offer.Description ?? "", sourceLang, targetLang);

            await Task.WhenAll(titleTask, titleInfoTask, descriptionTask);

            translatedTranslation.Title = await titleTask;
            translatedTranslation.TitleInfo = await titleInfoTask;
            translatedTranslation.Description = await descriptionTask;

            var sourceTask = _translationClient.AddOfferTranslationAsync(sourceTranslation, sourceLang);
            var translatedTask = _translationClient.AddOfferTranslationAsync(translatedTranslation, targetLang);
            var addOfferTask = _userApiClient.AddOfferToClient(offerId, accessToken);

            await Task.WhenAll(sourceTask, translatedTask, addOfferTask);

            if (sourceTask.Result == null || translatedTask.Result == null)
            {
                _logger.LogWarning("Translation saving failed for OfferId: {OfferId}", offerId);
            }

            if (!addOfferTask.Result)
            {
                _logger.LogWarning("Failed to link offer to user. OfferId: {OfferId}", offerId);
            }

            _logger.LogInformation("Offer update process completed. OfferId: {OfferId}", offerId);

            return offerUpdate ?? new OfferResponse();
        }


        //===============================================================================================================
        //		UPDATE OFFER PRICE
        //===============================================================================================================

        /// <summary>
        ///		Обновляет цену объявления.
        ///		Метод проверяет, является ли пользователь владельцем объявления,
        ///		после чего обновляет цену и валидирует результат.
        /// </summary>
        /// <param name="offerId">Идентификатор объявления</param>
        /// <param name="updateOfferPriceRequest">Новые данные цены</param>
        /// <param name="lang">Код языка (не используется, но сохранён для совместимости)</param>
        /// <returns>Идентификатор объявления</returns>
        public async Task<int> UpdateOfferPrice(
            int offerId,
            UpdateOfferPriceRequest updateOfferPriceRequest,
            string lang,
            string accessToken)
        {
            if (updateOfferPriceRequest == null)
            {
                _logger.LogWarning("UpdateOfferPriceRequest is null. OfferId: {OfferId}", offerId);
                throw new ArgumentNullException(nameof(updateOfferPriceRequest));
            }

            _logger.LogInformation("Start updating offer price. OfferId: {OfferId}", offerId);


            var isOwner = await _userApiClient.ValidOfferIdByOwner(offerId, accessToken);
            if (!isOwner)
            {
                _logger.LogWarning("Unauthorized price update attempt. OfferId: {OfferId}", offerId);
                throw new UnauthorizedAccessException("Вы не являетесь владельцем этого объявления");
            }

            var offerUpdate = await _offerApiClient.UpdateOfferPrice(offerId, updateOfferPriceRequest);

            if (offerUpdate == null)
            {
                _logger.LogError("Offer update returned null. OfferId: {OfferId}", offerId);
                throw new Exception("Ошибка при обновлении цены объявления");
            }
            if (offerUpdate.id != offerId)
            {
                _logger.LogError(
                    "Offer ID mismatch after price update. Expected: {OfferId}, Actual: {ActualId}",
                    offerId,
                    offerUpdate.id
                );
                throw new Exception("Offer ID mismatch after price update.");
            }

            _logger.LogInformation("Offer price updated successfully. OfferId: {OfferId}", offerId);


            return offerId;
        }

        //===============================================================================================================
        //		UPDATE OFFER TEXT
        //===============================================================================================================

        /// <summary>
        ///		Обновляет текст объявления (заголовок, описание и дополнительную информацию).
        ///		Метод проверяет владельца объявления, выполняет перевод текста
        ///		на второй язык и сохраняет оба варианта.
        /// </summary>
        /// <param name="request">Данные перевода</param>
        /// <param name="lang">Язык исходного текста (например: "en", "uk")</param>
        /// <returns>Идентификатор объявления</returns>
        public async Task<int> UpdateTextOffer(
            TranslationRequest request,
            string lang,
            string accessToken)
        {
            _logger.LogInformation("Start updating offer text. OfferId: {OfferId}, Lang: {Lang}", request?.EntityId, lang);

            if (request == null)
            {
                _logger.LogWarning("TranslationRequest is null");
                throw new ArgumentNullException(nameof(request));
            }

            var offerId = request.EntityId;

            var isValid = await _userApiClient.ValidOfferIdByOwner(offerId, accessToken);
            if (!isValid)
            {
                _logger.LogWarning("Unauthorized text update attempt. OfferId: {OfferId}", offerId);
                throw new UnauthorizedAccessException("Вы не являетесь владельцем этого объявления");
            }
            var sourceLang = lang; // "uk" или "en"
            var targetLang = sourceLang == "uk" ? "en" : "uk";
            var sourceTranslation = new TranslationRequest
            {
                EntityId = offerId,
                Lang = sourceLang,
                Title = request.Title ?? "",
                TitleInfo = request.TitleInfo,
                Description = request.Description
            };

            var translatedTranslation = new TranslationRequest
            {
                EntityId = offerId,
                Lang = targetLang,

            };

            var titleTask = Translator.TranslateAsync(request.Title ?? "", sourceLang, targetLang);
            var titleInfoTask = Translator.TranslateAsync(request.TitleInfo ?? "", sourceLang, targetLang);
            var descriptionTask = Translator.TranslateAsync(request.Description ?? "", sourceLang, targetLang);

            await Task.WhenAll(titleTask, titleInfoTask, descriptionTask);

            translatedTranslation.Title = await titleTask;
            translatedTranslation.TitleInfo = await titleInfoTask;
            translatedTranslation.Description = await descriptionTask;

            var sourceTask = _translationClient.AddOfferTranslationAsync(sourceTranslation, sourceLang);
            var translatedTask = _translationClient.AddOfferTranslationAsync(translatedTranslation, targetLang);

            await Task.WhenAll(sourceTask, translatedTask);

            if (sourceTask.Result == null || translatedTask.Result == null)
            {
                _logger.LogWarning("Translation saving failed for OfferId: {OfferId}", offerId);
            }

            _logger.LogInformation("Offer text updated successfully. OfferId: {OfferId}", offerId);


            return offerId;
        }
        //===============================================================================================================
        //		ADD OFFER IMAGES
        //===============================================================================================================

        /// <summary>
        ///		Добавляет изображения к объявлению.
        ///		Метод проверяет владельца объявления, получает идентификатор объекта аренды
        ///		и загружает изображения параллельно.
        /// </summary>
        /// <param name="offerId">Идентификатор объявления</param>
        /// <param name="files">Список файлов изображений</param>
        /// <returns>Коллекция URL загруженных изображений</returns>
        public async Task<IEnumerable<string>> AddImageOffer(
          int offerId,
          List<IFormFile> files,
          string accessToken)
        {

            if (files == null || files.Count == 0)
            {
                _logger.LogWarning("No files provided. OfferId: {OfferId}", offerId);
                throw new ValidationException("Файлы не переданы");
            }
            _logger.LogInformation(
                 "Start adding images to offer. OfferId: {OfferId}, FilesCount: {Count}",
                 offerId,
                 files.Count
             );
            var isValid = await _userApiClient.ValidOfferIdByOwner(offerId, accessToken);
            if (!isValid)
            {
                _logger.LogWarning("Unauthorized image upload attempt. OfferId: {OfferId}", offerId);
                throw new ForbiddenException($"Вы не являетесь владельцем объявления {offerId}");
            }

            var rentObjId = await _offerApiClient.GetRentObjIdByOfferId(offerId);
            if (rentObjId <= 0)
            {
                _logger.LogError("Invalid RentObjId. OfferId: {OfferId}", offerId);
                throw new ValidationException("Некорректный идентификатор объекта аренды");
            }
            FileValidationHelper.ValidateFiles(files);
            var semaphore = new SemaphoreSlim(5);

            var tasks = files.Select(async file =>
            {
                await semaphore.WaitAsync();
                try
                {
                    var result = await _offerApiClient.AddImageOffer(rentObjId, file);

                    if (string.IsNullOrEmpty(result))
                    {
                        _logger.LogInformation(
                             "Uploading file. OfferId: {OfferId}, FileName: {FileName}, FileLength: {Length}",
                             offerId,
                             file.FileName,
                             file.Length
                         );
                    }

                    return result;
                }
                finally
                {
                    semaphore.Release();
                }
            });

            var results = await Task.WhenAll(tasks);
            var finalResults = results
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList();

            _logger.LogInformation("Images added successfully. OfferId: {OfferId}, SuccessCount: {Count}", offerId, finalResults.Count);


            return finalResults;
            
        }


        //===============================================================================================================
        //		UPDATE OFFER IMAGE
        //===============================================================================================================

        /// <summary>
        ///		Редактирует изображение объявления.
        ///		Проверяет владельца объявления и загружает новое изображение.
        /// </summary>
        /// <param name="offerId">Идентификатор объявления</param>
        /// <param name="imageId">Идентификатор изображения</param>
        /// <param name="file">Файл изображения</param>
        /// <returns>True, если изображение успешно обновлено, иначе false</returns>
        public async Task<UpdateImageOfferResponse> UpdateImageOffer(
               int offerId,
               int imageId,
               IFormFile file,
               string accessToken
        )
        {
            _logger.LogInformation(
                "Start updating image. OfferId: {OfferId}, ImageId: {ImageId}, FileName: {FileName}, FileLength: {Length}",
                offerId,
                imageId,
                file.FileName,
                file.Length
            );
            if (file == null || file.Length == 0)
            {
                _logger.LogWarning("No file provided for update. OfferId: {OfferId}, ImageId: {ImageId}", offerId, imageId);
                throw new ValidationException("Файл не передан");
            }

            var isOwner = await _userApiClient.ValidOfferIdByOwner(offerId, accessToken);
            if (!isOwner)
            {
                _logger.LogWarning("Unauthorized image update attempt. OfferId: {OfferId}, ImageId: {ImageId}", offerId, imageId);
                throw new ForbiddenException($"Вы не являетесь владельцем объявления {offerId}");
            }

            FileValidationHelper.ValidateFile(file);

            var result = await _offerApiClient.UpdateImageAsync(imageId, file);

            if (result)
                _logger.LogInformation("Image updated successfully. OfferId: {OfferId}, ImageId: {ImageId}", offerId, imageId);
            else
            {
                _logger.LogWarning("Image update failed. OfferId: {OfferId}, ImageId: {ImageId}", offerId, imageId);
                throw new ValidationException("Ошибка при обновлении изображения");
            }

            return new UpdateImageOfferResponse
            {
                OfferId = offerId,
                ImageId = imageId,
                Success = result,
                FileName = file.FileName
            };
        }

        //===============================================================================================================
        //		DELETE OFFER IMAGE
        //===============================================================================================================

        /// <summary>
        ///		Удаляет изображение объявления.
        ///		Проверяет владельца объявления перед удалением.
        /// </summary>
        /// <param name="offerId">Идентификатор объявления</param>
        /// <param name="imageId">Идентификатор изображения</param>
        /// <returns>True, если изображение успешно удалено, иначе false</returns>
        public async Task<bool> DeleteImageOffer(
               int offerId,
               int imageId,
               string accessToken
        )
        {
            _logger.LogInformation(
                 "Start deleting image. OfferId: {OfferId}, ImageId: {ImageId}",
                 offerId,
                 imageId
             );

            var isOwner = await _userApiClient.ValidOfferIdByOwner(offerId, accessToken);
            if (!isOwner)
            {
                _logger.LogWarning(
                    "Unauthorized delete attempt. OfferId: {OfferId}, ImageId: {ImageId}",
                    offerId,
                    imageId
                );
                throw new ForbiddenException("Вы не являетесь владельцем этого объявления");
            }

            var result = await _offerApiClient.DeleteImageOffer(imageId);

            if (result)
                _logger.LogInformation(
                    "Image deleted successfully. OfferId: {OfferId}, ImageId: {ImageId}",
                    offerId,
                    imageId
                );
            else
                _logger.LogWarning(
                    "Image deletion failed (image not found or error). OfferId: {OfferId}, ImageId: {ImageId}",
                    offerId,
                    imageId
                );
            return result;
        }

        //===============================================================================================================
        //		TOGGLE OFFER BLOCK STATUS
        //===============================================================================================================

        /// <summary>
        ///		Блокирует или разблокирует объявление в зависимости от параметра block.
        ///		Проверяет владельца перед выполнением операции.
        /// </summary>
        /// <param name="offerId">Идентификатор объявления</param>
        /// <param name="block">True — заблокировать, False — разблокировать</param>
        /// <returns>True, если операция выполнена успешно, иначе false</returns>
        public async Task<bool> SetOfferBlockStatus(int offerId, bool block, string accessToken)
        {
            _logger.LogInformation(
                 "Attempting to {Action} offer. OfferId: {OfferId}",
                 block ? "block" : "unblock",
                 offerId
             );

            var isOwner = await _userApiClient.ValidOfferIdByOwner(offerId, accessToken);
            if (!isOwner)
            {
                _logger.LogWarning(
                    "Forbidden attempt to {Action} offer. OfferId: {OfferId}",
                    block ? "block" : "unblock",
                    offerId
                );
                throw new ForbiddenException("Вы не являетесь владельцем этого объявления");
            }

            bool result;
            if (block)
            {
                result = await _offerApiClient.BlockOffer(offerId);
            }
            else
            {
                result = await _offerApiClient.UnBlockOffer(offerId);
            }

            if (result)
                _logger.LogInformation("Offer {Action}ed successfully. OfferId: {OfferId}", block ? "block" : "unblock", offerId);
            else
                _logger.LogWarning("Failed to {Action} offer. OfferId: {OfferId}", block ? "block" : "unblock", offerId);

            return result;
        }


        //===============================================================================================================
        //		TOP OFFERS FOR PERIOD (WEEK / MONTH / YEAR)
        //===============================================================================================================

        /// <summary>
        ///		Получает список популярных объявлений за указанный период (неделя, месяц, год).
        ///		Возвращает переводы для указанных объявлений на выбранном языке.
        /// </summary>
        /// <param name="period">Период статистики: "week", "month", "year"</param>
        /// <param name="limit">Максимальное количество объявлений для возврата</param>
        /// <param name="lang">Код языка для переводов (например: "en", "uk", "ru")</param>
        /// <returns>Список популярных объявлений с переводами</returns>
        public async Task<IEnumerable<OfferResponseForPupularList>> GetPopularTopOffer(
            string period,
            int limit,
            string lang)
        {
            if (string.IsNullOrWhiteSpace(period) || !new[] { "week", "month", "year" }.Contains(period.ToLower()))
                throw new ValidationException("Параметр period должен быть 'week', 'month' или 'year'");

            if (limit <= 0)
                throw new ValidationException("Параметр limit должен быть больше нуля");

            if (string.IsNullOrWhiteSpace(lang))
                lang = "en"; 

            _logger.LogInformation(
                 "Start aggregation for popular offers. Period: {Period}, Limit: {Limit}, Lang: {Lang}",
                 period, limit, lang);
            var offersStatisticList = await _statisticClient.GetOffersStatisticsAsync(period, limit);
            if (offersStatisticList == null || !offersStatisticList.Any())
            {
                _logger.LogWarning("No statistics received for period {Period}", period);
                return Enumerable.Empty<OfferResponseForPupularList>();
            }

            var idList = offersStatisticList?
                 .Where(x => x != null)
                 .Select(x => x.EntityId)
                 .ToList() ?? new List<int>();
            if (!idList.Any())
            {
                _logger.LogWarning("No valid offer IDs found in statistics for period {Period}", period);
                return Enumerable.Empty<OfferResponseForPupularList>();
            }

            var offersListFromStatisticTask = _offerApiClient.GetPopularsOffersAsync(idList);
            var offersTranslationsListTask = _translationClient.GetAllOffersTranslationAsync(lang);
            await Task.WhenAll(offersListFromStatisticTask, offersTranslationsListTask);

            var offers = offersListFromStatisticTask.Result ?? Enumerable.Empty<OfferResponseForPupularList>();
            var offersTranslations = offersTranslationsListTask.Result ?? Enumerable.Empty<TranslationResponse>();

            _logger.LogInformation("Retrieved {Count} popular offers", offers.Count());
            _logger.LogInformation("Retrieved {Count} offers translations", offersTranslations.Count());

            if (!offers.Any())
                _logger.LogWarning("No offers left after merging translations for period {Period}", period);
            if (!offersTranslations.Any())
                _logger.LogWarning("No translations received for popular offers in lang {Lang}", lang);

            MergeHelper.Merge(
               offers,
               offersTranslations,
               c => c.id,
               t => t.EntityId
             );
            _logger.LogInformation(
                "Merge completed for popular offers translations. Total offers merged: {Count}, Lang: {Lang}",
                offers.Count(), lang
            );

            return offers ?? Enumerable.Empty<OfferResponseForPupularList>();
        }





    }
}
