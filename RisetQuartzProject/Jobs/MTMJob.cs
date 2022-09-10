using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using SampleBLL;
using System;
using System.Threading.Tasks;

namespace RisetQuartzProject.Jobs
{
    public class MTMJob : IJob
    {
        private readonly ILogger<MTMJob> _logger;
        private readonly IServiceProvider _serviceProvider;

        public MTMJob(ILogger<MTMJob> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("MTMJob: executes Execute()");

            using (var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<EODService>();
                if (service != null)
                    await service.DoSomething();
            }
        }
    }
}
