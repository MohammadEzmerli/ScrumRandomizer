using System;

namespace ScrumRandomizerServer.Data.Logging
{
    public interface ILogEntry
    {
        string Level { get; set; }
        DateTime Timestamp { get; set; }
        string RenderedMessage { get; set; }
        string MethodName { get; set; }
        string OperatingSystem { get; set; }
        string ApplicationName { get; set; }
        string MachineName { get; set; }
    }
}