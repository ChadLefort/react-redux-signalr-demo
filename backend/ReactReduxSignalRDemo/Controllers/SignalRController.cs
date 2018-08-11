using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Controllers
{
    public class R6StatsSignalR : Hub
    {
        private readonly R6StatsContext _context;
        private static IConfiguration _configuration;
        private static Timer _killDeathTimer;
        private static Timer _winLossTimer;

        public R6StatsSignalR(R6StatsContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public override async Task OnConnectedAsync()
        {
            UserHandler.UserList.Add(new SignalRUser { ConnectionId = Context.ConnectionId });

            await Clients.All.SendAsync("OnConnected", Context.ConnectionId);
            await base.OnConnectedAsync(); 
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _killDeathTimer.Dispose();
            _winLossTimer.Dispose();
            UserHandler.UserList.RemoveAll(x => x.ConnectionId == Context.ConnectionId);

            await Clients.All.SendAsync("OnDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public Task StartFetchMatch(int userId)
        {
            var simulatedMatchAlready = UserHandler.UserList.FirstOrDefault(x => x.SearchedUserId == userId);

            if (simulatedMatchAlready == null)
            {
                SimulateMatch(userId);

                var connectedUser = UserHandler.UserList.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);

                if (connectedUser != null)
                {
                    connectedUser.SearchedUserId = userId;
                }
            }

            return Clients.All.SendAsync("StartFetchMatch");
        }

        private void SimulateMatch(int userId)
        {
            var stats = _context.Stats.Find(userId);

            if (stats != null)
            {
                var timerState = new TimerState { Stats = stats, Clients = Clients };
                _killDeathTimer = new Timer(KillDeathTimerTask, timerState, 0, 10000);
                _winLossTimer = new Timer(WinLossTimerTask, timerState, 0, 30000);
            }
           
        }

        private static void KillDeathTimerTask(object timerState)
        {
            if (timerState is TimerState state)
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

                var optionsBuilder = new DbContextOptionsBuilder<R6StatsContext>();
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ReactReduxSignalRDemoDatabase"));

                using (var context = new R6StatsContext(optionsBuilder.Options))
                {
                    context.Stats.Update(state.Stats);
                    context.SaveChanges();
                }

                state.Clients.All.SendAsync("GetLiveStats", state.Stats);
            }
        }

        private static void WinLossTimerTask(object timerState)
        {
            if (timerState is TimerState state)
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

                var optionsBuilder = new DbContextOptionsBuilder<R6StatsContext>();
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ReactReduxSignalRDemoDatabase"));

                using (var context = new R6StatsContext(optionsBuilder.Options))
                {
                    context.Stats.Update(state.Stats);
                    context.SaveChanges();
                }

                state.Clients.All.SendAsync("GetLiveStats", state.Stats);
            }
        }
    }

    public static class UserHandler
    {
        public static List<SignalRUser> UserList = new List<SignalRUser>();
    }

    public class SignalRUser
    {
        public string ConnectionId { get; set; }
        public int? SearchedUserId { get; set; }
    }

    public class TimerState
    {
        public Stats Stats;
        public IHubCallerClients Clients;
    }
}