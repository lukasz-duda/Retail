using Microsoft.AspNetCore.SignalR;
using NServiceBus;
using Sales.Messages.Commands;

namespace Client.Hubs
{
    public class RetailHub : Hub
    {
        private readonly IMessageSession? messageSession;

        public RetailHub(IMessageSession? messageSession)
        {
            this.messageSession = messageSession;
        }

        public async Task PlaceOrder(string orderId)
        {
            await messageSession.Send(new PlaceOrder { OrderId = orderId })
                .ConfigureAwait(false);
        }
    }
}