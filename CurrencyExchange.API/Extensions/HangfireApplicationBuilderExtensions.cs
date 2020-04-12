namespace CurrencyExchange.API.Extensions
{
    using CurrencyExchange.BLL.Abstractions.Services;
    using Hangfire;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class HangfireApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseHangfire(this IApplicationBuilder app)
        {
            app.UseHangfireServer();

            var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
            lifetime.ApplicationStarted.Register(() =>
            {
                var serviceScope = app.ApplicationServices
                    .GetRequiredService<IServiceScopeFactory>()
                    .CreateScope();

                using (serviceScope)
                {
                    // resolve inside to have DB migration done already
                    var jobService = serviceScope.ServiceProvider.GetService<IJobService>();
                    jobService.UpdateJobs();
                }
            });

            return app;
        }
    }
}
