using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrumRandomizerServer.Data.Logging
{
    public interface ILogRepository
    {
        Task<List<ILogEntry>> GetAll();

        Task<List<ILogEntry>> GetAllDebugEntries();

        Task<List<ILogEntry>> GetAllErrorEntries();

        Task<List<ILogEntry>> GetAllInformationEntries();

        Task<List<ILogEntry>> GetAllWarningEntries();
    }
}