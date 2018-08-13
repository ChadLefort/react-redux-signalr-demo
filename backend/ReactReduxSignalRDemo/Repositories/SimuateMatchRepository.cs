using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReactReduxSignalRDemo.Interfaces;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Repositories
{
    public class SimuateMatchRepository : ISimuateMatchRepository
    {
        private readonly R6StatsContext _context;
        private readonly IConfiguration _configuration;
        public SimuateMatchRepository(R6StatsContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Stats GetStats(int userId)
        {
            return _context.Stats.Find(userId);
        }

        public void UpdateStats(Stats stats)
        {
            var optionsBuilder = new DbContextOptionsBuilder<R6StatsContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ReactReduxSignalRDemoDatabase"));

            using (var context = new R6StatsContext(optionsBuilder.Options))
            {
                context.Stats.Update(stats);
                context.SaveChanges();
            }
        }
    }
}
