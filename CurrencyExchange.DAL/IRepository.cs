namespace CurrencyExchange.DAL
{
    using System;
    using System.Collections.Generic;
    using CurrencyExchange.Model.Abstractions;

    public interface IRepository<T>
        where T : class, IEntity
    {
        T GetById(Guid id);

        T FirstOrDefault(Guid id);

        List<T> Get();

        T Add(T item);

        void Remove(T item);

        void Remove(Guid id);
    }
}
