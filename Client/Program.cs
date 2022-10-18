using Client.Hubs;
using NServiceBus;
using Sales.Messages.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Host.UseNServiceBus(context =>
{
    var endpointConfiguration = new EndpointConfiguration("Client");
    endpointConfiguration.EnableInstallers();
    var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
    transport.ConnectionString("host=localhost");
    transport.UseConventionalRoutingTopology(QueueType.Quorum);
    transport.Routing().RouteToEndpoint(typeof(PlaceOrder), "Sales");
    return endpointConfiguration;
});

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<RetailHub>("/retailhub");

app.Run();
