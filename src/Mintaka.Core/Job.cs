using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mintaka.Core
{
    abstract class Job : IJob
    {
        private readonly IServiceProvider serviceProvider;

        public ISchedule Schedule { get; }

        public Job(
            ISchedule schedule,
            IServiceProvider serviceProvider)
        {
            this.Schedule = schedule;
            this.serviceProvider = serviceProvider;
        }


        /*
         * Alterar a class Job para implementar um metodo RunAsync() 
         * que chama o DoJobAsync() e no fim, actualiza o schedule para 
         * apontar para a data da proxima execução
         * a interface ISchedule podia ter um método chamado UpdateNextRun() 
         * por exemplo que o RunAsync() iria chamar
         */
        public abstract Task DoJobAsync(CancellationToken cancellationToken);
    }
}
