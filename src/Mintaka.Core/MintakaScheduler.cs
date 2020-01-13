using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mintaka.Core
{
    public class MintakaScheduler : IMintakaScheduler
    {
        private readonly IEnumerable<IJob> jobs;
        // Used to create scopes if a Job is marked as scoped
        private readonly IServiceProvider serviceProvider;

        /*
         * This timer is responsible for running the ExecuteScheduler() method in a loop.
         * The way this works (and in order to avoid wasting CPU cycles) is that we find
         * when the next job needs to run, set this timer to run our code at that time and 
         * go to sleep until then.
         */
        Timer timer;

        public MintakaScheduler(IEnumerable<IJob> jobs, IServiceProvider serviceProvider)
        {
            // Create a new stoped timer
            this.timer = new Timer(state => ExecuteScheduler(), null, TimeSpan.MaxValue, TimeSpan.MaxValue);
            this.jobs = jobs;
            this.serviceProvider = serviceProvider;
        }

        public Task StartAsync()
        {
            return Task.CompletedTask;
        }
        private void ExecuteScheduler()
        {
            // TODO: Run all Jobs that should run
            // TODO: Change the timer to call us again when it's time to run the next job
        }

        public Task StopAsync()
        {
            throw new NotImplementedException();
        }
    }
}
