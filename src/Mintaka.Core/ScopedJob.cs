using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Mintaka.Core
{
    public class ScopedJob : IJob
    {
        public DateTimeOffset NextExceutionTime => throw new NotImplementedException();

        public void DoJob(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
