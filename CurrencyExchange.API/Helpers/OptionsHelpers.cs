namespace CurrencyExchange.API.Helpers
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    public static class OptionsHelpers
    {
        public static TOptions ConfigureAndBind<TOptions>(this IServiceCollection services, IConfigurationSection section)
            where TOptions : class, new()
        {
            services.Configure<TOptions>(section);
            services.AddScoped(sp => sp.GetRequiredService<IOptionsSnapshot<TOptions>>().Value);
            return section.Get<TOptions>();
        }
    }
}
