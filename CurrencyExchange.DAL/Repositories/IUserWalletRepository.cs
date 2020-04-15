namespace CurrencyExchange.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using CurrencyExchange.Model.Abstractions;

    public interface IUserWalletRepository : IRepository<IUserWallet>
    {
        List<IUserWallet> Get(Guid userId);

        IUserWallet Get(Guid userId, Guid currencyId);
    }
}
