namespace CurrencyExchange.Model.Entities
{
    using System;
    using CurrencyExchange.Model.Abstractions;

    public class User : IUser
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
