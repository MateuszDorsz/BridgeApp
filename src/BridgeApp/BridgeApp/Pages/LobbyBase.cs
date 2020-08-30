using System.Threading.Tasks;
using BridgeApp.Services.Game;
using Microsoft.AspNetCore.Components;

namespace BridgeApp.Pages
{
    public class LobbyBase : ComponentBase
    {
        [Inject] 
        public ITableService TableService { get; }



        protected override Task OnInitializedAsync()
        {

            return base.OnInitializedAsync();
        }
    }
}
