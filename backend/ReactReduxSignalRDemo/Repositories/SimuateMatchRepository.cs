using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReactReduxSignalRDemo.Interfaces;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Repositories
{
    public class SimuateMatchRepository : ISimuateMatchRepository
    {
        private readonly UsersContext _usersContext;
        private readonly KillFeedsContext _killFeedsContext;
        private readonly IConfiguration _configuration;
        public SimuateMatchRepository(UsersContext usersContext, KillFeedsContext killFeedsContext, IConfiguration configuration)
        {
            _usersContext = usersContext;
            _killFeedsContext = killFeedsContext;
            _configuration = configuration;
        }

        public User GetUser(int userId)
        {
            return _usersContext.Users.Where(x => x.UserId == userId).Include(x => x.Stats).FirstOrDefault();
        }

        public KillFeed GetKillFeed(int userId, int matchId)
        {
            return _killFeedsContext.KillFeeds.Where(x => x.UserId == userId && x.MatchId == matchId)
                .Include(x => x.KillFeedItems)
                .ThenInclude(x => x.Kill)
                .Include(x => x.KillFeedItems)
                .ThenInclude(x => x.Death)
                .FirstOrDefault();
        }

        public void UpdateStats(Stats stats)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UsersContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ReactReduxSignalRDemoDatabase"));

            using (var context = new UsersContext(optionsBuilder.Options))
            {
                context.Stats.Update(stats);
                context.SaveChanges();
            }
        }

        public void AddKillFeedItem(KillFeedItem killFeedItem)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KillFeedsContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ReactReduxSignalRDemoDatabase"));

            using (var context = new KillFeedsContext(optionsBuilder.Options))
            {
                context.KillFeedItems.Add(killFeedItem);
                context.SaveChanges();
            }
        }
    }
}
