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

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await scheduler.StartAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await scheduler.StopAsync();
        }
    }
}
