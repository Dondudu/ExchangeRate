using ExchangeRate.ExternalClients.ExchangeRateApi;
using ExchangeRate.Services;

namespace ExchangeRate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSingleton<CurrencyConverterService>();
            builder.Services.AddSingleton<IExchangeRateApiClient, ExchangeRateApiClient>(sp =>
            {
                string apiKey = builder.Configuration["ExchangeRateApiKey"] ?? "";
                return new ExchangeRateApiClient(apiKey);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
