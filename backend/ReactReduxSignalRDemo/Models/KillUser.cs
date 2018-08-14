using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactReduxSignalRDemo.Models
{
    public class KillUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KillUserId { get; set; }
        public int KillFeedItemId { get; set; } 
        public string Username { get; set; }
        public string Operator { get; set; }
    }
}
