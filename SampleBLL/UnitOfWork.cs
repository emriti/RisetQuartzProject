using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBLL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ILogger<UnitOfWork> _logger;

        public UnitOfWork(ILogger<UnitOfWork> logger)
        {
            _logger = logger;
        }

        public async Task Save()
        {
            _logger.LogInformation("UnitOfWork: Save stuff");
        }

        public void Dispose()
        {
            
        }
    }
}
