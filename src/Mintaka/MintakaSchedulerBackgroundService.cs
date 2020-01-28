using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Mintaka.Core;

namespace Mintaka
{
    class MintakaSchedulerBackgroundService : IHostedService
    {
        private readonly IMintakaScheduler scheduler;

        public MintakaSchedulerBackgroundService(IMintakaScheduler scheduler)
        {
            this.scheduler = scheduler;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            scheduler.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            scheduler.Stop();
            return Task.CompletedTask;
        }
    }
}
