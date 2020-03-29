namespace CurrencyExchange.DAL
{
    using System;
    using System.Collections.Generic;
    using CurrencyExchange.Model.Abstractions;

    public interface IRepository<T>
        where T : class, IEntity
    {
        // queries

        List<T> Get();

        T GetBy(Guid id);

        T FirstOrDefault(Guid id);

        // commands

        T Add(T item);

        T Update(T item);

        void Remove(T item);

        void Remove(Guid id);
    }
}
