using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TranslationContracts;

namespace WebApiGetway.Service.Interfase
{
    public interface ILocationBffService
    {
        Task<IEnumerable<TranslationResponse>> GetAllCityTranslations(string lang);
        Task<CityResponse> GetCityById(int cityId, string lang);
        Task<IEnumerable<CityResponse>> GetAllCities(string lang);
        Task<IEnumerable<CityResponseForPopularList>> GetPopularTopCity(
            string period,
            int limit,
            string lang);

        //===============================================================================================================

        Task<IEnumerable<RegionResponse>> GetAllRegions(string lang);
        //===============================================================================================================

        Task<CityResponse> GetAllLocationsTitlesByCityId(int cityId, string lang);
        //===============================================================================================================

        Task<IEnumerable<CountryResponse>> GetAllOnlyCountries(string lang);
        Task<IEnumerable<CountryResponse>> GetAllCountryWithRegionsWithCityTranslations(string lang);
       
    }

}
