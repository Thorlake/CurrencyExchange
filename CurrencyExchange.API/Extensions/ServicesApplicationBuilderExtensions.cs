namespace CurrencyExchange.API.Extensions
{
    using CurrencyExchange.DAL;
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
                var context = serviceScope.ServiceProvider.GetService<IDbContext>();
                context.Migrate();
            }

            return app;
        }
    }
}
