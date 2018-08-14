using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactReduxSignalRDemo.Models
{
    public class DeathUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeathUserId { get; set; }
        public int KillFeedItemId { get; set; }
        public string Username { get; set; }
        public string Operator { get; set; }
    }
}
