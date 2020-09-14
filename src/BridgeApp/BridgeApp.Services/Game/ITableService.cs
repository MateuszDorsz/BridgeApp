using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BridgeApp.Model;

namespace BridgeApp.Services.Game
{
    public interface ITableService
    {
        Task<int> CreateNew();

        Task DeleteInactive();

        Task<IEnumerable<Table>> GetTables();

        Task<Table> GetTable(int id);
    }
}