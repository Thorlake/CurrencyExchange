namespace CurrencyExchange.DAL
{
    using System.Data;
    using CurrencyExchange.DAL.Repositories;

    public interface IDbContext
    {
        IUserRepository Users { get; }

        IUserWalletRepository UserWallets { get; }

        ICurrencyRepository Currencies { get; }

        void Migrate();

        ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}
