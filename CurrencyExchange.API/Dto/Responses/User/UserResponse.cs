namespace CurrencyExchange.API.Dto.Responses.User
{
    using System;
    using CurrencyExchange.Model.Abstractions;

    public class UserResponse : IUser
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
