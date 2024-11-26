using ExchangeRate.Contracts;
using ExchangeRate.Extensions;
using ExchangeRate.Models;
using ExchangeRate.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExchangeServiceController : ControllerBase
    {
        CurrencyConverterService _currencyConverter;

        public ExchangeServiceController(CurrencyConverterService currencyConverterService)
        {
            _currencyConverter = currencyConverterService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("OK");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ExchangeRateRequest request)
        {
            var inputCurrency = Enum.Parse<Currency>(request.InputCurrency);
            var outputCurrency = Enum.Parse<Currency>(request.OutputCurrency);
            var converted = await _currencyConverter.ConvertCurrency(new Money(inputCurrency, request.Amount), outputCurrency);

            return Ok(new ExchangeRateResponse()
            {
                Amount = request.Amount,
                OutputCurrency = converted.Currency.ToString(),
                InputCurrency = request.InputCurrency,
                Value = converted.Amount.To2DP()
            });
        }
    }
}
