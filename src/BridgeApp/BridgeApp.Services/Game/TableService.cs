using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BridgeApp.Model;

namespace BridgeApp.Services.Game
{
    public class TableService : ITableService
    {
        private readonly List<Table> _tables;
        private readonly ReaderWriterLockSlim _lock;

        public TableService()
        {
            _tables = new List<Table>(100);
            _lock = new ReaderWriterLockSlim();
        }

        public async Task<int> CreateNew()
        {
            _lock.EnterWriteLock();
            try
            {
                var table = new Table(_tables.Count + 1);
                _tables.Add(table);
                return await Task.FromResult(table.Id);
            }
            finally
            {
                _lock.ExitWriteLock();
            }

        }

        public async Task DeleteInactive()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Table>> GetTables()
        {
            _lock.EnterReadLock();
            try
            {
                return await Task.FromResult(_tables);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public async Task<Table> GetTable(int id)
        {
            _lock.EnterReadLock();
            try
            {
                return await Task.FromResult(_tables.First(t => t.Id == id));
            }
            finally
            {
                _lock.ExitReadLock();
            }        
        }
    }
}