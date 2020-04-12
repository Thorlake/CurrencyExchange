namespace CurrencyExchange.BLL.Abstractions
{
    public interface ICurrencyRate
    {
        string Code { get; set; }

        decimal Rate { get; set; }
    }
}
