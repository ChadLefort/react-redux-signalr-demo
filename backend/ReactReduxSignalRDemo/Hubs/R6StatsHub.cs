using System;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ReactReduxSignalRDemo.Interfaces;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Hubs
{
    public class R6StatsHub : Hub
    {
        private readonly ISimuateMatchService _simuateMatch;
        private readonly ILogger _logger;

        public R6StatsHub(ISimuateMatchService simuateMatch, ILogger<R6StatsHub> logger)
        {
            _simuateMatch = simuateMatch;
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation($"{Context.ConnectionId} has connected to SignalR Hub.");
            UserHandler.UserList.Add(new SignalRUser {ConnectionId = Context.ConnectionId});

            await Clients.All.SendAsync("OnConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _simuateMatch.StopMatch();
            _logger.LogInformation($"{Context.ConnectionId} has disconnected from SignalR Hub.");
            UserHandler.UserList.RemoveAll(x => x.ConnectionId == Context.ConnectionId);

            await Clients.All.SendAsync("OnDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public Task StartFetchMatch(int userId, int matchId)
        {
            var simulatedMatchAlready = UserHandler.UserList.FirstOrDefault(x => x.SearchedUserId == userId);

            if (simulatedMatchAlready == null)
            {
                _simuateMatch.StartMatch(userId, matchId);

                var connectedUser = UserHandler.UserList.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);

                if (connectedUser != null)
                {
                    connectedUser.SearchedUserId = userId;
                }
            }

            return Clients.All.SendAsync("StartFetchMatch");
        }
    }
}