using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BridgeApp.Conts;
using BridgeApp.Services.Game;
using Microsoft.AspNetCore.Components;
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

        [Parameter]
        public string TableId { get; set; }

        public Model.Table Table { get; set; }

        public IEnumerable<string> ChatMessages { get; private set; }

        private async Task GetChatMessages()
        {
            ChatMessages = await Table.TableChat.GetChatHistory();
        }

        protected override async Task OnInitializedAsync()
        {
            _connection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri(string.Format(Url.TableHub + TableId)), options =>
            {
                //ToDo - add options
            }).Build();
            Table = await TableService.GetTable(int.Parse(TableId));
            ChatMessages = await Table.TableChat.GetChatHistory();
            _connection.On(TableMessage.PlayerJoined, async () =>
            {
                await GetChatMessages();
                StateHasChanged();
            });
            _connection.On(TableMessage.PlayerLeft, async () =>
            {
                await Table.TableChat.Send("Player left", "system");
                await GetChatMessages();
                StateHasChanged();
            });
            await _connection.StartAsync();
            await base.OnInitializedAsync();
            await Table.TableChat.Send("New player joined", "system");
            await _connection.SendAsync(TableMessage.PlayerJoined);
        }
    }
}
