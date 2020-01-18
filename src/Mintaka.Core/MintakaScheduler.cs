using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mintaka.Core
{
    public class MintakaScheduler : IMintakaScheduler, IDisposable
    {
        private readonly IEnumerable<IJob> jobs;

        /*
         * This timer is responsible for running the ExecuteScheduler() method in a loop.
         * The way this works (and in order to avoid wasting CPU cycles) is that we find
         * when the next job needs to run, set this timer to run our code at that time and 
         * go to sleep until then.
         */
        Timer timer;

        public MintakaScheduler(IEnumerable<IJob> job)
        {
            // Create a new stoped timer
            timer = new Timer(async state => await ExecuteSchedulerAsync(), null, Timeout.Infinite, Timeout.Infinite); ;
            jobs = job;
        }

        public Task StartAsync()
        {
            throw new NotImplementedException();
        }
        private Task ExecuteSchedulerAsync()
        {
            // TODO: Find and run all Jobs that should run
            // TODO: Change the timer to call us again when it's time to run the next job
            throw new NotImplementedException();
        }

        public Task StopAsync()
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    timer.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
