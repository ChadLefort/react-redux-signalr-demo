namespace ReactReduxSignalRDemo.Interfaces
{
    public interface ISimuateMatchService
    {
        void StartMatch(int userId);
        void StopMatch();
    }
}
