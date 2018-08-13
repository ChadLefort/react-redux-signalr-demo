using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReactReduxSignalRDemo.Models
{
    public class R6KillFeedContext : DbContext
    {
        public R6KillFeedContext(DbContextOptions<R6KillFeedContext> options) : base(options) {}
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
                new KillUser { KillUserId = 1, KillFeedItemId = 1, Username = "chad", Operator = "Ash" },
                new KillUser { KillUserId = 2, KillFeedItemId = 2, Username = "Gully", Operator = "Mirror" }
            );
            modelBuilder.Entity<DeathUser>().HasData(
                new DeathUser { DeathUserId = 1, KillFeedItemId = 1, Username = "Gully", Operator = "Mirror" },
                new DeathUser { DeathUserId = 2, KillFeedItemId = 2, Username = "chad", Operator = "Ash" }
            );
        }
    }

    public class KillFeed
    {
        public int KillFeedId { get; set; }
        public int MatchId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<KillFeedItem> KillFeedItems{ get; set; }
    }
}
