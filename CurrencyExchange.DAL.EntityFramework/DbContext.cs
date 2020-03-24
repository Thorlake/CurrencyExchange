namespace CurrencyExchange.DAL.Cache
{
    using System;
    using CurrencyExchange.DAL;
    using CurrencyExchange.DAL.Repositories;

    public class DbContext : IDbContext
    {
        public IUserRepository Users => throw new NotImplementedException();

        public IWalletRepository Wallets => throw new NotImplementedException();
    }
}
