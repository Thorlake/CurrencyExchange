namespace CurrencyExchange.Model.Abstractions
{
    using System;

    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
