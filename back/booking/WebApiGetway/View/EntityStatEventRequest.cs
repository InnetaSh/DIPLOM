namespace WebApiGetway.View
{
    public class EntityStatEventRequest
    {
        public int EntityId { get; set; }
        public string EntityType { get; set; }

        public string ActionType { get; set; }
        public int? UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
