using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Interfaces
{
    public interface ISimuateMatchRepository
    {
        User GetUser(int userId);
        KillFeed GetKillFeed(int userId, int matchId);
        void UpdateStats(Stats stats);
        void AddKillFeedItem(KillFeedItem killFeedItem);
    }
}
