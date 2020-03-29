namespace CurrencyExchange.DAL.Repositories
{
    using CurrencyExchange.Model.Abstractions;

    public interface ICurrencyRepository : IRepository<ICurrency>
    {
        ICurrency GetBy(string code);
    }
}
