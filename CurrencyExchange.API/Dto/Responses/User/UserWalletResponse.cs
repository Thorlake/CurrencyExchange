namespace CurrencyExchange.API.Dto.Responses.User
{
    using System;
    using CurrencyExchange.Model.Abstractions;

    public class UserWalletResponse : IUserWallet
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid CurrencyId { get; set; }

        public decimal Balance { get; set; }
    }
}
