using Microsoft.EntityFrameworkCore;

namespace ReactReduxSignalRDemo.Models
{
    public class CounterContext : DbContext
    {
        public CounterContext(DbContextOptions options) : base(options) {}

        public DbSet<Counter> Counter { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Counter>().HasData(new Counter {Id = 1, Count = 0});
        }
    }

    public class Counter
    {
        public int Id { get; set; }
        public int Count { get; set; }
    }

    public class CounterResult
    {
        public int Count { get; set; }
    }
}


