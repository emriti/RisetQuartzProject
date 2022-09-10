using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBLL
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save();
    }
}
