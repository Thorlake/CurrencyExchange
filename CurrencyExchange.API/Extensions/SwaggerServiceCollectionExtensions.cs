namespace CurrencyExchange.API.Extensions
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    public static class SwaggerServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Currency Exchange API",
                    Version = "v1"
                });

                // to combine by same route names
                c.TagActionsBy(api =>
                {
                    var index = api.RelativePath.IndexOf('/');
                    var controllerName = index < 0
                            ? api.RelativePath
                            : api.RelativePath.Substring(0, index);
                    return new[] { controllerName };
                });

                // order by path not by source order (especially worth for methods)
                c.OrderActionsBy(api => $"{api.RelativePath}_{api.HttpMethod}");
            });

            return services;
        }
    }
}
