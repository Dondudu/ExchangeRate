using ExchangeRate.ExternalClients.ExchangeRateApi;
using ExchangeRate.Services;
using ExchangeRate.Models;
using Moq;

namespace Tests
{
    public class CurrencyConverterTests
    {
        [Fact]
        public void ConvertCurrency_IsCorrect()
        {
            var currencyMock = new Mock<IExchangeRateApiClient>();
            currencyMock.Setup(x => x.Latest("USD")).ReturnsAsync(new ConversionRateResponse()
            {
                conversion_rates = new ConversionRates()
                {
                    AUD = 1.5m
                }
            });

            var x = new CurrencyConverterService(currencyMock.Object);
            var result = x.ConvertCurrency(new Money(Currency.USD, 100), Currency.AUD).Result;
            Assert.True(result.Currency == Currency.AUD);
            Assert.True(result.Amount == 150);
        }
    }
}