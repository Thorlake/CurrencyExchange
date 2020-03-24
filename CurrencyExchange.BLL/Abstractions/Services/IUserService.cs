namespace CurrencyExchange.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using CurrencyExchange.BLL.Abstractions.Services.Args;
    using CurrencyExchange.Model.Abstractions;

    public interface IUserService
    {
        // queries

        IReadOnlyCollection<IUser> Get();

        IUser GetById(Guid id);

        // commands

        IUser Add(CreateUserArgs user);

        void UpdateAmount(Guid id);

        void Remove(Guid id);
    }
}
