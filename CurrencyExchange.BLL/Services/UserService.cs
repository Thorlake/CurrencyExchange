namespace CurrencyExchange.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using CurrencyExchange.BLL.Abstractions.Services;
    using CurrencyExchange.BLL.Abstractions.Services.Args;
    using CurrencyExchange.DAL;
    using CurrencyExchange.Model.Abstractions;

    public class UserService : IUserService
    {
        private readonly IDbContext _context;

        public UserService(IDbContext context)
        {
            _context = context;
        }

        public IReadOnlyCollection<IUser> Get()
        {
            return _context.Users.Get();
        }

        public IUser GetBy(Guid id)
        {
            return _context.Users.GetBy(id);
        }

        public IUser Add(UserCreateArgs args)
        {
            IUser user = args;
            return _context.Users.Add(user);
        }

        public void Remove(Guid id) => _context.Users.Remove(id);
    }
}
