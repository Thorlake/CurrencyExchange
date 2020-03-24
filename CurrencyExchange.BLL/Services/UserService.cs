namespace CurrencyExchange.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using CurrencyExchange.BLL.Abstractions.Services.Args;
    using CurrencyExchange.DAL;
    using CurrencyExchange.Model.Abstractions;

    public class UserService : IUserService
    {
        private readonly IDbContext _context;

        public UserService(
           IDbContext context)
        {
            _context = context;
        }

        public IReadOnlyCollection<IUser> Get()
        {
            return _context.Users.Get();
        }

        public IUser GetById(Guid id)
        {
            return _context.Users.GetById(id);
        }

        public IUser Add(CreateUserArgs user)
        {
            return _context.Users.Add(user);
        }

        public void UpdateAmount(Guid id)
        {
            // Method intentionally left empty.
        }

        public void Remove(Guid id) => _context.Users.Remove(id);
    }
}
