using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using StatisticApiService.Models;
using StatisticApiService.Models.Enum;
using StatisticApiService.Services.Interface;
using StatisticApiService.View;

namespace StatisticApiService.Services
{
    public class EntityStatsService : TableServiceBase<PopularEntity, StatisticDbContext>, IEntityStatsService
    {

        public async Task<bool> AddEventAsync(EntityStatEvent entityStatEvent)
        {
            using var db = new StatisticDbContext();
            db.EntityStatEvents.Add(entityStatEvent);

            var result = await db.SaveChangesAsync();
            return result > 0;
        }


        ////---------------агрегировать статистику за день-------------------------
        //public async Task AggregateDayAsync(DateOnly date)
        //{
        //    var start = date.ToDateTime(TimeOnly.MinValue);
        //    var end = date.ToDateTime(TimeOnly.MaxValue);

        //    using var db = new StatisticDbContext();

        //    var aggregates = await db.EntityStatEvents
        //        .Where(e => e.CreatedAt >= start && e.CreatedAt <= end)
        //        .GroupBy(e => new { e.EntityType, e.EntityId }) 
        //        .Select(g => new EntityStatsAggregate
        //        {
        //            EntityType = g.Key.EntityType,
        //            EntityId = g.Key.EntityId,
        //            Date = date,
        //            SearchesCount = g.Count(e => e.ActionType == ActionType.Search),
        //            ViewsCount = g.Count(e => e.ActionType == ActionType.View),
        //            BookingsCount = g.Count(e => e.ActionType == ActionType.Booking),
        //            UniqueUsers = g.Select(e => e.UserId).Where(u => u.HasValue).Distinct().Count()
        //        })
        //        .ToListAsync();

           
        //    db.EntityStatsAggregates.AddRange(aggregates);

        //    await db.SaveChangesAsync();
        //}


        // ---------------получить популярные сущности-------------------------
        public async Task<List<PopularEntityResponse>> GetPopularEntitiesAsync(
             EntityType type,
             int limit,
             DateOnly? startDate = null,
             DateOnly? endDate = null)
        {
            using var db = new StatisticDbContext();

            var query = db.EntityStatEvents
              .Where(a => a.EntityType == type);

            if (startDate.HasValue)
            {
                var start = startDate.Value.ToDateTime(TimeOnly.MinValue);
                query = query.Where(e => e.CreatedAt >= start);
            }

            if (endDate.HasValue)
            {
                var end = endDate.Value.ToDateTime(TimeOnly.MaxValue);
                query = query.Where(e => e.CreatedAt <= end);
            }

            return await query
                .GroupBy(a => a.EntityId)
                .Select(g => new PopularEntityResponse
                {
                    EntityId = g.Key,
                    Score =
                        g.Count(e => e.ActionType == ActionType.Search) * 1 +
                        g.Count(e => e.ActionType == ActionType.View) * 2 +
                        g.Count(e => e.ActionType == ActionType.Booking) * 5
                })
                .OrderByDescending(x => x.Score)
                .Take(limit)
                .ToListAsync();
        }

    }
}


