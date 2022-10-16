using NServiceBus;

class Program
{
    static void Main()
    {
        AsyncMain().GetAwaiter().GetResult();
    }

    static async Task AsyncMain()
    {
        Console.WriteLine("Sales");
        var endpointConfiguration = new EndpointConfiguration("Sales");
        var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
        transport.ConnectionString("host=localhost");
        transport.UseConventionalRoutingTopology(QueueType.Quorum);
        var endpointInstance = await Endpoint.Start(endpointConfiguration)
            .ConfigureAwait(false);
        
        Console.ReadLine();

        await endpointInstance.Stop()
            .ConfigureAwait(false);
    }
}