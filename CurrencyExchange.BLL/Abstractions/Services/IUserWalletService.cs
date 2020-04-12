namespace CurrencyExchange.BLL.Abstractions.Services
{
    using System;
    using System.Collections.Generic;
    using CurrencyExchange.BLL.Abstractions.Services.Args;
    using CurrencyExchange.Model.Abstractions;

    public interface IUserWalletService
    {
        // queries

        IReadOnlyCollection<IUserWallet> Get(Guid userId);

        IUserWallet GetBy(Guid id);

        // commands

        IUserWallet Withdrawal(UserWalletWithdrawalArgs args);

        IUserWallet Deposit(UserWalletDepositArgs args);

        void Exchange(UserWalletExchangeArgs args);
    }
}
