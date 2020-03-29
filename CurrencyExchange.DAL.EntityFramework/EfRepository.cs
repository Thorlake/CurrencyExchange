namespace CurrencyExchange.DAL.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using AutoMapper;
    using CurrencyExchange.DAL.EntityFramework.Abstraction;
    using CurrencyExchange.Model.Abstractions;
    using Microsoft.EntityFrameworkCore;

    public abstract class EfRepository<T, TDatabase> : IRepository<T>
        where T : class, IEntity
        where TDatabase : class, IEntity, T
    {
        private readonly IMapper _mapper;
        private readonly DbSet<TDatabase> _dbSet;
        protected readonly IEfDbContext _dbContext;

        protected EfRepository(IEfDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _dbSet = _dbContext.Set<TDatabase>();
        }

        // queries

        public T GetBy(Guid id) => Find(id);

        public List<T> Get() => _dbSet.ToList<T>();

        // commands

        public virtual T Add(T item)
        {
            var entity = _mapper.Map<T, TDatabase>(item);
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public T Update(T item)
        {
            var entity = Find(item.Id);

            var entityEntry = _dbContext.Entry(entity);
            entityEntry.CurrentValues.SetValues(item);
            entityEntry.State = EntityState.Modified;

            _dbContext.SaveChanges();
            return item;
        }

        public void Remove(T item) => Remove(item.Id);

        public void Remove(Guid id)
        {
            var entity = Find(id);
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public T FirstOrDefault(Guid id) => _dbSet.Find(id);

        private TDatabase Find(Guid id)
        {
            var item = _dbSet.Find(id);

            if (item == null)
            {
                throw new DataException($"{typeof(TDatabase)} with id {id} not found");
            }

            return item;
        }
    }
}
