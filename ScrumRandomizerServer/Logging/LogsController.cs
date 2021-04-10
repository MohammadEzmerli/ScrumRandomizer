using Microsoft.AspNetCore.Mvc;
using ScrumRandomizerServer.Core.Logging;
using System;
using System.Threading.Tasks;

namespace ScrumRandomizerServer.Logging
{
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogsController(IServiceProvider serviceProvider)
        {
            _logService = (ILogService)serviceProvider.GetService(typeof(ILogService));
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _logService.GetAll());
        }
    }
}