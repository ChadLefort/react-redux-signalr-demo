using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReactReduxSignalRDemo.Models
{
    public class KillFeedsContext : DbContext
    {
        public KillFeedsContext(DbContextOptions<KillFeedsContext> options) : base(options) {}
        public DbSet<KillFeed> KillFeeds { get; set; }
        public DbSet<KillFeedItem> KillFeedItems { get; set; }
        public DbSet<KillUser> KillUsers { get; set; }
        public DbSet<DeathUser> DeathUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KillFeed>().HasData(new KillFeed {KillFeedId = 1, MatchId = 1, UserId = 1});
            modelBuilder.Entity<KillFeedItem>().HasData(
                new KillFeedItem {KillFeedItemId = 1, KillFeedId = 1 },
                new KillFeedItem { KillFeedItemId = 2, KillFeedId = 1 }
            );
            modelBuilder.Entity<KillUser>().HasData(
                new KillUser { KillUserId = 1, KillFeedItemId = 1, Username = "Chad", Operator = "Ash" },
                new KillUser { KillUserId = 2, KillFeedItemId = 2, Username = "Gully", Operator = "Mira" }
            );
            modelBuilder.Entity<DeathUser>().HasData(
                new DeathUser { DeathUserId = 1, KillFeedItemId = 1, Username = "Gully", Operator = "Mira" },
                new DeathUser { DeathUserId = 2, KillFeedItemId = 2, Username = "Chad", Operator = "Ash" }
            );
        }
    }

    public class KillFeed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KillFeedId { get; set; }
        public int MatchId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<KillFeedItem> KillFeedItems{ get; set; }
    }
}
