namespace CurrencyExchange.API.Dto.Requests.User
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using CurrencyExchange.Model.Abstractions;

    public class UserCreateRequest : IUser
    {
        [Required]
        public string Name { get; set; }

        // Ignored

        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
