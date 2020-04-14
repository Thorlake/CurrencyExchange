namespace CurrencyExchange.API.Mappings
{
    using AutoMapper;
    using CurrencyExchange.API.Dto.Requests.User;
    using CurrencyExchange.API.Dto.Responses.User;
    using CurrencyExchange.BLL.Abstractions.Services.Args;
    using CurrencyExchange.Model.Abstractions;

    public class UserWalletRequestProfile : Profile
    {
        public UserWalletRequestProfile()
        {
            CreateMap<UserWalletDepositRequest, UserWalletDepositArgs>();
            CreateMap<UserWalletWithdrawalRequest, UserWalletWithdrawalArgs>();
            CreateMap<UserWalletExchangeRequest, UserWalletExchangeArgs>();
        }
    }

    public class UserWalletResponseProfile : Profile
    {
        public UserWalletResponseProfile()
        {
            CreateMap<IUserWallet, UserWalletResponse>();
        }
    }
}
