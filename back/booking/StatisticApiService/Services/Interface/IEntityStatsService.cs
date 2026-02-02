using Globals.Abstractions;
using StatisticApiService.Models;
using StatisticApiService.Models.Enum;
using StatisticApiService.View;

namespace StatisticApiService.Services.Interface
{
    public interface IEntityStatsService : IServiceBase<PopularEntity>
    {
        Task<bool> AddEventAsync(EntityStatEvent entityStatEvent);
        //Task AggregateDayAsync(DateOnly date);
        Task<List<PopularEntityResponse>> GetPopularEntitiesAsync(
             EntityType type,
             int limit,
             DateOnly? startDate = null,
             DateOnly? endDate = null);
    }
        
}
