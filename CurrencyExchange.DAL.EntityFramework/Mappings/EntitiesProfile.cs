namespace CurrencyExchange.DAL.EntityFramework.Mappings
{
    using AutoMapper;
    using CurrencyExchange.DAL.EntityFramework.Entities;
    using CurrencyExchange.Model.Abstractions;

    public class EntitiesProfile : Profile
    {
        public EntitiesProfile()
        {
            CreateMap<IUser, User>();
            CreateMap<IUserWallet, UserWallet>();
            CreateMap<ICurrency, Currency>();
        }
    }
}
