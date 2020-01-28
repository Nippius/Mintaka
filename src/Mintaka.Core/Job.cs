using System;
using System.Threading;

namespace Mintaka.Core
{
    public abstract class Job : IJob
    {
        public abstract DateTimeOffset NextExceutionTime { get; }

        public abstract void DoJob(CancellationToken cancellationToken);
    }
}
