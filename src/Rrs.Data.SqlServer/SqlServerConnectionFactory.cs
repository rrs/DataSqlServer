using System.Data;
using System.Data.SqlClient;

namespace Rrs.Data.SqlServer
{
    public class SqlServerConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqlServerConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlServerConnectionFactory(IConnectionProperties connectionPropeties)
        {
            _connectionString = connectionPropeties.ConnectionString;
        }

        public SqlServerConnectionFactory(string server, string database, string username = null, string password = null)
        {
            var connectionPropeties = new SqlServerConnectionProperties(server, database, username, password);
            _connectionString = connectionPropeties.ConnectionString;
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
