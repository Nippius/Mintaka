using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mintaka.Core
{
    class Job : IJob
    {
        public ISchedule Schedule { get; }

        public Task<Action<CancellationToken>> Action { get; }

        public bool RequiresScopedServices { get; }

        public Job(
            ISchedule schedule,
            Task<Action<CancellationToken>> action,
            bool requiresScopedServices = false)
        {
            Schedule = schedule;
            Action = action;
            RequiresScopedServices = requiresScopedServices;
        }
    }
}
