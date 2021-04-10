using System;
using System.IO;

namespace ScrumRandomizerServer.Core.Configuration
{
    public static class AppSettingsHelper
    {
        public static string GetAppsettingsName()
        {
            string appsettingsName = null;
            if (File.Exists($"appsettings.{Environment.MachineName}.json"))
                appsettingsName = $"appsettings.{Environment.MachineName}.json";
            else if (File.Exists($"appsettings.{Environment.GetEnvironmentVariable(Core.Configuration.Constants.ConfigurationEnvironmentVariable)}.json"))
                appsettingsName = $"appsettings.{Environment.GetEnvironmentVariable(Core.Configuration.Constants.ConfigurationEnvironmentVariable)}.json";
            else if (File.Exists($"appsettings.{Core.Configuration.Constants.ConfigurationDefaultEnvironment}.json"))
                appsettingsName = $"appsettings.{Core.Configuration.Constants.ConfigurationDefaultEnvironment}.json";
            else if (File.Exists("appsettings.json"))
                appsettingsName = "appsettings.json";

            return appsettingsName ?? throw new Exception("No valid appsettings-file found. Please make sure that a valid config file is present in the base directory!");
        }
    }
}