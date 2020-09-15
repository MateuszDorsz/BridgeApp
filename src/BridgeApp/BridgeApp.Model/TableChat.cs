using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BridgeApp.Model
{
    public class TableChat : ITableChat
    { 
        private ReaderWriterLockSlim _lock;
        private List<string> _messages;

        public TableChat()
        {
            _lock = new ReaderWriterLockSlim();
            _messages = new List<string>(100);
        }

        public Task Send(string message, string sender)
        {
            return Task.Run(() =>
            {
                try
                {
                    _lock.EnterWriteLock();
                    if (_messages.Count > 98)
                    {
                        _messages.Remove(_messages.Last());
                    }
                    _messages.Add(sender + ": " + message);
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            });
        }

        public Task<IEnumerable<string>> GetChatHistory()
        {
            IEnumerable<string> result;
            try
            {
                _lock.EnterReadLock();
                result = _messages.ToList();
            }
            finally
            {
                _lock.ExitReadLock();
            }
            return Task.FromResult(result);
        }
    }
}