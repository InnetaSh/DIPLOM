using Globals.Models;

namespace StatisticApiService.Models
{
    public class PopularEntity : EntityBase
    {
        public int EntityId { get; set; }
        public int Score { get; set; }
    }
}
