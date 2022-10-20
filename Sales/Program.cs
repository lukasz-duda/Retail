using Microsoft.Extensions.Hosting;
using NServiceBus;

Console.Title = "Sales";

var builder = Host.CreateDefaultBuilder(args)
    .UseConsoleLifetime()
    .UseNServiceBus(context =>
    {
        var endpointConfiguration = new EndpointConfiguration("Sales");
        endpointConfiguration.EnableInstallers();
        var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
        var connectionString = context.Configuration.GetSection("ConnectionStrings:MessageBus").Value;
        transport.ConnectionString(connectionString);
        transport.UseConventionalRoutingTopology(QueueType.Quorum);
        return endpointConfiguration;
    });

var app = builder.Build();
app.Run();