using System.Threading.Tasks;
using BridgeApp.Context;
using Microsoft.AspNetCore.SignalR;

namespace BridgeApp.Hubs
{
    public class TableHub : Hub<ITableHost>, ITableHost
    {
        public async Task SendPlayerJoined(string username)
        {
            await Clients.Others.SendPlayerJoined(username);
        }
    }
}