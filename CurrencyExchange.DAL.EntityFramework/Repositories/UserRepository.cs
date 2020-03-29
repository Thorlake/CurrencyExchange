namespace CurrencyExchange.DAL.EntityFramework.Repositories
{
    using AutoMapper;
    using CurrencyExchange.DAL.EntityFramework.Abstraction;
    using CurrencyExchange.DAL.EntityFramework.Entities;
    using CurrencyExchange.DAL.Repositories;
    using CurrencyExchange.Model.Abstractions;

    public class UserRepository : EfRepository<IUser, User>, IUserRepository
    {
        public UserRepository(
            IEfDbContext dbContext,
            IMapper mapper)
        : base(dbContext, mapper)
        {
        }
    }
}
