using ExchangeRate.ExternalClients;
using ExchangeRate.ExternalClients.ExchangeRateApi;
using ExchangeRate.Models;

namespace ExchangeRate.Services
{
    public class CurrencyConverterService
    {
        IExchangeRateApiClient _exchangeRateClient;

        public CurrencyConverterService(IExchangeRateApiClient exchangeRateClient)
        {
            _exchangeRateClient = exchangeRateClient;
        }

        public async Task<Money> ConvertCurrency(Money money, Currency target)
        {
            var latestRates = await _exchangeRateClient.Latest(money.Currency.ToString());
            decimal rate;
            switch (target)
            {
                case Currency.USD:
                    rate = latestRates.conversion_rates.USD;
                    break;
                case Currency.AUD:
                    rate = latestRates.conversion_rates.AUD;
                    break;
                default:
                    throw new ArgumentException();
            }

            return new Money(target, money.Amount * rate);
        }
    }
}
