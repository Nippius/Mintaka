using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mintaka.Core;
using NCrontab;

namespace HelloMintaka.Jobs
{
    public class HelloWorldJob : Job
    {
        private readonly CrontabSchedule crontabSchedule = CrontabSchedule.Parse("*/5 * * * * *", new CrontabSchedule.ParseOptions { IncludingSeconds = true });
        private readonly IServiceProvider serviceProvider;

        public HelloWorldJob(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public override DateTimeOffset NextExceutionTime => crontabSchedule.GetNextOccurrence(DateTime.UtcNow);

        public override void DoJob(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();

            var logger = scope.ServiceProvider.GetRequiredService<ILogger>();

            logger.LogInformation($"Hello from Mintaka! Current UTC time: {DateTime.UtcNow}");
        }
    }
}
