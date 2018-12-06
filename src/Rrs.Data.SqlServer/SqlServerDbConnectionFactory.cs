using System.Data;
using System.Data.SqlClient;

namespace Rrs.Data.SqlServer
{
    public class SqlServerDbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqlServerDbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlServerDbConnectionFactory(IConnectionProperties connectionPropeties)
        {
            _connectionString = connectionPropeties.ConnectionString;
        }

        public SqlServerDbConnectionFactory(string server, string database, string username = null, string password = null)
        {
            var connectionPropeties = new SqlServerDbConnectionProperties(server, database, username, password);
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
