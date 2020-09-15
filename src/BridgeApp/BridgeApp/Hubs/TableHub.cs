using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BridgeApp.Context;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BridgeApp.Hubs
{
    public class TableHub : Hub<ITableHost>, ITableHost
    {
        private readonly Dictionary<string, string> _connectedUsers;


        public TableHub()
        {
            _connectedUsers = new Dictionary<string, string>();
        }

        public async Task SendPlayerJoined(string username)
        {
            await Clients.Others.SendPlayerJoined(username);
        }

        public async Task SendPlayerDisconnected(string username)
        {
            await Clients.Others.SendPlayerDisconnected(username);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var id = Context.ConnectionId;
            if (_connectedUsers.TryGetValue(id, out var userName))
            {
                _connectedUsers.Remove(id);
                Clients.Others.SendPlayerDisconnected("Played disconnected: " + userName);
            }

            return base.OnDisconnectedAsync(exception);
        }

        public override Task OnConnectedAsync()
        {
            var userName = Context.User.Identity.Name;
            var id = Context.ConnectionId;
            _connectedUsers.Add(id, userName);
            return base.OnConnectedAsync();
        }
    }
}