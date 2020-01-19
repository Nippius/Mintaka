using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mintaka.Core;

namespace HelloMintaka.Jobs
{
    public class HelloWorldJob : Job
    {
        private readonly IServiceProvider serviceProvider;
        private readonly TimeSpan nextExecution = TimeSpan.FromSeconds(5);

        public HelloWorldJob(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public override TimeSpan NextExecution => nextExecution;

        public override void DoJob(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();

            var logger = scope.ServiceProvider.GetRequiredService<ILogger>();

            logger.LogInformation($"Hello from Mintaka! Current UTC time: {DateTime.Now}");
        }
    }
}
