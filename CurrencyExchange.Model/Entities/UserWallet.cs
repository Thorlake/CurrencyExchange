﻿namespace CurrencyExchange.Model.Entities
{
    using System;
    using CurrencyExchange.Model.Abstractions;

    public class UserWallet : IUserWallet
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid CurrencyId { get; set; }

        public decimal Balance { get; set; }
    }
}
