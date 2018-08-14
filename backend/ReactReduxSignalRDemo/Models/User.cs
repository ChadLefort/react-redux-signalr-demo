using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReactReduxSignalRDemo.Models
{

    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Stats> Stats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { UserId = 1, Username = "Chad" });
            modelBuilder.Entity<Stats>().HasData(new Stats
            {
                StatsId = 1,
                UserId = 1,
                Kills = 1462,
                Deaths = 640,
                Wins = 384,
                Losses = 124,
                Rank = "Gold One",
                TopAttacker = "Twitch",
                TopDefender = "Lesion"
            });
        }
    }

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Username { get; set; }
        public Stats Stats { get; set; }
    }
}
