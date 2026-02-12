using Microsoft.AspNetCore.SignalR;

namespace FManagement.RazorWepApp.QuangND.Hubs
{
    public class ProductionPlanHub : Hub
    {
        public async Task NotifyProductionPlanDeleted(int planId)
        {
            await Clients.All.SendAsync("ProductionPlanDeleted", planId);
        }

        public async Task NotifyProductionPlanUpdated()
        {
            await Clients.All.SendAsync("ProductionPlanUpdated");
        }
    }
}
