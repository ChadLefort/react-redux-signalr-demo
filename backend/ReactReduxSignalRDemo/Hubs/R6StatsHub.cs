using System;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ReactReduxSignalRDemo.Interfaces;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Hubs
{
    public class R6StatsHub : Hub
    {
        private readonly ISimuateMatchService _simuateMatch;

        public R6StatsHub(ISimuateMatchService simuateMatch)
        {
            _simuateMatch = simuateMatch;
        }

        public override async Task OnConnectedAsync()
        {
            UserHandler.UserList.Add(new SignalRUser {ConnectionId = Context.ConnectionId});

            await Clients.All.SendAsync("OnConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _simuateMatch.StopMatch();
            UserHandler.UserList.RemoveAll(x => x.ConnectionId == Context.ConnectionId);

            await Clients.All.SendAsync("OnDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public Task StartFetchMatch(int userId)
        {
            var simulatedMatchAlready = UserHandler.UserList.FirstOrDefault(x => x.SearchedUserId == userId);

            if (simulatedMatchAlready == null)
            {
                _simuateMatch.StartMatch(userId);

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