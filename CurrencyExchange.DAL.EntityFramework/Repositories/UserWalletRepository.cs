namespace CurrencyExchange.DAL.EntityFramework.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using CurrencyExchange.DAL.EntityFramework.Abstraction;
    using CurrencyExchange.DAL.EntityFramework.Entities;
    using CurrencyExchange.DAL.Repositories;
    using CurrencyExchange.Model.Abstractions;

    public class UserWalletRepository : EfRepository<IUserWallet, UserWallet>, IUserWalletRepository
    {
        public UserWalletRepository(
            IEfDbContext dbContext,
            IMapper mapper)
        : base(dbContext, mapper)
        {
        }

        public List<IUserWallet> Get(Guid userId)
        {
            return _dbContext.UserWallets
                .Where(uw => uw.UserId == userId)
                .AsEnumerable<IUserWallet>()
                .ToList();
        }

        public IUserWallet Get(Guid userId, Guid currencyId)
        {
            return _dbContext.UserWallets
                .Where(uw => uw.UserId == userId)
                .Where(uw => uw.CurrencyId == currencyId)
                .FirstOrDefault();
        }
    }
}
