namespace CurrencyExchange.DAL.Cache
{
    using System;
    using CurrencyExchange.DAL.Cache.Repositories;
    using CurrencyExchange.DAL.Repositories;

    public class DbContext : IDbContext
    {
        public IUserRepository Users => new UserRepository();

        public IWalletRepository Wallets => throw new NotImplementedException();
    }
}
