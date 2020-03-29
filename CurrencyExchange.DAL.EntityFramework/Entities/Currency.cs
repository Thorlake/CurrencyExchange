namespace CurrencyExchange.DAL.EntityFramework.Entities
{
    using System;
    using System.Collections.Generic;
    using CurrencyExchange.Model.Abstractions;

    public class Currency : ICurrency
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public decimal Rate { get; set; }

        // FK

        public ICollection<UserWallet> UserWallets { get; set; }
    }
}
