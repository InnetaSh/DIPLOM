using Globals.Clients;
using AttractionContracts;
using System.Net.Http.Json;
using TranslationContracts;
using WebApiGetway.Clients.Interface;
using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Clients
{
    public class AttractionApiClient : BaseApiClient, IAttractionApiClient
    {
        //private readonly HttpClient _client;

        //public LocationApiClient(HttpClient client)
        //{
        //    _client = client;
        //}
        public AttractionApiClient(HttpClient client, ILogger<AttractionApiClient> logger)
       : base(client, logger) { }


        //===============================================================================================================
        //      GET ALL CITY ATTRACTIONS
        //===============================================================================================================
        public async Task<IEnumerable<AttractionResponse>> GetAllAttractionsByCityIdAsync(int cityId)
        {
            var result = await GetAsync<IEnumerable<AttractionResponse>>($"/api/attraction/get/byCityId/{cityId}");
            return result ?? Enumerable.Empty<AttractionResponse>();
        }


        //===============================================================================================================
        //    GET  ATTRACTIONS BY id
        //===============================================================================================================
        public async Task<AttractionResponse> GetAttractionByIdAsync(int attractionId)
        {
            var result = await GetAsync<AttractionResponse>($"/api/attraction/get/byId/{attractionId}");
            return result ?? new AttractionResponse();
        }


        //===============================================================================================================
        //                           NEARBY ATTRACTIONS
        //===============================================================================================================

        public async Task<IEnumerable<AttractionResponse>> GetNearAttractionsByIdWithDistance(
            double latitude,
            double longitude,
            decimal distance)
        {
            var result = await GetAsync<IEnumerable<AttractionResponse>>(
                $"/api/attraction/near/by-distance/{latitude}/{longitude}/{distance}");
            return result ?? Enumerable.Empty<AttractionResponse>();
        }
    }


}
