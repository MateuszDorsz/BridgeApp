using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BridgeApp.Conts;

namespace BridgeApp.Context
{
    public interface ITableHost
    {
        Task SendPlayerJoined(string message);

        Task SendPlayerDisconnected(string username);
    }
}
