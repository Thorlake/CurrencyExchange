namespace CurrencyExchange.API.Extensions
{
    using AutoMapper;
    using CurrencyExchange.BLL.Services;
    using CurrencyExchange.DAL;
    using CurrencyExchange.DAL.Cache;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCurrencyExchange(
          this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
               {
                   cfg.AllowNullCollections = true;
               },
                typeof(Mappings.UserRequestProfile)
            );

            services.AddDbContext();
            services.AddBLLServices();

            return services;
        }
        private static void AddDbContext(
            this IServiceCollection services)
        {
            services.TryAddScoped<IDbContext, DbContext>();
        }

        private static void AddBLLServices(
            this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWalletService, WalletService>();
        }
    }
}