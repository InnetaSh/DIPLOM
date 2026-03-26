using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using TranslationContracts;
using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("locations")]
    public class LocationBffController : ControllerBase
    {
        private readonly ILocationBffService _locationService;
        public LocationBffController( ILocationBffService locationService)
        {
            _locationService = locationService;
        }


        //===============================================================================================================
        //     TRANSLATIONS FOR ALL CITIES
        //===============================================================================================================
        
        [HttpGet("cities/translations/{lang}")]
        public Task<IEnumerable<TranslationResponse>> GetAllCitiesTranslations(string lang)
           => _locationService.GetAllCityTranslations(lang);

        //===============================================================================================================
        //      	ALL CITY WITH TRANSLATION
        //===============================================================================================================

        [HttpGet("cities/all/{lang}")]
        public Task<IEnumerable<CityResponse>> GetAllCitiesWithTranslations(string lang)
             => _locationService.GetAllCities(lang);


        //===============================================================================================================
        //         CITY BY cityId WITH TRANSLATION
        //===============================================================================================================

        [HttpGet("cities/{cityId}/{lang}")]
        public Task<CityResponse> GetCityByIdWithTranslations(int cityId,string lang)
             => _locationService.GetCityById(cityId,lang);

        //===============================================================================================================
        //        Populars  cities with translation from period (week / month / year)
        //===============================================================================================================

        [HttpGet("cities/populars")]
        public Task<IEnumerable<CityResponseForPopularList>> GetPopularTopCities(
            [FromQuery] string period,
            [FromQuery] int limit,
            [FromQuery] string lang)
             => _locationService.GetPopularTopCity(period, limit, lang);

        //===============================================================================================================
        //         ALL REGIONS WITH TRANSLATION
        //===============================================================================================================

        [HttpGet("regions/{lang}")]
        public Task<IEnumerable<RegionResponse>> GetAllRegionsWithTranslations(string lang)
             => _locationService.GetAllRegions(lang);

        //===============================================================================================================
        //       CITY, REGION, COUNTRY WITH TRANSLATION BY cityId
        //===============================================================================================================
        [HttpGet("cities/{cityId}/locations/translations/{lang}")]
        public Task<CityResponse> GetAllLocationsTitlesByCityId(int cityId, string lang)
         => _locationService.GetAllLocationsTitlesByCityId(cityId, lang);

        //===============================================================================================================
        //      	ALL COUNTRIES WITH TRANSLATION - WITHOUT REGIONS, CITY (ALL COUNTRY WITH COUNTRYCODE)
        //===============================================================================================================
        [HttpGet("countries/all/{lang}")]
        public  Task<IEnumerable<CountryResponse>> GetAllOnlyCountries(string lang)
              => _locationService.GetAllOnlyCountries(lang);

        //===============================================================================================================
        //      ALL COUNTRIES WITH REGIONS, CITY, TRANSLATION
        //===============================================================================================================

        [HttpGet("countries/full/{lang}")]
        public  Task<IEnumerable<CountryResponse>> GetAllCountryWithRegionsWithCityTranslations(string lang)
              => _locationService.GetAllCountryWithRegionsWithCityTranslations(lang);
    }
}
