using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using ScrumRandomizerServer.Core.AutoMapper;
using ScrumRandomizerServer.Core.Logging;
using ScrumRandomizerServer.Core.Randomization;
using ScrumRandomizerServer.Core.RepositoryFactory;
using ScrumRandomizerServer.Core.ServiceFactory;
using ScrumRandomizerServer.Core.Users;
using ScrumRandomizerServer.Data.DbFactory;
using ScrumRandomizerServer.Data.Logging;
using ScrumRandomizerServer.Data.Users;
using Serilog;
using System.Threading.Tasks; 

namespace ScrumRandomizerServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHealthChecks()
                    .AddAsyncCheck("health", () => Task.FromResult(new HealthCheckResult(HealthStatus.Healthy)));

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            }).CreateMapper());

            // repositories
            services.AddScoped((serviceProvider) => RepositoryFactory.CreateRepository<IMongoDbFactory>(serviceProvider));
            services.AddScoped((serviceProvider) => RepositoryFactory.CreateRepository<ILogRepository>(serviceProvider));
            services.AddScoped((serviceProvider) => RepositoryFactory.CreateRepository<IUserRepository>(serviceProvider));

            // services
            services.AddScoped((serviceProvider) => ServiceFactory.CreateService<ILogService>(serviceProvider));
            services.AddScoped((serviceProvider) => ServiceFactory.CreateService<IUserService>(serviceProvider));
            services.AddScoped((serviceProvider) => ServiceFactory.CreateService<IRandomizerService>(serviceProvider));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}