using AttractionApiService.View;
using System.Net.Http;
using System.Text.Json;

namespace AttractionApiService.Service
{
    public class GeocodingService
    {
        private readonly HttpClient _httpClient;

        public GeocodingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add(
                "User-Agent",
                "OfferApiService/1.0"
            );
        }

        public async Task<(double lat, double lon)?> GetCoordinatesAsync(
            string street,
            string houseNumber,
            string city,
            string postcode,
            string country
        )
        {
            var url =
                "https://nominatim.openstreetmap.org/search?" +
                $"street={Uri.EscapeDataString($"{street} {houseNumber}")}&" +
                $"city={Uri.EscapeDataString(city)}&" +
                $"postcode={Uri.EscapeDataString(postcode)}&" +
                $"country={Uri.EscapeDataString(country)}&" +
                "format=json&limit=1";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<NominatimResponse>>(json);

            if (data == null || data.Count == 0)
                return null;

            return (
                double.Parse(data[0].lat, System.Globalization.CultureInfo.InvariantCulture),
                double.Parse(data[0].lon, System.Globalization.CultureInfo.InvariantCulture)
            );
        }
    }
}
