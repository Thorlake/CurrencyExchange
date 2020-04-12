namespace CurrencyExchange.API.Dto.Requests.User
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using CurrencyExchange.BLL.Abstractions;

    public class UserExchangeRequest : IUserWalletExchange
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid FromCurrencyId { get; set; }

        [Required]
        public Guid ToCurrencyId { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
