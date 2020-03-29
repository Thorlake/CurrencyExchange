namespace CurrencyExchange.DAL.Repositories
{
    using System;
    using CurrencyExchange.Model.Abstractions;

    public interface IUserWalletRepository : IRepository<IUserWallet>
    {
        IUserWallet Get(Guid userId, Guid currencyId);
    }
}
