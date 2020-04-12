namespace CurrencyExchange.BLL.Mappings
{
    using AutoMapper;
    using CurrencyExchange.BLL.Abstractions;
    using CurrencyExchange.BLL.Abstractions.Services.Args;

    public class UserWalletProfile : Profile
    {
        public UserWalletProfile()
        {
            CreateMap<IUserWalletExchange, UserWalletWithdrawalArgs>()
                .ForMember(widthdrawal => widthdrawal.CurrencyId, opt => opt.MapFrom(exchange => exchange.FromCurrencyId));

            CreateMap<IUserWalletExchange, UserWalletDepositArgs>()
                .ForMember(deposit => deposit.CurrencyId, opt => opt.MapFrom(exchange => exchange.ToCurrencyId));
        }
    }
}
