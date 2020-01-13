using System.Threading.Tasks;

namespace Mintaka.Core
{
    public interface IMintakaScheduler
    {
        Task StartAsync();

        Task StopAsync();
    }
}
