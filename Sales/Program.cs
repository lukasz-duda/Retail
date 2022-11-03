using System.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using NServiceBus;

Console.Title = "Sales";

var builder = Host.CreateDefaultBuilder(args)
    .UseConsoleLifetime()
    .UseNServiceBus(context =>
    {
        var endpointConfiguration = new EndpointConfiguration("Sales");

        var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
        var connectionString = context.Configuration.GetSection("ConnectionStrings:MessageBus").Value;
        transport.ConnectionString(connectionString);
        transport.UseConventionalRoutingTopology(QueueType.Quorum);

        var databaseConnectionString = context.Configuration.GetSection("ConnectionStrings:Database").Value;
        var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
        persistence.SqlDialect<SqlDialect.MsSqlServer>();
        persistence.ConnectionBuilder(() => new SqlConnection(databaseConnectionString));

        endpointConfiguration.EnableInstallers();
        endpointConfiguration.EnableOutbox();

        return endpointConfiguration;
    });

var app = builder.Build();
app.Run();