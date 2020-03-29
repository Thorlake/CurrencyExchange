namespace CurrencyExchange.DAL.EntityFramework
{
    using System.Data;
    using AutoMapper;
    using CurrencyExchange.DAL;
    using CurrencyExchange.DAL.EntityFramework.Abstraction;
    using CurrencyExchange.DAL.EntityFramework.Repositories;
    using CurrencyExchange.DAL.Repositories;

    public class DbContext : IDbContext
    {
        private readonly IEfDbContext _context;

        public DbContext(IEfDbContext context, IMapper mapper)
        {
            Users = new UserRepository(context, mapper);
            UserWallets = new UserWalletRepository(context, mapper);
            Currencies = new CurrencyRepository(context, mapper);

            _context = context;
        }

        public IUserRepository Users { get; }

        public IUserWalletRepository UserWallets { get; }

        public ICurrencyRepository Currencies { get; }

        public void Migrate() => _context.Migrate();

        public ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return new EfTransaction(_context.BeginTransaction(isolationLevel));
        }
    }
}
