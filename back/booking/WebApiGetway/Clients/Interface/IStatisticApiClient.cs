using LocationContracts;
using StatisticContracts;
using TranslationContracts;

namespace WebApiGetway.Clients.Interface
{
    public interface IStatisticApiClient
    {
        Task<IEnumerable<PopularEntityResponse>> GetCitiesStatisticsAsync(string period, int limit);
        Task<IEnumerable<PopularEntityResponse>> GetOffersStatisticsAsync(string period, int limit);

        //-------------------------------------------------------------------------------------
        Task<bool> AddStatisticToEntityAsync(EntityStatEventRequest request);

    }
}
