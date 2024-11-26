
namespace ExchangeRate.ExternalClients.ExchangeRateApi
{
    public interface IExchangeRateApiClient
    {
        Task<ConversionRateResponse> Latest(string currency);
    }
}