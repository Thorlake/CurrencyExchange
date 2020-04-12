namespace CurrencyExchange.BLL.Abstractions.Services.Args
{
    using System;

    public class UserWalletWithdrawalArgs : IUserWalletWithdrawal
    {
        public Guid UserId { get; set; }

        public Guid CurrencyId { get; set; }

        public decimal Amount { get; set; }
    }
}