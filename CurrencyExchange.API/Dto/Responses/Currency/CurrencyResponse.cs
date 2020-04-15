namespace CurrencyExchange.API.Dto.Responses.Currency
{
    using System;
    using CurrencyExchange.Model.Abstractions;

    public class CurrencyResponse : ICurrency
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public decimal Rate { get; set; }
    }
}
