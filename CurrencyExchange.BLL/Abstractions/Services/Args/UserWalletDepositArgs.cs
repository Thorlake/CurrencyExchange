namespace CurrencyExchange.BLL.Abstractions.Services.Args
{
    using System;

    public class UserWalletDepositArgs : IUserWalletDeposit
    {
        public Guid UserId { get; set; }

        public Guid CurrencyId { get; set; }

        public decimal Amount { get; set; }
    }
}