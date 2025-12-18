using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Service
{
    public class GatewayService : IGatewayService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<GatewayService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GatewayService(
            IHttpClientFactory clientFactory,
            ILogger<GatewayService> logger,
            IHttpContextAccessor httpContextAccessor) 
        {
            _clientFactory = clientFactory;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<IActionResult> ForwardRequestAsync<TRequest>(
            string serviceName,
            string route,
            HttpMethod method,
            TRequest? request = null
            )
            where TRequest : class
        {
            var client = _clientFactory.CreateClient(serviceName);

            // Прокидываем JWT из входящего запроса, если есть
            var authHeader = _httpContextAccessor.HttpContext?
                .Request.Headers["Authorization"]
                .FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(authHeader))
            {
                client.DefaultRequestHeaders.Remove("Authorization");
                client.DefaultRequestHeaders.Add("Authorization", authHeader);
            }


            HttpResponseMessage response;

            switch (method.Method)
            {
                case "GET":
                    response = await client.GetAsync(route);
                    break;

                case "POST":
                    response = await client.PostAsJsonAsync(route, request);
                    break;

                case "PUT":
                    response = await client.PutAsJsonAsync(route, request);
                    break;

                case "DELETE":
                    response = await client.DeleteAsync(route);
                    break;

                default:
                    throw new ArgumentException($"Unsupported HTTP method: {method}");
            }

            _logger.LogInformation(
                "[Gateway] {Method} {Service}{Route} -> {Status}",
                method.Method,
                serviceName,
                route,
                response.StatusCode);

            // ⬇️ ВАЖНАЯ ЧАСТЬ
            if (response.IsSuccessStatusCode)
            {
                object? content = null;

                // если тело реально есть
                if (response.Content.Headers.ContentLength > 0)
                {
                    content = await response.Content.ReadFromJsonAsync<object>();
                }

                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    return new OkObjectResult(content)
                    {
                        StatusCode = (int)response.StatusCode
                    };

                // возвращаем ТОТ ЖЕ статус, что пришёл из сервиса
                return new ObjectResult(content)
                {
                    StatusCode = (int)response.StatusCode
                };
            }

            // ошибки пробрасываем как есть
            return new ObjectResult(await response.Content.ReadAsStringAsync())
            {
                StatusCode = (int)response.StatusCode
            };
        }

        public async Task<IActionResult> ForwardFileAsync(
            string serviceName,
            string route,
            HttpMethod method,
            IFormFile file)
        {
            var client = _clientFactory.CreateClient(serviceName);

            using var content = new MultipartFormDataContent();
            var streamContent = new StreamContent(file.OpenReadStream());
            content.Add(streamContent, "file", file.FileName);

            HttpResponseMessage response = method.Method switch
            {
                "POST" => await client.PostAsync(route, content),
                "PUT" => await client.PutAsync(route, content),
                _ => throw new ArgumentException("Only POST/PUT allowed")
            };

            object result;
            var raw = await response.Content.ReadAsStringAsync();

            try
            {
                result = JsonSerializer.Deserialize<object>(raw)!;
            }
            catch
            {
                result = raw;
            }

            return new ObjectResult(result)
            {
                StatusCode = (int)response.StatusCode
            };
        }
    }
}
