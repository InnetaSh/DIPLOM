namespace WebApiGetway.Service.Interfase
{
    public class OfferServiceClient: IOfferServiceClient
    {
        private readonly HttpClient _http;

        public OfferServiceClient(HttpClient http)
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
