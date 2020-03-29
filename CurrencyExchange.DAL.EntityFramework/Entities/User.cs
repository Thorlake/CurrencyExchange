namespace CurrencyExchange.DAL.EntityFramework.Entities
{
    using System;
    using System.Collections.Generic;
    using CurrencyExchange.Model.Abstractions;

    public class User : IUser
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserWallet> UserWallets { get; set; }
    }
}
