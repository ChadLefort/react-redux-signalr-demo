using System;
using System.Threading;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using ReactReduxSignalRDemo.Hubs;
using ReactReduxSignalRDemo.Interfaces;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Services
{
    public class SimuateMatchService : ISimuateMatchService
    {
        private readonly ISimuateMatchRepository _simuateMatchRepository;
        private readonly IHubContext<R6StatsHub> _hubContext;
        private static Timer _killDeathTimer;
        private static Timer _winLossTimer;
        private readonly ILogger _logger;

        public SimuateMatchService(ISimuateMatchRepository simuateMatchRepository, IHubContext<R6StatsHub> hubContext, ILogger<SimuateMatchService> logger)
        {
            _simuateMatchRepository = simuateMatchRepository;
            _hubContext = hubContext;
            _logger = logger;
        }

        public void StartMatch(int userId)
        {
            _logger.LogInformation($"Start simulated match for user {userId}.");
            var stats = _simuateMatchRepository.GetStats(userId);

            if (stats != null)
            {
                var timerState = new MatchTimerState { Stats = stats };
                _killDeathTimer = new Timer(KillDeathTimerTask, timerState, 0, 1000);
                _winLossTimer = new Timer(WinLossTimerTask, timerState, 0, 30000);
            }
        }

        public void StopMatch()
        {
            _logger.LogInformation($"Stop simulated match.");
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

                _simuateMatchRepository.UpdateStats(state.Stats);
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

                _simuateMatchRepository.UpdateStats(state.Stats);
                _hubContext.Clients.All.SendAsync("GetLiveStats", state.Stats);
            }
        }
    }
}
