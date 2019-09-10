using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Rrs.Data.SqlServer
{
    public partial class SqlServerConnectionFactory : IDbConnectionFactory
    {
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
