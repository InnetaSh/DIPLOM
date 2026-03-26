using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class LocationBffService : ILocationBffService
    {
        private readonly ITranslationApiClient _translationClient;
        private readonly ILocationApiClient _locationClient;
        private readonly IStatisticApiClient _statisticClient;
        private readonly ILogger<ILocationBffService> _logger;

        public LocationBffService
                (ITranslationApiClient translationClient,
                ILocationApiClient locationClient,
                IStatisticApiClient statisticClient,
        ILogger<ILocationBffService> logger)
        {
            _translationClient = translationClient;
            _locationClient = locationClient;
            _statisticClient = statisticClient;
            _logger = logger;
        }


        //=============================================================================
        //		TRANSLATIONS FOR ALL CITIES
        //=============================================================================
        /// <summary>
        /// Получает переводы для городов на указанном языке.
        /// В случае отсутствия переводов может использовать fallback-язык.
        /// </summary>
        /// <param name="lang">Код языка (например: "en", "uk", "ru").</param>
        /// <returns>Коллекция переводов для городов.</returns>
        public async Task<IEnumerable<TranslationResponse>> GetAllCityTranslations(string lang)
        {
            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language code is required", nameof(lang));

            _logger.LogInformation("Start fetching city translations. Lang: {Lang}", lang);

            var result = await _translationClient.GetAllCitiesTranslationsAsync(lang);

            if (result == null || !result.Any())
            {
                _logger.LogWarning(
                    "No translations found for lang {Lang}. Falling back to default language",
                    lang);

                result = await _translationClient.GetAllCitiesTranslationsAsync("en");
            }

            var list = result ?? Enumerable.Empty<TranslationResponse>();

            _logger.LogInformation(
                "Retrieved {Count} city translations for lang {Lang}",
                list.Count(),
                lang
            );

            return list;
        }

        //=============================================================================
        //		CITY BY cityId WITH TRANSLATION
        //=============================================================================
        /// <summary>
        /// Получает city на указанном языке.
        /// В случае отсутствия переводов может использовать fallback-язык.
        /// </summary>
        /// <param name="cityId">Идентификатор города.</param>
        /// <param name="lang">Код языка (например: "en", "uk", "ru").</param>
        /// <returns>City с переводом.</returns>
        /// <exception cref="ArgumentException">Если переданы некорректные параметры.</exception>

        public async Task<CityResponse> GetCityById(int cityId, string lang)
        {
            if (cityId <= 0)
                throw new ArgumentException("Invalid cityId", nameof(cityId));

            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language code is required", nameof(lang));

            _logger.LogInformation(
                "Start aggregation for city with translation by CityId: {CityId}, Lang: {Lang}",
                cityId,
                lang);

            var cityTask = _locationClient.GetCityByIdAsync(cityId);
            var cityTranslationTask = _translationClient.GetCityTranslationByIdAsync(cityId,lang);
            await Task.WhenAll(cityTask, cityTranslationTask);

            var city = cityTask.Result ?? new CityResponse();
            var cityTranslation = cityTranslationTask.Result ?? new TranslationResponse();

            _logger.LogInformation("Retrieved city", city);
            _logger.LogInformation("Retrieved city translations", cityTranslation);
            if (city == null)
            {
                _logger.LogWarning("No city received from Location service. CityId: {CityId}", cityId);
                return new CityResponse();
            }

            if (cityTranslation == null)
            {
                _logger.LogWarning("No city translations received for lang {Lang}, CityId: {CityId}", lang, cityId);
            }

            MergeHelper.MergeSingle(city, cityTranslation);

            _logger.LogInformation(
                  "Merge completed for city translation. CityId: {CityId}, Lang: {Lang}",
                  cityId,
                  lang);

            return city;
        }

        //=============================================================================
        //		ALL CITY WITH TRANSLATION
        //=============================================================================
        /// <summary>
        /// Получает все города на указанном языке.
        /// В случае отсутствия переводов может использовать fallback-язык.
        /// </summary>
        /// <param name="lang">Код языка (например: "en", "uk", "ru").</param>
        /// <returns>Коллекция городов с переводами.</returns>
        /// <exception cref="ArgumentException">Если lang пустой.</exception>
        public async Task<IEnumerable<CityResponse>> GetAllCities(string lang)
        {
            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language code is required", nameof(lang));

            _logger.LogInformation(
                "Start aggregation for all cities with translation. Lang: {Lang}",
                lang);

            var citiesListTask = _locationClient.GetAllCitiesAsync();
            var citiesTranslationsListTask = _translationClient.GetAllCitiesTranslationsAsync(lang);
            await Task.WhenAll(citiesListTask, citiesTranslationsListTask);

            var cities = citiesListTask.Result ?? Enumerable.Empty<CityResponse>();
            var citiesTranslations = citiesTranslationsListTask.Result ?? Enumerable.Empty<TranslationResponse>();

            _logger.LogInformation("Retrieved {Count} cities", cities.Count());
            _logger.LogInformation("Retrieved {Count} cities translations", citiesTranslations.Count());

            if (!cities.Any())
                _logger.LogWarning("No cities received from Location service.");
            if (!citiesTranslations.Any())
                _logger.LogWarning("No cities translations received for lang {Lang}", lang);

            MergeHelper.Merge(
               cities,
               citiesTranslations,
               c => c.id,
               t => t.EntityId
             );

            _logger.LogInformation("Merge completed for cities translations.");
            _logger.LogInformation(
              "Retrieved {Count} cities  with translations  for lang {Lang}",
              cities?.Count() ?? 0,
              lang
          );

            return cities ?? Enumerable.Empty<CityResponse>();
        }



        //===============================================================================================================
        //		TOP CITY FOR PERIOD (WEEK / MONTH / YEAR)
        //===============================================================================================================
        /// <summary>
        /// Получает топ популярных городов за указанный период.
        /// </summary>
        /// <param name="period">Период статистики ("week", "month", "year").</param>
        /// <param name="limit">Количество городов для выборки.</param>
        /// <param name="lang">Код языка (например: "en", "uk", "ru").</param>
        /// <returns>Коллекция популярных городов с переводами.</returns>
        /// <exception cref="ArgumentException">Если lang пустой или limit <= 0.</exception>
        public async Task<IEnumerable<CityResponseForPopularList>> GetPopularTopCity(
            string period,
            int limit,
            string lang)
        {
            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language code is required", nameof(lang));

            if (limit <= 0)
                throw new ArgumentException("Limit must be greater than 0", nameof(limit));

            _logger.LogInformation(
                "Start aggregation for popular cities. Period: {Period}, Lang: {Lang}",
                period,
                lang);

            var citiesStatisticList = await _statisticClient.GetCitiesStatisticsAsync(period, limit);

            var idList = citiesStatisticList?
                 .Where(x => x != null)
                 .Select(x => x.EntityId)
                 .ToList() ?? new List<int>();

            if (!idList.Any())
            {
                _logger.LogWarning("No popular cities found in statistics for period {Period}", period);
                return Enumerable.Empty<CityResponseForPopularList>();
            }

            var citiesListFromStatisticTask = _locationClient.GetPopularsCitiesAsync(idList);
            var citiesTranslationsListTask = _translationClient.GetAllCitiesTranslationsAsync(lang);
            await Task.WhenAll(citiesListFromStatisticTask, citiesTranslationsListTask);

            var cities = citiesListFromStatisticTask.Result ?? Enumerable.Empty<CityResponseForPopularList>();
            var citiesTranslations = citiesTranslationsListTask.Result ?? Enumerable.Empty<TranslationResponse>();

            _logger.LogInformation("Retrieved {Count}popular cities", cities.Count());
            _logger.LogInformation("Retrieved {Count} cities translations", citiesTranslations.Count());

            if (!cities.Any())
                _logger.LogWarning("No popular cities received from Location service.");
            if (!citiesTranslations.Any())
                _logger.LogWarning("No cities translations received for lang {Lang}", lang);

            MergeHelper.Merge(
               cities,
               citiesTranslations,
               c => c.id,
               t => t.EntityId
             );
            _logger.LogInformation("Merge completed for popular cities translations.");
            _logger.LogInformation(
              "Retrieved {Count}popular cities  with translations  for lang {Lang}",
              cities?.Count() ?? 0,
              lang
          );

            return cities ?? Enumerable.Empty<CityResponseForPopularList>();
        }

        //=============================================================================
        //		ALL REGIONS WITH TRANSLATION
        //=============================================================================
        /// <summary>
        /// Получает все регионы на указанном языке.
        /// В случае отсутствия переводов может использовать fallback-язык.
        /// </summary>
        /// <param name="lang">Код языка (например: "en", "uk", "ru").</param>
        /// <returns>Коллекция регионов с переводами.</returns>
        /// <exception cref="ArgumentException">Если lang пустой.</exception>
        public async Task<IEnumerable<RegionResponse>> GetAllRegions(string lang)
        {
            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language code is required", nameof(lang));

            _logger.LogInformation(
                "Start aggregation for all regions with translation. Lang: {Lang}",
                lang);

            var regionsListTask = _locationClient.GetAllRegionsAsync();
            var regionsTranslationsListTask = _translationClient.GetAllRegionsTranslationsAsync(lang);
            await Task.WhenAll(regionsListTask, regionsTranslationsListTask);

            var regions = regionsListTask.Result ?? Enumerable.Empty<RegionResponse>();
            var regionsTranslations = regionsTranslationsListTask.Result ?? Enumerable.Empty<TranslationResponse>();

            _logger.LogInformation("Retrieved {Count} regions", regions.Count());
            _logger.LogInformation("Retrieved {Count} regions translations", regionsTranslations.Count());

            if (!regions.Any())
                _logger.LogWarning("No countries received from Location service.");
            if (!regionsTranslations.Any())
                _logger.LogWarning("No country translations received for lang {Lang}", lang);

            MergeHelper.Merge(
               regions,
               regionsTranslations,
               c => c.id,
               t => t.EntityId
             );

            _logger.LogInformation("Merge completed for regions translations.");
            _logger.LogInformation(
              "Retrieved {Count} regions  with translations  for lang {Lang}",
              regions?.Count() ?? 0,
              lang
          );

            return regions ?? Enumerable.Empty<RegionResponse>();
        }




        //=============================================================================
        //		CITY, REGION, COUNTRY WITH TRANSLATION BY cityId
        //=============================================================================
        /// <summary>
        /// Получаем названия City, Region и Country по cityId на указанном языке.
        /// В случае отсутствия переводов используется fallback ("N/A").
        /// </summary>
        /// <param name="cityId">Идентификатор города.</param>
        /// <param name="lang">Код языка (например: "en", "uk", "ru").</param>
        /// <returns>CityResponse с названиями и переводами для Region и Country.</returns>
        /// <exception cref="ArgumentException">Если cityId <= 0 или lang пустой.</exception>

        public async Task<CityResponse> GetAllLocationsTitlesByCityId(int cityId, string lang)
        {
            if (cityId <= 0)
                throw new ArgumentException("Invalid cityId", nameof(cityId));

            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language code is required", nameof(lang));

            _logger.LogInformation(
                "Start aggregation for CityId: {CityId}, Lang: {Lang}",
                cityId,
                lang);

            var cityResult = await _locationClient.GetCityByIdAsync(cityId);
            if (cityResult == null)
            {
                _logger.LogWarning("City not found for CityId: {CityId}", cityId);
                return null;
            }

            var regionId = cityResult.RegionId ?? 0;
            var regionResult = await _locationClient.GetRegionByIdAsync(regionId);
            var countryId = regionResult?.CountryId ?? 0;


            var countryTask = _translationClient.GetCountryTranslationByIdAsync(countryId, lang);
            var regionTask = _translationClient.GetRegionTranslationByIdAsync(regionId, lang);
            var cityTask = _translationClient.GetCityTranslationByIdAsync(cityId, lang);

            await Task.WhenAll(countryTask, regionTask, cityTask);

            var countryTranslation = countryTask.Result;
            var regionTranslation = regionTask.Result;
            var cityTranslation = cityTask.Result;


            if (countryTranslation == null && regionTranslation == null && cityTranslation == null)
            {
                _logger.LogWarning("No translation found for cityId: {CityId}, Lang: {Lang}", cityId, lang);
                return cityResult;
            }

            cityResult.CountryTitle = countryTranslation?.Title ?? "N/A";
            cityResult.RegionTitle = regionTranslation?.Title ?? "N/A";
            cityResult.Title = cityTranslation?.Title ?? "N/A";
            cityResult.Description = cityTranslation?.Description ?? "N/A";
            cityResult.History = cityTranslation?.History ?? "N/A";
            cityResult.CountryId = countryId;

            _logger.LogInformation("Successfully retrieved translation for cityId: {CityId}, Lang: {Lang}", cityId, lang);

            return cityResult;
        }


        //===============================================================================================================
        //		ALL COUNTRIES WITH TRANSLATION - WITHOUT REGIONS, CITY (ALL COUNTRY WITH COUNTRYCODE)
        //===============================================================================================================
        /// <summary>
        /// Получает все страны с переводами, без регионов и городов.
        /// </summary>
        /// <param name="lang">Код языка (например: "en", "uk", "ru").</param>
        /// <returns>Коллекция стран с переводами.</returns>
        /// <exception cref="ArgumentException">Если lang пустой.</exception>
        public async Task<IEnumerable<CountryResponse>> GetAllOnlyCountries(string lang)
        {
            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language code is required", nameof(lang));

            _logger.LogInformation(
                "Start aggregation for all countries with translation, without regions, city. Lang: {Lang}",
                lang); 
            var countriesListTask = _locationClient.GetAllOnlyCountriesAsync();
            var countriesTranslationsListTask = _translationClient.GetAllCountriesTranslationsAsync(lang);
            await Task.WhenAll(countriesListTask, countriesTranslationsListTask);

            var countries = countriesListTask.Result ?? Enumerable.Empty<CountryResponse>();
            var countriesTranslations = countriesTranslationsListTask.Result ?? Enumerable.Empty<TranslationResponse>();

            _logger.LogInformation("Retrieved {Count} countries", countries.Count());
            _logger.LogInformation("Retrieved {Count} country translations", countriesTranslations.Count());

            if (!countries.Any())
                _logger.LogWarning("No countries received from Location service.");
            if (!countriesTranslations.Any())
                _logger.LogWarning("No country translations received for lang {Lang}", lang);

            MergeHelper.Merge(
               countries,
               countriesTranslations,
               c => c.id,
               t => t.EntityId
             );

            _logger.LogInformation("Merge completed for countries, regions, and cities translations.");
            _logger.LogInformation(
              "Retrieved {Count} country translations, without regions, city for lang {Lang}",
              countries?.Count() ?? 0,
              lang
          );

            return countries ?? Enumerable.Empty<CountryResponse>();
        }


       //===============================================================================================================
       //		ALL COUNTRIES WITH REGIONS, CITY, TRANSLATION
       //===============================================================================================================
        /// <summary>
        /// Получает все страны с регионами и городами, включая переводы на указанном языке.
        /// </summary>
        /// <param name="lang">Код языка (например: "en", "uk", "ru").</param>
        /// <returns>Коллекция стран с регионами и городами, с переводами.</returns>
        /// <exception cref="ArgumentException">Если lang пустой.</exception>
        public async Task<IEnumerable<CountryResponse>> GetAllCountryWithRegionsWithCityTranslations(string lang)
        {
            if (string.IsNullOrWhiteSpace(lang))
                throw new ArgumentException("Language code is required", nameof(lang));

            _logger.LogInformation(
                "Start aggregation for all countries with regions, city, translation. Lang: {Lang}",
                lang);

            var countriesListTask = _locationClient.GetAllCountriesAsync();
            var countriesTranslationsListTask = _translationClient.GetAllCountriesTranslationsAsync(lang);
            var regionsTranslationsListTask = _translationClient.GetAllRegionsTranslationsAsync(lang);
            var citiesTranslationsListTask = _translationClient.GetAllCitiesTranslationsAsync(lang);

            await Task.WhenAll(countriesListTask, countriesTranslationsListTask, regionsTranslationsListTask, citiesTranslationsListTask);

            var countries = countriesListTask.Result ?? Enumerable.Empty<CountryResponse>();
            var countriesTranslations = countriesTranslationsListTask.Result ?? Enumerable.Empty<TranslationResponse>();
            var regionsTranslations = regionsTranslationsListTask.Result ?? Enumerable.Empty<TranslationResponse>();
            var citiesTranslations = citiesTranslationsListTask.Result ?? Enumerable.Empty<TranslationResponse>();

            _logger.LogInformation("Retrieved {Count} countries", countries.Count());
            _logger.LogInformation("Retrieved {Count} country translations", countriesTranslations.Count());
            _logger.LogInformation("Retrieved {Count} region translations", regionsTranslations.Count());
            _logger.LogInformation("Retrieved {Count} city translations", citiesTranslations.Count());

            if (!countries.Any())
                _logger.LogWarning("No countries received from Location service.");
            if (!countriesTranslations.Any())
                _logger.LogWarning("No country translations received for lang {Lang}", lang);
            if (!regionsTranslations.Any())
                _logger.LogWarning("No region translations received for lang {Lang}", lang);
            if (!citiesTranslations.Any())
                _logger.LogWarning("No city translations received for lang {Lang}", lang);

            MergeHelper.Merge(
                countries,
                countriesTranslations,
                c => c.id,
                t => t.EntityId
            );

            var semaphore = new SemaphoreSlim(10); 
            var countryTasks = countries.Select(async country =>
            {
                if (country.Regions?.Any() == true)
                {
                    await semaphore.WaitAsync();
                    try
                    {
                        MergeHelper.Merge(country.Regions, regionsTranslations, r => r.id, t => t.EntityId);

                        var regionTasks = country.Regions.Select(async region =>
                        {
                            if (region.Cities?.Any() == true)
                            {
                                MergeHelper.Merge(region.Cities, citiesTranslations, c => c.id, t => t.EntityId);
                            }
                        });

                        await Task.WhenAll(regionTasks);
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }
            });
            await Task.WhenAll(countryTasks);

            _logger.LogInformation("Merge completed for countries translations.");
            _logger.LogInformation(
                "Retrieved {Count} countries with translations, without regions and cities, for lang {Lang}",
                countries.Count(),
                lang
            );


            return countries ?? Enumerable.Empty<CountryResponse>();
        }

    }
}
