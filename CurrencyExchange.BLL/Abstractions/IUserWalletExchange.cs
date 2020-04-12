namespace CurrencyExchange.BLL.Abstractions
{
    using System;

    public interface IUserWalletExchange
    {
        Guid UserId { get; set; }

        Guid FromCurrencyId { get; set; }

        Guid ToCurrencyId { get; set; }

        decimal Amount { get; set; }
    }
}
