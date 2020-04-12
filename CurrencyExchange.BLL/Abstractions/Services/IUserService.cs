namespace CurrencyExchange.BLL.Abstractions.Services
{
    using System;
    using System.Collections.Generic;
    using CurrencyExchange.BLL.Abstractions.Services.Args;
    using CurrencyExchange.Model.Abstractions;

    public interface IUserService
    {
        // queries

        IReadOnlyCollection<IUser> Get();

        IUser GetBy(Guid id);

        // commands

        IUser Add(UserCreateArgs args);

        void Remove(Guid id);
    }
}
