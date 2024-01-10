using Microsoft.AspNetCore.SignalR;

namespace CWASP_Razor_Edition.Hubs
{
    public class IndexHub : Hub
    {
        public async Task UpdateDatabaseView()
        {
            // Like a repeater, tell all clients to update their database view.
            await Clients.All.SendAsync("UpdateDatabaseView");
        }
    }
}
