using ScrumRandomizerServer.Data.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrumRandomizerServer.Core.Logging
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(IServiceProvider serviceProvider)
        {
            _logRepository = (ILogRepository)serviceProvider.GetService(typeof(ILogRepository));
        }

        async Task<List<ILogEntry>> ILogService.GetAll()
        {
            List<ILogEntry> result = null;
            try
            {
                result = await _logRepository.GetAll();
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured during '{nameof(ILogService.GetAll)}' in class '{nameof(LogService)}' -> {ex}");
            }
            return result
                ?? new List<ILogEntry>();
        }

        async Task<List<ILogEntry>> ILogService.GetAllDebugEntries()
        {
            List<ILogEntry> result = null;
            try
            {
                result = await _logRepository.GetAllDebugEntries();
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured during '{nameof(ILogService.GetAllDebugEntries)}' in class '{nameof(LogService)}' -> {ex}");
            }
            return result
                ?? new List<ILogEntry>();
        }

        async Task<List<ILogEntry>> ILogService.GetAllErrorEntries()
        {
            List<ILogEntry> result = null;
            try
            {
                result = await _logRepository.GetAllErrorEntries();
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured during '{nameof(ILogService.GetAllErrorEntries)}' in class '{nameof(LogService)}' -> {ex}");
            }
            return result
                ?? new List<ILogEntry>();
        }

        async Task<List<ILogEntry>> ILogService.GetAllInformationEntries()
        {
            List<ILogEntry> result = null;
            try
            {
                result = await _logRepository.GetAllInformationEntries();
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured during '{nameof(ILogService.GetAllInformationEntries)}' in class '{nameof(LogService)}' -> {ex}");
            }
            return result
                ?? new List<ILogEntry>();
        }

        async Task<List<ILogEntry>> ILogService.GetAllWarningEntries()
        {
            List<ILogEntry> result = null;
            try
            {
                result = await _logRepository.GetAllWarningEntries();
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured during '{nameof(ILogService.GetAllWarningEntries)}' in class '{nameof(LogService)}' -> {ex}");
            }
            return result
                ?? new List<ILogEntry>();
        }
    }
}