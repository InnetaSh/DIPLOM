using Globals.Models;

namespace TranslationApiService.Models.Attraction
{
    public class AttractionTranslation : TranslationEntityBase
    {
       
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
