namespace CurrencyExchange.Model.Abstractions
{
    public interface ICurrency : IEntity
    {
        string Code { get; set; }

        decimal Rate { get; set; }
    }
}
