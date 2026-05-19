using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Core_V1_NET8.Data.Database
{
    public static class DbConnectionFactory
    {
        private const string ConnectionStringName = "CoreV1Db";

        public static SqlConnection CreateConnection()
        {
            string? connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    $"No se encontró la cadena de conexión '{ConnectionStringName}' en App.config.");
            }

            return new SqlConnection(connectionString);
        }
    }
}
