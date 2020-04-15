namespace CurrencyExchange.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using CurrencyExchange.API.Dto.Responses.Currency;
    using CurrencyExchange.BLL.Abstractions.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("currencies")]
    public partial class CurrencyController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyService _currencyService;

        public CurrencyController(
            IMapper mapper,
            ICurrencyService currencyService)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CurrencyResponse> Get()
        {
            var currencies = _currencyService.Get();
            return _mapper.MapMany<CurrencyResponse>(currencies);
        }

        [HttpGet("{id}")]
        public CurrencyResponse GetBy(Guid id)
        {
            var currency = _currencyService.GetBy(id);
            return _mapper.Map<CurrencyResponse>(currency);
        }
    }
}
