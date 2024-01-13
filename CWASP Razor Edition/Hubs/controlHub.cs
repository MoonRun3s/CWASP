using Microsoft.AspNetCore.SignalR;

namespace CWASP_Razor_Edition.Hubs
{
    public class ControlHub : Hub
    {
        public async Task AllCall()
        {
            await Clients.All.SendAsync("UpdatePartialView");
        }
    }
}
