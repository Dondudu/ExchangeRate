using ExchangeRate.Models;

namespace ExchangeRate.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal To2DP(this decimal amount)
        {
            return Math.Round(amount, 2);
        }
    }
}
