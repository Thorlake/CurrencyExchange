namespace CurrencyExchange.DAL.EntityFramework
{
    using Microsoft.EntityFrameworkCore.Storage;

    public sealed class EfTransaction : ITransaction
    {
        private readonly IDbContextTransaction _transaction;

        public EfTransaction(IDbContextTransaction transaction)
        {
            _transaction = transaction;
        }

        public bool Commited { get; private set; }

        public void Commit()
        {
            _transaction.Commit();
            Commited = true;
        }

        public void Dispose()
        {
            if (!Commited)
            {
                _transaction.Rollback();
            }

            _transaction.Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
