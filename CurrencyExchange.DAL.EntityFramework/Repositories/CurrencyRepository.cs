namespace CurrencyExchange.DAL.EntityFramework.Repositories
{
    using System.Linq;
    using AutoMapper;
    using CurrencyExchange.DAL.EntityFramework.Abstraction;
    using CurrencyExchange.DAL.EntityFramework.Entities;
    using CurrencyExchange.DAL.Repositories;
    using CurrencyExchange.Model.Abstractions;

    public class CurrencyRepository : EfRepository<ICurrency, Currency>, ICurrencyRepository
    {
        public CurrencyRepository(
            IEfDbContext dbContext,
            IMapper mapper)
        : base(dbContext, mapper)
        {
        }

        public ICurrency GetBy(string code)
        {
            return _dbContext.Currencies
                .Where(currency => currency.Code.ToLower() == code.ToLower())
                .FirstOrDefault();
        }
    }
}
