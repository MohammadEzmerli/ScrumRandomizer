using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ScrumRandomizerServer.Data.Logging
{
    [BsonIgnoreExtraElements]
    public class MongoLogEntry : ILogEntry
    {
        public string Level { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string RenderedMessage { get; set; } = string.Empty;
        public string MethodName { get; set; } = string.Empty;
        public string OperatingSystem { get; set; } = string.Empty;
        public string ApplicationName { get; set; } = string.Empty;
        public string MachineName { get; set; } = string.Empty;
    }
}