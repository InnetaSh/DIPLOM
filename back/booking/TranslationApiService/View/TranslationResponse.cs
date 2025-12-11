

using Globals.Controllers;

namespace TranslationApiService.View
{
    public class TranslationResponse : IBaseResponse
    {
        public int id { get; set; }
        public int EntityId { get; set; } //id привязанной сущности из других микросервисов

        public string Lang { get; set; }
        public string Title { get; set; }

        public string? Description { get; set; }

     

    }
}
