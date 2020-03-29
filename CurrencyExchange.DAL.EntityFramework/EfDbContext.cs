namespace CurrencyExchange.DAL.EntityFramework
{
    using System;
    using System.Data;
    using CurrencyExchange.DAL.EntityFramework.Abstraction;
    using CurrencyExchange.DAL.EntityFramework.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    public abstract class EfDbContext : Microsoft.EntityFrameworkCore.DbContext, IEfDbContext
    {
        public static string DefaultConnectionStringName { get; } = "Api";

        public DbSet<User> Users { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<UserWallet> UserWallets { get; set; }

        protected EfDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public void Migrate() => base.Database.Migrate();

        public IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return base.Database.BeginTransaction(isolationLevel);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            SetDataAnnotation(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            (Guid currencyRubId, Guid currencyUsdId) currencyGuids = (Guid.NewGuid(), Guid.NewGuid());
            modelBuilder.Entity<Currency>().HasData(
                new Currency[]
                {
                    new Currency { Id = currencyGuids.currencyRubId, Code = "RUB" },
                    new Currency { Id = currencyGuids.currencyUsdId, Code = "KRW" }
                });

            (Guid userAId, Guid userBId) userGuids = (Guid.NewGuid(), Guid.NewGuid());
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id = userGuids.userAId, Name = "User A" },
                    new User { Id = userGuids.userBId, Name = "User B" },
                });

            modelBuilder.Entity<UserWallet>().HasData(
                new UserWallet[]
                {
                    new UserWallet { Id = Guid.NewGuid(), CurrencyId = currencyGuids.currencyRubId, UserId = userGuids.userAId },
                    new UserWallet { Id = Guid.NewGuid(), CurrencyId = currencyGuids.currencyUsdId, UserId = userGuids.userBId },
                });
        }

        private void SetDataAnnotation(ModelBuilder modelBuilder)
        {
            // IEntityTypeConfiguration<T> can be used to separate entites model building

            // User
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserWallets)
                .WithOne(uw => uw.User)
                .HasForeignKey(uw => uw.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User wallets
            modelBuilder.Entity<UserWallet>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<UserWallet>()
                .Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<UserWallet>()
                .Property(u => u.Balance)
                .IsRequired();

            // Currency
            modelBuilder.Entity<Currency>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Currency>()
                .Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Currency>()
                .Property(u => u.Code)
                .IsRequired();
            modelBuilder.Entity<Currency>()
                .HasMany(c => c.UserWallets)
                .WithOne(uw => uw.Currency)
                .HasForeignKey(uw => uw.CurrencyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
