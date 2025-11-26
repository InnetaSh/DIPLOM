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

        public async Task<HttpResponseMessage> Register(string request)
        {
            //var json = System.Text.Json.JsonSerializer.Serialize(request);
            var content = new StringContent(request, System.Text.Encoding.UTF8, "application/json");
            var res = await _http.PostAsync($"/api/userapiservice/register", content);
            return res;
        }
    }
}
