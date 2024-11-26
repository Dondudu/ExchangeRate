using ExchangeRate.Models;

namespace ExchangeRate.ExternalClients.ExchangeRateApi
{
    public class ExchangeRateApiClient : IExchangeRateApiClient
    {
        readonly string _apiKey;
        readonly string _baseUrl;

        public ExchangeRateApiClient(string apiKey)
        {
            _baseUrl = @"https://v6.exchangerate-api.com";
            _apiKey = apiKey;
        }

        public async Task<ConversionRateResponse> Latest(string currency)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            var result = await client.GetAsync($"v6/{_apiKey}/latest/{currency}");
            var deserialized = await result.Content.ReadFromJsonAsync<ConversionRateResponse>();
            if (deserialized == null)
                throw new Exception();
            return deserialized;
        }
    }
}
