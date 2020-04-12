namespace CurrencyExchange.Model.Entities
{
    using System;
    using CurrencyExchange.Model.Abstractions;

    public class Currency : ICurrency
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public decimal Rate { get; set; }
    }
}
