using ScrumRandomizerServer.Data.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrumRandomizerServer.Core.Logging
{
    public interface ILogService
    {
        Task<List<ILogEntry>> GetAll();
        Task<List<ILogEntry>> GetAllDebugEntries();
        Task<List<ILogEntry>> GetAllErrorEntries();
        Task<List<ILogEntry>> GetAllInformationEntries();
        Task<List<ILogEntry>> GetAllWarningEntries();
    }
}
