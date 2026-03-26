using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApiGetway.Helpers
{

    //--------------------------перевод текста-------------------------------------


    public class TranslatorHelper
    {
        public class TranslateApiResponse
        {
            [JsonPropertyName("translated_text")]
            public string translatedText { get; set; }
        }

        public class Translator
        {
            private static readonly string ApiUrl = "https://api.translateapi.ai/api/v1/translate/";
            private static readonly string ApiKey = "ta_2e6e006e57caa4c8d35f7f813f813b84f1e020b7029a2b8daef06cdf"; // твой ключ

            public static async Task<string> TranslateAsync(string text, string fromLang, string toLang)
            {
                if (string.IsNullOrWhiteSpace(text))
                    return text;

                try
                {
                    using var httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApiKey);

                    var payload = new
                    {
                        text = text,
                        source_language = fromLang.ToLower(),
                        target_language = toLang.ToLower()
                    };

                    var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    var content = JsonContent.Create(payload, options: options);

                    var response = await httpClient.PostAsync(ApiUrl, content);
                    var raw = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("TranslateAPI.ai raw response:");
                    Console.WriteLine(raw);

                    if (!response.IsSuccessStatusCode)
                        return text;

                    var result = JsonSerializer.Deserialize<TranslateApiResponse>(raw);
                    return result?.translatedText ?? text;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Translate error: {ex.Message}");
                    return text;
                }
            }
        }
        public class DeepLTranslationItem
        {
            public string Detected_source_language { get; set; }
            public string Text { get; set; }
        }

    }
}
