using System.Collections.Generic;
using System.Threading.Tasks;
using BridgeApp.Context;
using BridgeApp.Conts;
using BridgeApp.Services.Game;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR.Client;

namespace BridgeApp.Pages.Table
{
    public class TableViewBase : ComponentBase
    {
        private HubConnection _connection;

        [Inject]
        public ITableService TableService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        [Inject]
        protected IHttpContextAccessor ContextAccessor { get; set; }
        

        [Parameter]
        public string TableId { get; set; }

        public Model.Table Table { get; set; }

        public IList<string> ChatMessages { get; private set; }


        protected override async Task OnInitializedAsync()
        {
            _connection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri(string.Format(Url.TableHub + TableId)), options =>
            {
                //ToDo - add options
            }).Build();
            Table = await TableService.GetTable(int.Parse(TableId));
            ChatMessages = new List<string>();
            
            _connection.On<string>(nameof(ITableHost.SendPlayerJoined), async (message) =>
            {
                ChatMessages.Add(message);
                StateHasChanged();
            });
            string username = string.IsNullOrEmpty(ContextAccessor.HttpContext.User.Identity.Name)
                ? "unknown"
                : ContextAccessor.HttpContext.User.Identity.Name;
            await _connection.StartAsync();
            var joinedMessage = "system: New player joined: " + username;
            await _connection.SendAsync(nameof(ITableHost.SendPlayerJoined), joinedMessage);
            
            await base.OnInitializedAsync();
            await _connection.SendAsync(TableMessage.PlayerJoined);
        }
    }
}
