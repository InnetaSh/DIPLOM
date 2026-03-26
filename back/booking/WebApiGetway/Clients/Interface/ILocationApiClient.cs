using LocationContracts;
using TranslationContracts;

namespace WebApiGetway.Clients.Interface
{
    public interface ILocationApiClient
    {
        Task<CityResponse> GetCityByIdAsync(int id);
        Task<IEnumerable<CityResponseForPopularList>> GetPopularsCitiesAsync(List<int> idList);
        Task<IEnumerable<CityResponse>> GetAllCitiesAsync();
        //-------------------------------------------------------------------------------------

        Task<RegionResponse> GetRegionByIdAsync(int regionId);
        Task<IEnumerable<RegionResponse>> GetAllRegionsAsync();
        //-------------------------------------------------------------------------------------

        Task<CountryResponse> GetCountryByIdAsync(int countryId);
        Task<IEnumerable<CountryResponse>> GetAllCountriesAsync();
        Task<IEnumerable<CountryResponse>> GetAllOnlyCountriesAsync();
    }
}
