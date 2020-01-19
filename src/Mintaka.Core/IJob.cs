using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mintaka.Core
{
    public interface IJob
    {
        TimeSpan NextExecution { get; }

        void DoJob(CancellationToken cancellationToken);
    }
}
