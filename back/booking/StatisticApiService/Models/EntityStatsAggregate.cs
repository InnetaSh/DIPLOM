using Globals.Models;
using StatisticApiService.Models.Enum;

namespace StatisticApiService.Models
{
    public class EntityStatsAggregate : EntityBase
    {
        public int EntityId { get; set; }
        public EntityType EntityType { get; set; }

        public DateOnly Date { get; set; }

        public int SearchesCount { get; set; }
        public int ViewsCount { get; set; }
        public int BookingsCount { get; set; }

        public int UniqueUsers { get; set; }
    }
}
