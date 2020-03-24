namespace CurrencyExchange.DAL.Cache.Repositories
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using CurrencyExchange.DAL.Repositories;
    using CurrencyExchange.Model.Abstractions;

    public class UserRepository : IUserRepository
    {
        // MemoryCache does not have "GetAllKeys" to realize Get() method
        private static readonly ConcurrentDictionary<Guid, IUser> _cache = new ConcurrentDictionary<Guid, IUser>();

        public IUser GetById(Guid id)
        {
            if (!_cache.TryGetValue(id, out IUser user))
            {
                throw new Exception($"User with id {id} not found");
            }

            return user;
        }

        public IUser FirstOrDefault(Guid id)
        {
            _cache.TryGetValue(id, out IUser user);
            return user;
        }

        public List<IUser> Get()
        {
            return _cache
                .Select(x => x.Value)
                .ToList();
        }

        public IUser Add(IUser item)
        {
            item.Id = Guid.NewGuid();
            _cache.TryAdd(item.Id, item);
            return item;
        }

        public void Remove(IUser item) => Remove(item.Id);

        public void Remove(Guid id)
        {
            _cache.TryRemove(id, out _);
        }
    }
}
