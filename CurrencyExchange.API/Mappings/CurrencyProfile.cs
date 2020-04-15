namespace CurrencyExchange.API.Mappings
{
    using AutoMapper;
    using CurrencyExchange.API.Dto.Responses.Currency;
    using CurrencyExchange.Model.Abstractions;

    public class CurrencyResponseProfile : Profile
    {
        public CurrencyResponseProfile()
        {
            CreateMap<ICurrency, CurrencyResponse>();
        }
    }
}
