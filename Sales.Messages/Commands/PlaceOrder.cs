using NServiceBus;

namespace Sales.Messages.Commands
{
    public class PlaceOrder : ICommand
    {
        public string? OrderId { get; set; }
    }
}