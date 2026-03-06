using Globals.Sevices;
using TranslationApiService.Models;
using TranslationApiService.Models.Location;
using TranslationApiService.Service.Location.Interface;


namespace TranslationApiService.Service.Location
{
    public class DistrictService : TranslationServiceBase<DistrictTranslation, TranslationContext>, IDistrictService
    {
        public DistrictService(TranslationContext context, ILogger<DistrictService> logger) : base(context, logger)
        {
        }
    }
}
