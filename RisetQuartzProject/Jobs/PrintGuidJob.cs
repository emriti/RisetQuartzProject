using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisetQuartzProject.Jobs
{
    public class PrintGuidJob : IJob
    {
        private readonly ILogger<PrintGuidJob> _logger;
        private readonly Guid _guid;

        public PrintGuidJob(ILogger<PrintGuidJob> logger)
        {
            _logger = logger;
            _guid = Guid.NewGuid();
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("PrintGuidJob: The job GUID is: " + _guid);
            return Task.CompletedTask;
        }
    }
}
