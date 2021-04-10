using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ScrumRandomizerServer.Core.Configuration;
using Serilog;
using System;
using System.Threading.Tasks;

namespace ScrumRandomizerServer
{
    public class Program
    {
        private static IConfiguration Configuration;

        public static async Task Main(string[] args)
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(AppSettingsHelper.GetAppsettingsName(), optional: false)
                .Build();
            Log.Logger = Core.Logging.LoggerFactory.Create(Configuration);

            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var port = Int32.TryParse(Configuration.GetSection(Core.Configuration.Constants.ConfigurationPortSection)?.Value, out int result)
                       ? result
                       : DefaultValues.Port;

                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(kestrelConfig =>
                    {
                        kestrelConfig.ListenAnyIP(port);
                    });
                });
    }
}
