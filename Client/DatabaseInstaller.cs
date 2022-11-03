using System.Data.SqlClient;
using NServiceBus.Installation;

namespace Client
{
    public class DatabaseInstaller : INeedToInstallSomething
    {
        private string connectionString;

        public DatabaseInstaller(IConfiguration configuration)
        {
            connectionString = configuration.GetSection("ConnectionStrings:Database").Value;
        }

        public Task Install(string identity)
        {
            CreateDatabase(connectionString);
            return Task.CompletedTask;
        }

        private static void CreateDatabase(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            var database = builder.InitialCatalog;

            var masterConnection = connectionString.Replace(builder.InitialCatalog, "master");

            using (var connection = new SqlConnection(masterConnection))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
IF DB_ID('{database}') IS NULL
    CREATE DATABASE {database}";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}