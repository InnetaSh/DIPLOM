using Globals.Models;

namespace TranslationApiService.Models
{
    public class Language : EntityBase
    {
        public string Code { get; set; } // "en", "ru", "de"
        public string Name { get; set; } // English, Russian, German
        public bool IsEnabled { get; set; } // можно ли использовать язык
    }
}
