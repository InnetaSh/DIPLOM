using OfferApiService.Service.Interface;

namespace OfferApiService.Service
{
    public class RentObjClient: IRentObjServiceClient
    {
        private readonly HttpClient _http;

        public RentObjClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> GetByCityAsync(string cityTitle)
        {
            var res = await _http.GetAsync($"/api/rentobj/by-city?city={cityTitle}");
            return res;
        }
    }
}
