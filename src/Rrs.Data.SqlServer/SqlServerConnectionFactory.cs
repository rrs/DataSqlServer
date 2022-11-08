using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rrs.Data.SqlServer
{
    public class SqlServerConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;
        public IConnectionProperties ConnectionProperties { get; }

        public SqlServerConnectionFactory(string connectionString) : this(new SqlServerConnectionProperties(connectionString)) { }

        public SqlServerConnectionFactory(IConnectionProperties connectionPropeties)
        {
            ConnectionProperties = connectionPropeties;
            _connectionString = ConnectionProperties.ConnectionString;
        }

        public SqlServerConnectionFactory(string server, string database, string username = null, string password = null) : this(new SqlServerConnectionProperties(server, database, username, password)) { }

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

        public async Task<IDbConnection> OpenConnectionAsync(CancellationToken cancellationToken = default)
        {
            SqlConnection c = null;
            try
            {
                c = new SqlConnection(_connectionString);
                await c.OpenAsync(cancellationToken);
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
