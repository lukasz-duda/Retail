using NServiceBus;

namespace Sales.Messages.Events
{
    public class OrderPlaced : IEvent
    {
        public string? OrderId { get; set; }
    }
}
