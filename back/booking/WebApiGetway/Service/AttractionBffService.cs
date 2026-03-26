using AttractionContracts;
using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using ReviewContracts;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using TranslationContracts;
using WebApiGetway.Clients;
using WebApiGetway.Clients.Interface;
using WebApiGetway.Helpers;
using WebApiGetway.Models.Enum;
using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Service
{
    public class AttractionBffService : IAttractionBffService
    {
        private readonly ITranslationApiClient _translationClient;
        private readonly IAttractionApiClient _attractionClient;
        private readonly IStatisticApiClient _statisticClient;
        private readonly IOfferApiClient _offerClient;
        private readonly ILogger<ILocationBffService> _logger;

        public AttractionBffService
                (ITranslationApiClient translationClient,
                IAttractionApiClient attractionClient,
                IStatisticApiClient statisticClient,
                IOfferApiClient offerClient,
        ILogger<ILocationBffService> logger)
        {
            _translationClient = translationClient;
            _attractionClient = attractionClient;
            _statisticClient = statisticClient;
            _offerClient = offerClient;
            _logger = logger;
        }



        //===============================================================================================================
        //		GET ALL CITY ATTRACTIONS BY CityId
        //===============================================================================================================
        /// <summary>
        /// Получает все достопримечательности по CityId:
        /// 1. Загружает список достопримечательностей.
        /// 2. Подтягивает переводы для указанного языка.
        /// 3. Мержит переводы с сущностями.
        /// </summary>
        /// <param name="cityId">Идентификатор города.</param>
        /// <param name="lang">Язык ("uk" или "en").</param>
        /// <returns>Коллекция достопримечательностей.</returns>
        /// <exception cref="ArgumentException">Если переданы некорректные параметры.</exception>
        public async Task<IEnumerable<AttractionResponse>> GetAllAttractionByCityId(
          int cityId,
          string lang)
        {
            if (cityId <= 0)
                throw new ArgumentException("Invalid cityId");

            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language is required");

            _logger.LogInformation(
                "Start GetAllAttractionByCityId. CityId: {CityId}, Lang: {Lang}",
                cityId,
                lang);

            var attractionsTask = _attractionClient.GetAllAttractionsByCityIdAsync(cityId);
            var translateListTask = _translationClient.GetAllAttractionsTranslationsAsync(lang);

            await Task.WhenAll(attractionsTask, translateListTask);

            var attractions = await attractionsTask ?? Enumerable.Empty<AttractionResponse>();
            var attractionsTranslations = await translateListTask ?? Enumerable.Empty<TranslationResponse>();

            if (!attractions.Any())
            {
                _logger.LogInformation("No attractions found for CityId: {CityId}", cityId);
                return attractions;
            }

            MergeHelper.Merge(
                attractions,
                attractionsTranslations,
                c => c.id,
                r => r.EntityId
              );

            _logger.LogInformation(
                "Finished GetAllAttractionByCityId. Count: {Count}",
                attractions.Count());

            return attractions;
        }

        //===============================================================================================================
        //		GET ATTRACTIONS BY  attractionId
        //===============================================================================================================
        /// <summary>
        /// Получает достопримечательность по Id:
        /// 1. Загружает сущность.
        /// 2. Загружает перевод для указанного языка.
        /// 3. Обогащает данными перевода.
        /// </summary>
        /// <param name="attractionId">Идентификатор достопримечательности.</param>
        /// <param name="lang">Язык ("uk" или "en").</param>
        /// <returns>Достопримечательность с переводом.</returns>
        /// <exception cref="ArgumentException">Если переданы некорректные параметры.</exception>
        public async Task<AttractionResponse> GetAttractionById(
          int attractionId,
          string lang)
        {
            if (attractionId <= 0)
                throw new ArgumentException("Invalid attractionId");

            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language is required");

            _logger.LogInformation(
                "Start GetAttractionById. AttractionId: {AttractionId}, Lang: {Lang}",
                attractionId,
                lang);

            var attractionTask = _attractionClient.GetAttractionByIdAsync(attractionId);
            var translationTask = _translationClient.GetAttractionTranslationByIdAsync(attractionId,lang);

            await Task.WhenAll(attractionTask, translationTask);

            var attraction = await attractionTask;
            if (attraction == null)
            {
                _logger.LogWarning("Attraction not found. AttractionId: {AttractionId}", attractionId);
                return new AttractionResponse();
            }

            var translation = await translationTask;

            if (translation != null)
            {
                attraction.Title = translation.Title ?? "N/A";
                attraction.Description = translation.Description ?? "N/A";
            }
            else
            {
                _logger.LogWarning(
                    "Translation not found. AttractionId: {AttractionId}, Lang: {Lang}",
                    attractionId,
                    lang);
            }

            _logger.LogInformation(
                "Finished GetAttractionById. AttractionId: {AttractionId}",
                attractionId);

            return attraction;
        }

        //============================================================================================
        //     GET NEAREST ATTRACTIONS
        //============================================================================================
        /// <summary>
        /// Получает ближайшие достопримечательности к указанному офферу:
        /// 1. Загружает оффер по Id.
        /// 2. Определяет координаты оффера.
        /// 3. Получает достопримечательности в радиусе distance.
        /// 4. Подтягивает переводы и мержит их с сущностями.
        /// </summary>
        /// <param name="offerId">Идентификатор оффера.</param>
        /// <param name="distance">Радиус поиска (в км).</param>
        /// <param name="lang">Язык ("uk" или "en").</param>
        /// <returns>Коллекция ближайших достопримечательностей.</returns>
        /// <exception cref="ArgumentException">Если переданы некорректные параметры.</exception>
        /// <exception cref="ArgumentNullException">Если оффер не найден.</exception>
        public async Task<IEnumerable<AttractionResponse>> GetNearAttractionsByIdWithDistance(
              int offerId,
              decimal distance,
              string lang)
        {
            if (offerId <= 0)
                throw new ArgumentException("Invalid offerId");

            if (distance <= 0)
                throw new ArgumentException("Distance must be positive");

            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language is required");

            _logger.LogInformation(
                "Start GetNearAttractionsByIdWithDistance. OfferId: {OfferId}, Distance: {Distance}, Lang: {Lang}",
                offerId,
                distance,
                lang);

            var offer = await _offerClient.GetOfferById(offerId);
            if (offer == null)
            {
                _logger.LogWarning("Offer not found. OfferId: {OfferId}", offerId);
                throw new ArgumentNullException(nameof(offer), "Offer not found");
            }
            var latitude = offer.RentObj?.Latitude ?? 0;
            var longitude = offer.RentObj?.Longitude ?? 0;
            if (latitude == 0 || longitude == 0)
            {
                _logger.LogWarning("Offer coordinates missing. OfferId: {OfferId}", offerId);
            }

            var attractionsTask = _attractionClient.GetNearAttractionsByIdWithDistance(latitude, longitude, distance);
            var translateListTask = _translationClient.GetAllAttractionsTranslationsAsync(lang);

            await Task.WhenAll(attractionsTask, translateListTask);

            var attractions = await attractionsTask;
            var attractionsTranslations = await translateListTask ?? Enumerable.Empty<TranslationResponse>();

            if (!attractions.Any())
            {
                _logger.LogInformation("No nearby attractions found. OfferId: {OfferId}", offerId);
                return attractions;
            }

            MergeHelper.Merge(
                attractions,
                attractionsTranslations,
                c => c.id,
                r => r.EntityId
              );
            _logger.LogInformation(
               "Finished GetNearAttractionsByIdWithDistance. Count: {Count}",
               attractions.Count());

            return attractions ?? Enumerable.Empty<AttractionResponse>();
        }

    }
}
