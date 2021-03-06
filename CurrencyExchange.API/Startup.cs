﻿namespace CurrencyExchange.API
{
    using CurrencyExchange.API.Extensions;
    using CurrencyExchange.API.Helpers;
    using CurrencyExchange.API.Settings;
    using Hangfire;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureAndBind<DatabaseSettings>(Configuration.GetSection("Database"));
            services.ConfigureAndBind<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            services.AddControllers();
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });
            services.AddCurrencyExchange();
            services.AddHangfire();
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // auth

            app.UseAuthorization();

            // Database

            app.MigrateDatabase();

            // swagger

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Currency Exchange API");
                c.RoutePrefix = string.Empty;
            });

            // hangfire

            app.UseHangfire();
            if (!env.IsProduction())
            {
                app.UseHangfireDashboard();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
