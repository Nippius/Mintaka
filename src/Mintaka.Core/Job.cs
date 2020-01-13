using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mintaka.Core
{
    abstract class Job : IJob
    {
        private readonly IServiceProvider serviceProvider;

        public ISchedule Schedule { get; }

        public Job(
            ISchedule schedule,
            IServiceProvider serviceProvider)
        {
            this.Schedule = schedule;
            this.serviceProvider = serviceProvider;
        }

        public abstract Task DoJobAsync(CancellationToken cancellationToken);
    }
}
