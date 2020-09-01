using System.Threading.Tasks;
using BridgeApp.Conts;
using Microsoft.AspNetCore.SignalR;

namespace BridgeApp.Hubs
{
    public class LobbyHub : Hub
    {
        public async Task TablesUpdated()
        {
            await Clients.All.SendAsync(LobbyMessage.TablesUpdated);
        }
    }
}
