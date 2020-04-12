namespace CurrencyExchange.BLL.Abstractions
{
    using System;

    public interface IUserWalletWithdrawal
    {
        Guid UserId { get; set; }

        Guid CurrencyId { get; set; }

        decimal Amount { get; set; }
    }
}
