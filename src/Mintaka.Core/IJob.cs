using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mintaka.Core
{
    public interface IJob
    {
        ISchedule Schedule { get; }

        Task DoJobAsync(CancellationToken cancellationToken);
    }
}
