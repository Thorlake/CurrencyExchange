namespace CurrencyExchange.DAL.EntityFramework.Abstraction
{
    using System.Data;
    using CurrencyExchange.DAL.EntityFramework.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Storage;

    public interface IEfDbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Currency> Currencies { get; set; }

        DbSet<UserWallet> UserWallets { get; set; }

        int SaveChanges();

        DbSet<T> Set<T>()
            where T : class;

        EntityEntry<T> Entry<T>(T entity)
            where T : class;

        void Migrate();

        IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}
