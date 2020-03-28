namespace CurrencyExchange.BLL.Abstractions.Services.Args
{
    using System;
    using CurrencyExchange.Model.Abstractions;

    public class CreateUserArgs : IUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}