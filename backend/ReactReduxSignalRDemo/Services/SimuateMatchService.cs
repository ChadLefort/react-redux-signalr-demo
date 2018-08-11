using System;
using System.Threading;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReactReduxSignalRDemo.Hubs;
using ReactReduxSignalRDemo.Interfaces;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Services
{
    public class SimuateMatchService : ISimuateMatchService
    {
        private readonly R6StatsContext _context;
        private readonly IHubContext<R6StatsHub> _hubContext;
        private readonly IConfiguration _configuration;
        private static Timer _killDeathTimer;
        private static Timer _winLossTimer;

        public SimuateMatchService(R6StatsContext context, IHubContext<R6StatsHub> hubContext, IConfiguration configuration)
        {
            _context = context;
            _hubContext = hubContext;
            _configuration = configuration;
        }

        public void StartMatch(int userId)
        {
            var stats = _context.Stats.Find(userId);

            if (stats != null)
            {
                var timerState = new MatchTimerState { Stats = stats };
                _killDeathTimer = new Timer(KillDeathTimerTask, timerState, 0, 10000);
                _winLossTimer = new Timer(WinLossTimerTask, timerState, 0, 30000);
            }
        }

        public void StopMatch()
        {
            _killDeathTimer.Dispose();
            _winLossTimer.Dispose();
        }

        private void KillDeathTimerTask(object timerState)
        {
            if (timerState is MatchTimerState state)
            {
                var random = new Random();

                if (random.Next(0, 2) == 0)
                {
                    state.Stats.Kills++;
                }
                else
                {
                    state.Stats.Deaths++;
                }

                UpdateStats(state.Stats);
                _hubContext.Clients.All.SendAsync("GetLiveStats", state.Stats);
            }
        }

        private void WinLossTimerTask(object timerState)
        {
            if (timerState is MatchTimerState state)
            {
                var random = new Random();

                if (random.Next(0, 2) == 0)
                {
                    state.Stats.Wins++;
                }
                else
                {
                    state.Stats.Losses++;
                }

                UpdateStats(state.Stats);
                _hubContext.Clients.All.SendAsync("GetLiveStats", state.Stats);
            }
        }

        private void UpdateStats(Stats stats)
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
