namespace CurrencyExchange.BLL.Abstractions.Services.Args
{
    using System;

    public class UserWalletExchangeArgs : IUserWalletExchange
    {
        public Guid UserId { get; set; }

        public Guid FromCurrencyId { get; set; }

        public Guid ToCurrencyId { get; set; }

        public decimal Amount { get; set; }
    }
}