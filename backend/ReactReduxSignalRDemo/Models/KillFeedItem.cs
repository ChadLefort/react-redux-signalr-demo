using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactReduxSignalRDemo.Models
{
    public class KillFeedItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KillFeedItemId { get; set; }
        public int KillFeedId { get; set; }
        public KillUser Kill { get; set; }
        public DeathUser Death { get; set; }
    }
}
