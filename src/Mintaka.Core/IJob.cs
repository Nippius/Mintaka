using System;
using System.Threading;

namespace Mintaka.Core
{
    public interface IJob
    {
        DateTimeOffset NextExceutionTime { get; }

        void DoJob(CancellationToken cancellationToken);
    }
}
