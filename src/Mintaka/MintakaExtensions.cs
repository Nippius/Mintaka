using Microsoft.Extensions.DependencyInjection;
using Mintaka.Core;

namespace Mintaka
{
    public static class MintakaExtensions
    {
        /// <summary>
        /// Registers the Mintaka scheduler as background service
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddMintaka(this IServiceCollection services)
        {
            services.AddSingleton<IMintakaScheduler, MintakaScheduler>();
            services.AddHostedService<MintakaSchedulerBackgroundService>();
            
            return services;
        }
    }
}
