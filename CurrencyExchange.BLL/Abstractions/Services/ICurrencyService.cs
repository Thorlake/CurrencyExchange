namespace CurrencyExchange.BLL.Abstractions.Services
{
    using System;
    using System.Collections.Generic;
    using CurrencyExchange.Model.Abstractions;

    public interface ICurrencyService
    {
        // queries

        IReadOnlyCollection<ICurrency> Get();

        ICurrency GetBy(Guid id);
    }
}
