using Globals.Controllers;
using Globals.Models;
using StatisticApiService.Models;
using StatisticApiService.Models.Enum;

namespace StatisticApiService.View
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

        public static EntityStatEvent MapToModel(
            EntityStatEventRequest request
        )
        {
            if (!Enum.TryParse<EntityType>(
            request.EntityType,
            ignoreCase: true,
            out var entityType))
            {
                throw new ArgumentException(
                    $"Invalid EntityType: {request.EntityType}"
                );
            }

            if (!Enum.TryParse<ActionType>(
                    request.ActionType,
                    ignoreCase: true,
                    out var actionType))
            {
                throw new ArgumentException(
                    $"Invalid ActionType: {request.ActionType}"
                );
            }
            return new EntityStatEvent
            {
                EntityId = request.EntityId,
                EntityType = entityType,
                ActionType = actionType,
                UserId = request.UserId,
                CreatedAt = request.CreatedAt
            };
        }
    }

}
