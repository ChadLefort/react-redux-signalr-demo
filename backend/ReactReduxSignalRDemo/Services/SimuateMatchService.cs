using System;
using System.Collections.Generic;
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

        public void StartMatch(int userId, int matchId)
        {
            _logger.LogInformation($"Start simulated match for user {userId}.");
            var user = _simuateMatchRepository.GetUser(userId);
            var killFeed = _simuateMatchRepository.GetKillFeed(userId, matchId);

            if (user != null && killFeed != null)
            {
                var timerState = new MatchTimerState { User = user, KillFeed = killFeed };
                _killDeathTimer = new Timer(KillDeathTimerTask, timerState, 0, 10000);
                _winLossTimer = new Timer(WinLossTimerTask, timerState, 0, 30000);
            }
        }

        public void StopMatch()
        {
            _logger.LogInformation("Stop simulated match.");
            _killDeathTimer.Dispose();
            _winLossTimer.Dispose();
        }

        private void KillDeathTimerTask(object timerState)
        {
            if (timerState is MatchTimerState state)
            {
                var user = new KillFeedPlayer { Username = state.User.Username, Operator = "Ash" };
                var enemies = new List<KillFeedPlayer>
                {
                    new KillFeedPlayer { Username = "Gully", Operator = "Mira" },
                    new KillFeedPlayer { Username = "ITServices", Operator = "Smoke" },
                    new KillFeedPlayer { Username = "JCrafter99", Operator = "Doc" },
                    new KillFeedPlayer { Username = "Refridge", Operator = "Vigil" },
                    new KillFeedPlayer { Username = "Parnasas", Operator = "Maestro" }
                };

                var random = new Random();
                var randomNumber = random.Next(0, 4);
                var killFeedItem = new KillFeedItem { KillFeedId = state.KillFeed.KillFeedId };

                if (random.Next(0, 2) == 0)
                {
                    state.User.Stats.Kills++;

                    killFeedItem.Kill = new KillUser
                    {
                        KillFeedItemId = killFeedItem.KillFeedItemId,
                        Username = user.Username,
                        Operator = user.Operator
                    };

                    killFeedItem.Death = new DeathUser
                    {
                        KillFeedItemId = killFeedItem.KillFeedItemId,
                        Username = enemies[randomNumber].Username,
                        Operator = enemies[randomNumber].Operator
                    };
                }
                else
                {
                    state.User.Stats.Deaths++;

                    killFeedItem.Kill = new KillUser
                    {
                        KillFeedItemId = killFeedItem.KillFeedItemId,
                        Username = enemies[randomNumber].Username,
                        Operator = enemies[randomNumber].Operator
                    };

                    killFeedItem.Death = new DeathUser
                    {
                        KillFeedItemId = killFeedItem.KillFeedItemId,
                        Username = user.Username,
                        Operator = user.Operator
                    };
                }

                _simuateMatchRepository.UpdateStats(state.User.Stats);
                _simuateMatchRepository.AddKillFeedItem(killFeedItem);
                _hubContext.Clients.All.SendAsync("GetLiveStats", state.User.Stats);
                _hubContext.Clients.All.SendAsync("GetKillFeedItem", killFeedItem);
            }
        }

        private void WinLossTimerTask(object timerState)
        {
            if (timerState is MatchTimerState state)
            {
                var random = new Random();

                if (random.Next(0, 2) == 0)
                {
                    state.User.Stats.Wins++;
                }
                else
                {
                    state.User.Stats.Losses++;
                }

                _simuateMatchRepository.UpdateStats(state.User.Stats);
                _hubContext.Clients.All.SendAsync("GetLiveStats", state.User.Stats);
            }
        }
    }
}
