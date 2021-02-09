using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Rrs.Data.SqlServer
{
    public class SqlServerConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;
        public IConnectionProperties ConnectionProperties { get; }

        public SqlServerConnectionFactory(string connectionString)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            ConnectionProperties = new SqlServerConnectionProperties(connectionStringBuilder.DataSource, connectionStringBuilder.InitialCatalog, connectionStringBuilder.UserID, connectionStringBuilder.Password);
            _connectionString = ConnectionProperties.ConnectionString;
        }

        public SqlServerConnectionFactory(IConnectionProperties connectionPropeties)
        {
            ConnectionProperties = connectionPropeties;
            _connectionString = ConnectionProperties.ConnectionString;
        }

        public SqlServerConnectionFactory(string server, string database, string username = null, string password = null)
        {
            var connectionPropeties = new SqlServerConnectionProperties(server, database, username, password);
            ConnectionProperties = connectionPropeties;
            _connectionString = ConnectionProperties.ConnectionString;
        }

        public IDbConnection NewConnection() => new SqlConnection(_connectionString);

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

        public async Task<IDbConnection> OpenConnectionAsync()
        {
            SqlConnection c = null;
            try
            {
                c = new SqlConnection(_connectionString);
                await c.OpenAsync();
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
