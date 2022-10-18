using Client.Hubs;
using Microsoft.AspNetCore.SignalR;
using NServiceBus;
using Sales.Messages.Events;

namespace Client.Handlers
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {
        private readonly IHubContext<RetailHub> hubContext;

        public OrderPlacedHandler(IHubContext<RetailHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            hubContext.Clients.All.SendAsync("OrderPlaced", message.OrderId);
            return Task.CompletedTask;
        }
    }
}
