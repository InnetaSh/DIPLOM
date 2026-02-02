using Globals.Models;
using StatisticApiService.Models.Enum;

namespace StatisticApiService.Models
{
    public class EntityStatEvent : EntityBase
    {

        public int EntityId { get; set; }
        public EntityType EntityType { get; set; }

        public ActionType ActionType { get; set; }
        public int? UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // полезно для аналитики
        //public string? SessionId { get; set; }
       // public string? Source { get; set; } // web, mobile, partner
    }

}
