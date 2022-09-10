using Microsoft.Extensions.Logging;

namespace SampleBLL
{
    public class EODService
    {
        private ILogger<EODService> _logger;
        private IUnitOfWork _uow;

        public EODService(ILogger<EODService> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }

        public async Task DoSomething()
        {
            _logger.LogInformation("EODService: executes DoSomething()");
            await _uow.Save();
        }
    }
}