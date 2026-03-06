using Globals.Controllers;

namespace TranslationContracts
{
    public class TranslationResponse : IBaseResponse
    {
        public int id { get; set; }
        public int EntityId { get; set; }

        public string Lang { get; set; }
        public string Title { get; set; }

        public string? Description { get; set; }
        public string? TitleInfo { get; set; }   
        public string? History { get; set; }
        public string? Address { get; set; }
        public string? Slug { get; set; }

    }
}
