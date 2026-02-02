using Globals.Models;

namespace TranslationApiService.Models.Offer
{
    public class OfferTranslation : TranslationEntityBase
    {

        public string Title { get; set; }
        public string? TitleInfo { get; set; }     //  краткая инфа 
        public string Description { get; set; }
    }
}
