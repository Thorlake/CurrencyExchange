namespace CurrencyExchange.API.Extensions
{
    using System;
    using CurrencyExchange.API.Settings;
    using Hangfire;
    using Hangfire.SqlServer;
    using Microsoft.Extensions.DependencyInjection;

    public static class HangfireServiceCollectionExtensions
    {
        public static IServiceCollection AddHangfire(
            this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var connectionStrings = provider.GetRequiredService<ConnectionStrings>();
            var databaseSettings = provider.GetRequiredService<DatabaseSettings>();

            var jobStorage = databaseSettings.MatchProvider<JobStorage>(
                msSql: () =>
                {
                    return new SqlServerStorage(connectionStrings.Jobs, new SqlServerStorageOptions()
                    {
                        DisableGlobalLocks = true
                    });
                },
                mySql: () => throw new NotImplementedException("Implement to support MySQL"),
                pgSql: () => throw new NotImplementedException("Implement to support PostgreSQL")
            );

            services.AddHangfire(config => config.UseStorage(jobStorage));

            return services;
        }
    }
}
