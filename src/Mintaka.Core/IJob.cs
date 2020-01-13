using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mintaka.Core
{
    public interface IJob
    {
        Task<Action<CancellationToken>> Action { get; }
        ISchedule Schedule { get; }
        bool RequiresScopedServices { get; }
    }
}
