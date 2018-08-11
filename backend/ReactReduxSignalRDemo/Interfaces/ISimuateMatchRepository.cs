using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Interfaces
{
    public interface ISimuateMatchRepository
    {
        Stats GetStats(int userId);
        void UpdateStats(Stats stats);
    }
}
