using System.Net;

namespace ExchangeRate.Models
{
    public struct Money
    {
        public Money(Currency currency, decimal amount)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
    }
}
