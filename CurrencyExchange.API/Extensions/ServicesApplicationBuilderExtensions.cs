namespace CurrencyExchange.API.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServicesApplicationBuilderExtensions
    {
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            using (serviceScope)
            {
                ////var context = serviceScope.ServiceProvider.GetService<IDbContext>();
                //////context.Database.Migrate();
            }

            return app;
        }

        ////public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app, DatabaseSettings settings)
        ////{
        ////    settings.MatchProvider(
        ////        mssql: () => Database.SetInitializer(new MigrateDatabaseToLatestVersion<SqlServerPamDbContext, MsSqlConfig>(true)),
        ////        pgsql: () => Database.SetInitializer(new MigrateDatabaseToLatestVersion<PostgreSqlPamDbContext, PgSqlConfig>(true))
        ////    );

        ////    return app;
        ////}
    }
}
