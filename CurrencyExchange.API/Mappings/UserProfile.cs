namespace CurrencyExchange.API.Mappings
{
    using AutoMapper;
    using CurrencyExchange.API.Dto.Requests.User;
    using CurrencyExchange.API.Dto.Responses.User;
    using CurrencyExchange.BLL.Abstractions.Services.Args;
    using CurrencyExchange.Model.Abstractions;

    public class UserRequestProfile : Profile
    {
        public UserRequestProfile()
        {
            CreateMap<CreateUserRequest, CreateUserArgs>();
        }
    }

    public class UserResponseProfile : Profile
    {
        public UserResponseProfile()
        {
            CreateMap<IUser, UserResponse>();
        }
    }
}
