using MongoDB.Driver;
using ScrumRandomizerServer.Data.DbFactory;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumRandomizerServer.Data.Logging
{
    public class MongoLogRepository : ILogRepository
    {
        private readonly IMongoCollection<MongoLogEntry> _logEntries;

        public MongoLogRepository(IServiceProvider serviceProvider)
        {
            _logEntries = ((IMongoDbFactory)serviceProvider.GetService(typeof(IMongoDbFactory))).GetCollection<MongoLogEntry>();
        }

        async Task<List<ILogEntry>> ILogRepository.GetAll()
        {
            var logEntriesTask = await _logEntries.FindAsync(LogEntry => true);
            var logEntries = await logEntriesTask.ToListAsync();
            return logEntries.Cast<ILogEntry>().ToList();
        }

        async Task<List<ILogEntry>> ILogRepository.GetAllDebugEntries()
        {
            var logEntriesTask = await _logEntries.FindAsync(LogEntry => LogEntry.Level == Enum.GetName(LogEventLevel.Debug));
            var logEntries = await logEntriesTask.ToListAsync();
            return logEntries.Cast<ILogEntry>().ToList();
        }

        async Task<List<ILogEntry>> ILogRepository.GetAllErrorEntries()
        {
            var logEntriesTask = await _logEntries.FindAsync(LogEntry => LogEntry.Level == Enum.GetName(LogEventLevel.Error));
            var logEntries = await logEntriesTask.ToListAsync();
            return logEntries.Cast<ILogEntry>().ToList();
        }

        async Task<List<ILogEntry>> ILogRepository.GetAllInformationEntries()
        {
            var logEntriesTask = await _logEntries.FindAsync(LogEntry => LogEntry.Level == Enum.GetName(LogEventLevel.Information));
            var logEntries = await logEntriesTask.ToListAsync();
            return logEntries.Cast<ILogEntry>().ToList();
        }

        async Task<List<ILogEntry>> ILogRepository.GetAllWarningEntries()
        {
            var logEntriesTask = await _logEntries.FindAsync(LogEntry => LogEntry.Level == Enum.GetName(LogEventLevel.Warning));
            var logEntries = await logEntriesTask.ToListAsync();
            return logEntries.Cast<ILogEntry>().ToList();
        }
    }
}