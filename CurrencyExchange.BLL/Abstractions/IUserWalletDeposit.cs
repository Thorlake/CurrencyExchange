namespace CurrencyExchange.BLL.Abstractions
{
    using System;

    public interface IUserWalletDeposit
    {
        Guid UserId { get; set; }

        Guid CurrencyId { get; set; }

        decimal Amount { get; set; }
    }
}
