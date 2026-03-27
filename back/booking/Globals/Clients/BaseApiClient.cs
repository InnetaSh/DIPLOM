using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Globals.Clients
{
    public abstract class BaseApiClient
    {
        protected readonly HttpClient _client;
        protected readonly ILogger _logger;

        protected BaseApiClient(HttpClient client, ILogger logger)
        {
            _client = client;
            _logger = logger;
        }

        //=====================================================================================
        // GET
        //=====================================================================================
        public Task<T?> GetAsync<T>(string url, int maxAttempts = 3, Dictionary<string, string>? headers = null)
        {
            return SendAsync<T>(HttpMethod.Get, url, null, maxAttempts, headers);
        }

        //=====================================================================================
        // POST
        //=====================================================================================
        public Task<T?> PostAsync<T>(string url, object payload, int maxAttempts = 3, Dictionary<string, string>? headers = null)
        {
            return SendAsync<T>(HttpMethod.Post, url, payload, maxAttempts, headers);
        }

        //=====================================================================================
        // PUT
        //=====================================================================================
        public Task<T?> PutAsync<T>(string url, object payload, int maxAttempts = 3, Dictionary<string, string>? headers = null)
        {
            return SendAsync<T>(HttpMethod.Put, url, payload, maxAttempts, headers);
        }

        //=====================================================================================
        // DELETE без тела
        //=====================================================================================
        public Task DeleteAsync(string url, int maxAttempts = 3, Dictionary<string, string>? headers = null)
        {
            return SendAsync<object>(HttpMethod.Delete, url, null, maxAttempts, headers);
        }

        // DELETE с возвращаемым типом
        public Task<T?> DeleteAsync<T>(string url, int maxAttempts = 3, Dictionary<string, string>? headers = null)
        {
            return SendAsync<T>(HttpMethod.Delete, url, null, maxAttempts, headers);
        }

        //=====================================================================================
        // SEND ASYNC с поддержкой заголовков
        //=====================================================================================
        private async Task<T?> SendAsync<T>(
            HttpMethod method,
            string url,
            object? payload = null,
            int maxAttempts = 3,
            Dictionary<string, string>? headers = null)
        {
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    var fullUrl = new Uri(_client.BaseAddress!, url);
                    _logger.LogInformation("HTTP {Method} {Url}", method, fullUrl);

                    using var request = new HttpRequestMessage(method, url);

                    // тело запроса
                    if (payload != null)
                        request.Content = JsonContent.Create(payload);

                    // добавление кастомных заголовков
                    if (headers != null)
                    {
                        foreach (var header in headers)
                            request.Headers.Add(header.Key, header.Value);
                    }

                    var response = await _client.SendAsync(request);

                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        _logger.LogWarning("Endpoint not found: {Url}", fullUrl);
                        return default;
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        _logger.LogError(
                            "HTTP {Status} from {Url}. Body: {Body}",
                            response.StatusCode,
                            fullUrl,
                            body
                        );

                        throw new HttpRequestException($"Bad status: {response.StatusCode}");
                    }

                    if (response.Content.Headers.ContentLength == 0)
                        return default;

                    var result = await response.Content.ReadFromJsonAsync<T>();
                    return result;
                }
                catch (Exception ex) when (attempt < maxAttempts)
                {
                    _logger.LogWarning(ex, "Attempt {Attempt} failed for {Url}", attempt, url);
                    await Task.Delay(1000 * attempt);
                }
            }

            throw new Exception($"Service unavailable after {maxAttempts} attempts. Url: {url}");
        }
    }
}