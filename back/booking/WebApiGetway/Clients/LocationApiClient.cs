using Globals.Clients;
using LocationContracts;
using System.Net.Http.Json;
using TranslationContracts;
using WebApiGetway.Clients.Interface;
using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Clients
{
    public class LocationApiClient : BaseApiClient, ILocationApiClient
    {
        //private readonly HttpClient _client;

        //public LocationApiClient(HttpClient client)
        //{
        //    _client = client;
        //}
        public LocationApiClient(HttpClient client, ILogger<LocationApiClient> logger)
       : base(client, logger) { }


        //===============================================================================================================
        //   City  
        //===============================================================================================================

        public Task<CityResponse?> GetCityByIdAsync(int cityId)
        {
            return GetAsync<CityResponse>($"/api/City/get/{cityId}");
        }
        //-------------------------------------------------------------------------------------

        public async Task<IEnumerable<CityResponse>> GetAllCitiesAsync()
        {
            var result = await GetAsync<IEnumerable<CityResponse>>("/api/City/get-all");
            return result ?? Enumerable.Empty<CityResponse>();
        }


        //===============================================================================================================
        // ТOP Cities FOR PERIOD (week / month / year)
        //===============================================================================================================


        public async Task<IEnumerable<CityResponseForPopularList>> GetPopularsCitiesAsync(List<int> idList)
        {
            var result = await PostAsync<IEnumerable<CityResponseForPopularList>>(
                "/api/City/search/cities/populars",
                idList);

            return result ?? Enumerable.Empty<CityResponseForPopularList>();
        }

        
        //===============================================================================================================
        //        Region  
        //===============================================================================================================
        public Task<RegionResponse?> GetRegionByIdAsync(int regionId)
        {
            return GetAsync<RegionResponse>($"/api/Region/get/{regionId}");
        }

        //-------------------------------------------------------------------------------------

        public async Task<IEnumerable<RegionResponse>> GetAllRegionsAsync()
        {
            var result = await GetAsync<IEnumerable<RegionResponse>>("/api/Region/get-all");
            return result ?? Enumerable.Empty<RegionResponse>();
        }
      

        //===============================================================================================================
        //        country  
        //===============================================================================================================
        public Task<CountryResponse?> GetCountryByIdAsync(int countryId)
        {
            return GetAsync<CountryResponse>($"/api/Country/get/{countryId}");
        }

        //-------------------------------------------------------------------------------------

        public async Task<IEnumerable<CountryResponse>> GetAllCountriesAsync()
        {
            var result = await GetAsync<IEnumerable<CountryResponse>>("/api/Country/get-all");
            return result ?? Enumerable.Empty<CountryResponse>();
        }

        //-------------------------------------------------------------------------------------

        public async Task<IEnumerable<CountryResponse>> GetAllOnlyCountriesAsync()
        {
            var result = await GetAsync<IEnumerable<CountryResponse>>("/api/Country/get-only-countries");
            return result ?? Enumerable.Empty<CountryResponse>();
        }

     
    }
}
