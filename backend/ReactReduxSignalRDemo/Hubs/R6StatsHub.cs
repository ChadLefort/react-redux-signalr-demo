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
        private readonly ISimulateMatchService _simulateMatch;
        private readonly ILogger _logger;

        public R6StatsHub(ISimulateMatchService simulateMatch, ILogger<R6StatsHub> logger)
        {
            _simulateMatch = simulateMatch;
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation($"{Context.ConnectionId} has connected to SignalR Hub.");
            UserHandler.UserList.Add(new SignalRUser { ConnectionId = Context.ConnectionId });

            await Clients.All.SendAsync("OnConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _simulateMatch.StopMatch();
            _logger.LogInformation($"{Context.ConnectionId} has disconnected from SignalR Hub.");
            UserHandler.UserList.RemoveAll(x => x.ConnectionId == Context.ConnectionId);

            await Clients.All.SendAsync("OnDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public Task StartFetchMatch(int userId, int matchId)
        {
            _logger.LogInformation($"Attempting to simulate match for user {userId} and match {matchId}.");

            var simulatedMatchAlready = UserHandler.UserList.FirstOrDefault(x => x.SearchedUserId == userId);

            if (simulatedMatchAlready == null)
            {
                _simulateMatch.StartMatch(userId, matchId);

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