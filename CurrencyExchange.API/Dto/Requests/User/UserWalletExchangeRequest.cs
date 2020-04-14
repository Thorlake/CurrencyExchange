namespace CurrencyExchange.API.Dto.Requests.User
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using CurrencyExchange.BLL.Abstractions;

    public class UserWalletExchangeRequest : IUserWalletExchange
    {
        [Required]
        public Guid FromCurrencyId { get; set; }

        [Required]
        public Guid ToCurrencyId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        // ignored

        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
