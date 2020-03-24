namespace CurrencyExchange.BLL.Services
{
    using System;
    using CurrencyExchange.Model.Abstractions;

    public interface IWalletService
    {
        // queries

        IWallet GetById(Guid id);

        // commands

        void UpdateAmount(Guid id);
    }
}
