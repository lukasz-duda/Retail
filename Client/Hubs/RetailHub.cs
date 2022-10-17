using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Client.Hubs
{
    public class RetailHub : Hub
    {
        public async Task PlaceOrder(string message)
        {
            await Clients.Caller.SendAsync("OrderPlaced", $"{message} received");
        }
    }
}