namespace CurrencyExchange.Model.Abstractions
{
    using System;

    public interface IUserWallet : IEntity
    {
        Guid UserId { get; set; }

        Guid CurrencyId { get; set; }

        decimal Balance { get; set; }
    }
}
