using Microsoft.Extensions.Configuration;
using ScrumRandomizerServer.Data.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Reflection;

namespace ScrumRandomizerServer.Core.Logging
{
    public static class LoggerFactory
    {
        public static ILogger Create(IConfiguration configuration)
        {
            return new LoggerConfiguration()
                       .WriteTo.Async(sink =>
                           sink.Console(LogEventLevel.Verbose))
                       .WriteTo.Async(sink =>
                           sink.MongoDBCapped(databaseUrl: configuration.GetConnectionString(Data.Configuration.Constants.DatabaseConnectionStringName),
                               collectionName: nameof(ILogEntry),
                               restrictedToMinimumLevel: (LogEventLevel)Enum.Parse(typeof(LogEventLevel),
                               configuration.GetSection(Core.Configuration.Constants.ConfigurationLogLevelSection).Value)))
                       .Enrich.FromLogContext()
                       .Enrich.WithProperty("ApplicationName", Assembly.GetCallingAssembly().GetName().Name)
                       .Enrich.WithProperty("OperatingSystem", Environment.OSVersion.VersionString)
                       .Enrich.WithProperty("WorkingSet", Environment.WorkingSet)
                       .CreateLogger();
        }
    }
}