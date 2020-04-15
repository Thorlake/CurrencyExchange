namespace CurrencyExchange.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using CurrencyExchange.BLL.Abstractions.Services;
    using CurrencyExchange.DAL;
    using CurrencyExchange.Model.Abstractions;

    public class CurrencyService : ICurrencyService
    {
        private readonly IDbContext _context;

        public CurrencyService(IDbContext context)
        {
            _context = context;
        }

        // queries

        public IReadOnlyCollection<ICurrency> Get()
        {
            return _context.Currencies.Get();
        }

        public ICurrency GetBy(Guid id)
        {
            return _context.Currencies.GetBy(id);
        }
    }
}
