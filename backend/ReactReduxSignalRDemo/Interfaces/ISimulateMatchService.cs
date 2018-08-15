namespace ReactReduxSignalRDemo.Interfaces
{
    public interface ISimulateMatchService
    {
        void StartMatch(int userId, int matchId);
        void StopMatch();
    }
}
