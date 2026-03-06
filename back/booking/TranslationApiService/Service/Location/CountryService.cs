using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using TranslationApiService.Models;
using TranslationApiService.Models.Location;
using TranslationApiService.Service.Location.Interface;

namespace TranslationApiService.Service.Location
{
    public class CountryService : TranslationServiceBase<CountryTranslation, TranslationContext>, ICountryService
    {
        public CountryService(TranslationContext context, ILogger<CountryService> logger) : base(context, logger)
        {
        }

    }
}
