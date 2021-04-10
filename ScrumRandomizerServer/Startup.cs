using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScrumRandomizerServer.Core.Logging;
using ScrumRandomizerServer.Core.RepositoryFactory;
using ScrumRandomizerServer.Core.ServiceFactory;
using ScrumRandomizerServer.Data.DbFactory;
using ScrumRandomizerServer.Data.Logging;

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

            // repositories
            services.AddTransient((serviceProvider) => RepositoryFactory.CreateRepository<IMongoDbFactory>(serviceProvider));
            services.AddTransient((serviceProvider) => RepositoryFactory.CreateRepository<ILogRepository>(serviceProvider));

            // services
            services.AddTransient((serviceProvider) => ServiceFactory.CreateService<ILogService>(serviceProvider));
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
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
