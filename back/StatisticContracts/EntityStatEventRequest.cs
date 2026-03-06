using Globals.Controllers;

namespace StatisticContracts
{
    public class EntityStatEventRequest : IBaseRequest
    {

        public int EntityId { get; set; }
        public string EntityType { get; set; }

        public string ActionType { get; set; }
        public int? UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // полезно для аналитики
        //public string? SessionId { get; set; }
        // public string? Source { get; set; } // web, mobile, partner

       
    }

}
