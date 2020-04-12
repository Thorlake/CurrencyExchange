namespace CurrencyExchange.BLL.Services.JobService.Jobs
{
    using CurrencyExchange.BLL.Abstractions.Services;
    using CurrencyExchange.DAL;
    using CurrencyExchange.Model.Entities;

    public class UpdateCurrenciesJob : BaseJob
    {
        private readonly IDbContext _dbContext;
        private readonly ICurrencyRateService _currencyRateService;

        public UpdateCurrenciesJob(
            IDbContext dbContext,
            ICurrencyRateService currencyRateService)
        {
            _dbContext = dbContext;
            _currencyRateService = currencyRateService;
        }

        protected override void RunSafe()
        {
            var currencyRates = _currencyRateService.Get();
            foreach (var curencyRate in currencyRates)
            {
                var currency = _dbContext.Currencies.GetBy(curencyRate.Code);
                if (currency == null)
                {
                    currency = new Currency
                    {
                        Code = curencyRate.Code,
                        Rate = curencyRate.Rate
                    };
                    _dbContext.Currencies.Add(currency);
                }
                else
                {
                    currency.Rate = curencyRate.Rate;
                    _dbContext.Currencies.Update(currency);
                }
            }
        }
    }
}
