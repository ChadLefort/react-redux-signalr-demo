namespace ReactReduxSignalRDemo.Models
{
    public class KillFeedItem
    {
        public int KillFeedItemId { get; set; }
        public int KillFeedId { get; set; }
        public KillUser Kill { get; set; }
        public DeathUser Death { get; set; }
    }
}
