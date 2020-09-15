using System.Collections.Generic;
using System.Threading.Tasks;

namespace BridgeApp.Model
{
    public interface ITableChat
    {
        Task Send(string message, string sender);

        Task<IEnumerable<string>> GetChatHistory();
    }
}