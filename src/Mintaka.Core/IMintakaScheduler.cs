using System.Threading.Tasks;

namespace Mintaka.Core
{
    public interface IMintakaScheduler
    {
        void Start();

        void Stop();
    }
}
