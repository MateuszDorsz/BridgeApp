using System.Collections.Generic;
using System.Threading.Tasks;
using BridgeApp.Conts;
using BridgeApp.Services.Game;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BridgeApp.Pages
{
    public class LobbyBase : ComponentBase
    {
        private HubConnection _connection;

        [Inject] 
        public ITableService TableService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }


        public IEnumerable<Model.Table> Tables { get; set; }


        protected override async Task OnInitializedAsync()
        {
            _connection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri(Url.LobbyHub), options =>
            {
                //ToDo - add options
            }).Build();
            _connection.On(LobbyMessage.TablesUpdated, StateHasChanged);
            Tables = await TableService.GetTables();
            await _connection.StartAsync();
            await base.OnInitializedAsync();
        }

        public async Task AddNewTable()
        {
            await TableService.CreateNew();
            await _connection.SendAsync(LobbyMessage.TablesUpdated);
        }
    }
}
