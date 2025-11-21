using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Service
{ 
    public class UserServiceClient : IUserServiceClient
    {
        private readonly HttpClient _http;

        public UserServiceClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> Login(object request)
        {
            var res = await _http.GetAsync($"/api/rentobj/by-city?city={request}");
            return res;
        }
    }
}
