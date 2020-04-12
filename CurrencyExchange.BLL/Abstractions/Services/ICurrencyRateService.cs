namespace CurrencyExchange.BLL.Abstractions.Services
{
    using System.Collections.Generic;

    public interface ICurrencyRateService
    {
        IReadOnlyCollection<ICurrencyRate> Get();
    }
}
