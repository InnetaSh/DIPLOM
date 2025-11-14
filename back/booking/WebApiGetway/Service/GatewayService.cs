using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Service
{
    public class GatewayService : IGatewayService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<GatewayService> _logger;

        public GatewayService(IHttpClientFactory clientFactory, ILogger<GatewayService> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task<IActionResult> ForwardRequestAsync<TRequest>(
            string serviceName,
            string route,
            HttpMethod method,
           TRequest? request = null
        ) where TRequest : class
        {
            var client = _clientFactory.CreateClient(serviceName);
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

            Console.WriteLine($"[Gateway] {method.Method} {serviceName}{route} - Status: {response.StatusCode}");

            _logger.LogInformation("[Gateway] {Method} {Service}{Route} -> Status: {Status}",
                method, serviceName, route, response.StatusCode);

            if (request != null)
                _logger.LogInformation("[Gateway] Payload: {Payload}", JsonSerializer.Serialize(request));

            if (response.IsSuccessStatusCode)
            {
                if (method == HttpMethod.Delete)
                    return new OkResult();

                var result = await response.Content.ReadFromJsonAsync<object>();
                return new OkObjectResult(result);
            }

            return new StatusCodeResult((int)response.StatusCode);
        }
    }
}
