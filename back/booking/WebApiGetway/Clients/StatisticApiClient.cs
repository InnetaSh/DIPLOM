using Globals.Clients;
using LocationContracts;
using StatisticContracts;
using TranslationContracts;
using WebApiGetway.Clients.Interface;
using WebApiGetway.Models.Enum;
using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Clients
{
    public class StatisticApiClient : BaseApiClient,IStatisticApiClient
    {
        private readonly HttpClient _client;

        public StatisticApiClient(HttpClient client, ILogger<ReviewApiClient> logger)
      : base(client, logger) { }

        //===============================================================================================================
        //       TOP CITIES FOR PERIOD (WEEK / MONTH / YEAR)
        //===============================================================================================================

        public async Task<IEnumerable<PopularEntityResponse>> GetCitiesStatisticsAsync(string period, int limit)
        {
            int maxAttempts = 3;
            const int entityTypeId = 2;

            var (statisticPeriod, statisticUrl) = period.ToLower() switch
            {
                "week" => (StatisticPeriod.Week, "/api/EntityStatistic/top-week"),
                "month" => (StatisticPeriod.Month, "/api/EntityStatistic/top-month"),
                "year" => (StatisticPeriod.Year, "/api/EntityStatistic/top-year"),
                _ => throw new ArgumentOutOfRangeException(nameof(period), $"Invalid period: {period}")
            };

            var url = $"{statisticUrl}?entityType={entityTypeId}&limit={limit}";

            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    var result = await GetAsync<IEnumerable<PopularEntityResponse>>(url);

                    return result ?? Enumerable.Empty<PopularEntityResponse>();
                }
                catch (Exception ex) when (attempt < maxAttempts)
                {
                    Console.WriteLine($"Retry {attempt} failed: {ex.Message}");
                    await Task.Delay(1000 * attempt); 
                }
            }

            throw new Exception("Statistic service unavailable after retries for city statistics");

        }
        //===============================================================================================================
        //   TOP OFFERS FOR PERIOD (WEEK / MONTH / YEAR)
        //===============================================================================================================
        public async Task<IEnumerable<PopularEntityResponse>> GetOffersStatisticsAsync(string period, int limit)
        {
            int maxAttempts = 3;
            const int entityTypeId = 3;

            var (statisticPeriod, statisticUrl) = period.ToLower() switch
            {
                "week" => (StatisticPeriod.Week, "/api/EntityStatistic/top-week"),
                "month" => (StatisticPeriod.Month, "/api/EntityStatistic/top-month"),
                "year" => (StatisticPeriod.Year, "/api/EntityStatistic/top-year"),
                _ => throw new ArgumentOutOfRangeException(nameof(period), $"Invalid period: {period}")
            };

            var url = $"{statisticUrl}?entityType={entityTypeId}&limit={limit}";

            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    var result = await GetAsync<IEnumerable<PopularEntityResponse>>(url);

                    return result ?? Enumerable.Empty<PopularEntityResponse>();
                }
                catch (Exception ex) when (attempt < maxAttempts)
                {
                    Console.WriteLine($"Retry {attempt} failed: {ex.Message}");
                    await Task.Delay(1000 * attempt);
                }
            }

            throw new Exception("Statistic service unavailable after retries for city statistics");

        }

        //===============================================================================================================
        //       SEND EVENT TO STATISTICS
        //===============================================================================================================
        public async Task<bool> AddStatisticToEntityAsync(EntityStatEventRequest request)
        {
            try
            {
                await PostAsync<object>(
                    "/api/EntityStatistic/event",
                    request);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
