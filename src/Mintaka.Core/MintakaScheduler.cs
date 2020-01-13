using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mintaka.Core
{
    public class MintakaScheduler : IMintakaScheduler
    {
        private readonly IEnumerable<IJob> jobs;
        private readonly CancellationToken cancellationToken;

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
            // TODO: Figure out how to do this using async/await. This is ugly..
            timer = new Timer(state => ExecuteSchedulerAsync().GetAwaiter().GetResult(), null, TimeSpan.MaxValue, TimeSpan.MaxValue); ;
            jobs = job;
        }

        public Task StartAsync()
        {
            return Task.CompletedTask;
        }
        private async Task ExecuteSchedulerAsync()
        {
            // TODO: Find and run all Jobs that should run
            // TODO: Change the timer to call us again when it's time to run the next job
        }

        public Task StopAsync()
        {
            throw new NotImplementedException();
        }
    }
}
