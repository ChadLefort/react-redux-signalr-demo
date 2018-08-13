using Microsoft.EntityFrameworkCore;

namespace ReactReduxSignalRDemo.Models
{

    public class R6StatsContext : DbContext
    {
        public R6StatsContext(DbContextOptions<R6StatsContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Stats> Stats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { UserId = 1, Username = "chad" }, new User { UserId = 2, Username = "pat" });
            modelBuilder.Entity<Stats>().HasData(new Stats
            {
                StatsId = 1,
                UserId = 1,
                Kills = 850,
                Deaths = 640,
                Wins = 131,
                Losses = 124
            }, new Stats
            {
                StatsId = 2,
                UserId = 2,
                Kills = 1086,
                Deaths = 265,
                Wins = 252,
                Losses = 58
            });
        }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public Stats Stats { get; set; }
    }
}
