using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mintaka.Core
{
    // TODO: Add support for cancelation tokens
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

        public MintakaScheduler(IEnumerable<IJob> jobs)
        {
            // Create a new stoped timer
            timer = new Timer(state => ExecuteScheduler(), null, Timeout.Infinite, Timeout.Infinite); ;
            this.jobs = jobs;
        }

        public void Start()
        {
            // TODO: Change this to find the first job to run and set the timer to run at that time
            timer.Change(0, 0);
        }
        private void ExecuteScheduler()
        {
            StopTimer();

            // TODO: Find and run all Jobs that should run
            // TODO: Change the timer to call us again when it's time to run the next job

            RescheduleAndRestartTimer(TimeSpan.Zero);
        }

        public void Stop()
        {
            StopTimer();
        }

        private void RescheduleAndRestartTimer(TimeSpan nextExecutionTime)
        {
            timer.Change(nextExecutionTime, Timeout.InfiniteTimeSpan);
        }

        private void StopTimer()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
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
