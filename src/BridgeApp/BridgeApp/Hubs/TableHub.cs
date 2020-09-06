using System;
using System.Threading.Tasks;
using BridgeApp.Conts;
using Microsoft.AspNetCore.SignalR;

namespace BridgeApp.Hubs
{
    public class TableHub : Hub
    {
        public async Task PlayerJoined()
        {
            await Clients.All.SendAsync(TableMessage.PlayerJoined);
        }

        public async Task PlayerDisconectedTask()
        {
            await Clients.Others.SendAsync(TableMessage.PlayerLeft);
        }

        public override Task OnConnectedAsync()
        {
            
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}