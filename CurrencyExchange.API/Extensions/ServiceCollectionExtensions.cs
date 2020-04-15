namespace CurrencyExchange.API.Extensions
{
    using System;
    using AutoMapper;
    using CurrencyExchange.API.Settings;
    using CurrencyExchange.BLL.Abstractions.Services;
    using CurrencyExchange.BLL.Services;
    using CurrencyExchange.BLL.Services.JobService;
    using CurrencyExchange.DAL;
    using CurrencyExchange.DAL.EntityFramework.Abstraction;
    using CurrencyExchange.DAL.EntityFramework.SqlServer;
    using Microsoft.EntityFrameworkCore;
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
                typeof(Mappings.UserRequestProfile),
                typeof(BLL.Mappings.UserWalletProfile),
                typeof(DAL.EntityFramework.Mappings.EntitiesProfile)
            );

            services.AddDbContext();
            services.AddBLLServices();

            return services;
        }

        private static void AddDbContext(
            this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var connectionStrings = provider.GetRequiredService<ConnectionStrings>();
            var databaseSettings = provider.GetRequiredService<DatabaseSettings>();

            databaseSettings.MatchProvider(
                msSql: () =>
                {
                    return services.AddDbContext<IEfDbContext, SqlServerDbContext>(opt =>
                    {
                        opt.UseSqlServer(connectionStrings.Api);
                    });
                },
                mySql: () => throw new NotImplementedException("Implement to support MySQL"),
                pgSql: () => throw new NotImplementedException("Implement to support PostgreSQL")
            );

            services.TryAddScoped<IDbContext, DAL.EntityFramework.DbContext>();
        }

        private static void AddBLLServices(
            this IServiceCollection services)
        {
            services.TryAddScoped<IUserService, UserService>();
            services.TryAddScoped<IUserWalletService, UserWalletService>();
            services.TryAddScoped<ICurrencyService, CurrencyService>();
            services.TryAddScoped<ICurrencyRateService, CurrencyRateService>();
            services.TryAddScoped<IJobService, JobService>();
        }
    }
}