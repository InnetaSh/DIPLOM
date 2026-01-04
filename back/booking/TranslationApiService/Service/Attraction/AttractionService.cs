using Globals.Sevices;
using TranslationApiService.Models;
using TranslationApiService.Models.Attraction;
using TranslationApiService.Models.Location;
using TranslationApiService.Service.Attraction.Interface;
using TranslationApiService.Service.Location.Interface;


namespace TranslationApiService.Service.Attraction
{
    public class AttractionService : TranslationServiceBase<AttractionTranslation, TranslationContext>, IAttractionService
    {
        
    }
}
