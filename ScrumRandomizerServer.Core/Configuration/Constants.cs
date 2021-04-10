namespace ScrumRandomizerServer.Core.Configuration
{
    public static class Constants
    {
        public const string ConfigurationDefaultEnvironment = "Production";
        public const string ConfigurationEnvironmentVariable = "ASPNETCORE_ENVIRONMENT";
        public const string ConfigurationFileName = "appsettings.json";
        public const string ConfigurationLogLevelSection = "Logging:LogLevel:MininumLevel";
        public const string ConfigurationPortSection = "Kestrel:Port";
    }
}