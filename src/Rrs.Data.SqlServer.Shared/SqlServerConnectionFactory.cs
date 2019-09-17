using System.Data;
using System.Data.SqlClient;

namespace Rrs.Data.SqlServer
{
    public partial class SqlServerConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;
        public IConnectionProperties ConnectionProperties { get; }

        private SqlServerConnectionFactory()
        {
            _connectionString = ConnectionProperties.ConnectionString;
        }

        public SqlServerConnectionFactory(string connectionString) : this()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            ConnectionProperties = new SqlServerConnectionProperties(connectionStringBuilder.DataSource, connectionStringBuilder.InitialCatalog, connectionStringBuilder.UserID, connectionStringBuilder.Password);
        }

        public SqlServerConnectionFactory(IConnectionProperties connectionPropeties) : this()
        {
            ConnectionProperties = connectionPropeties;
        }

        public SqlServerConnectionFactory(string server, string database, string username = null, string password = null) : this()
        {
            var connectionPropeties = new SqlServerConnectionProperties(server, database, username, password);
            ConnectionProperties = connectionPropeties;
        }

        public IDbConnection OpenConnection()
        {
            SqlConnection c = null;
            try
            {
                c = new SqlConnection(_connectionString);
                c.Open();
            }
            catch
            {
                c?.Dispose();
                throw;
            }
            return c;
        }

    }
}
