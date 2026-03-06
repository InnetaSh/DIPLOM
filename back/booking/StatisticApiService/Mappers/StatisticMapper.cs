using StatisticApiService.Models;
using StatisticApiService.Models.Enum;
using StatisticContracts;

namespace StatisticApiService.Mappers
{
    public static class StatisticMapper
    {
        public static EntityStatEvent MapToModel( EntityStatEventRequest request)
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
