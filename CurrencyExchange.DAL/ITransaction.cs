namespace CurrencyExchange.DAL
{
    using System;

    public interface ITransaction : IDisposable
    {
        bool Commited { get; }

        void Commit();

        void Rollback();
    }
}
