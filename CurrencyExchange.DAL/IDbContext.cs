namespace CurrencyExchange.DAL
{
    using CurrencyExchange.DAL.Repositories;

    public interface IDbContext
    {
        IUserRepository Users { get; }

        IWalletRepository Wallets { get; }
    }
}
