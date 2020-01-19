using System;
using System.Threading;

namespace Mintaka.Core
{
    // TODO: To make a Job stop running/run only once, set NextExecution
    //          to Timeout.InifiniteTimeSpan after DoJob() finishes
    public abstract class Job : IJob
    {
        public abstract TimeSpan NextExecution { get; }

        public abstract void DoJob(CancellationToken cancellationToken);
    }
}
