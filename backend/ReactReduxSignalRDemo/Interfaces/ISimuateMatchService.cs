namespace ReactReduxSignalRDemo.Interfaces
{
    public interface ISimuateMatchService
    {
        void StartMatch(int userId, int matchId);
        void StopMatch();
    }
}
