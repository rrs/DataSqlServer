using Microsoft.Data.SqlClient;

namespace Rrs.Data.SqlServer
{
    public class SqlServerConnectionProperties : IConnectionProperties
    {
        private SqlConnectionStringBuilder _builder;

        public string Server { get; }
        public string Database { get; }
        public string Username { get; }

        public bool MultipleActiveResultSets
        { 
            get => _builder.MultipleActiveResultSets;
            set => _builder.MultipleActiveResultSets = value;
        }

        public bool IntegratedSecurity
        {
            get => _builder.IntegratedSecurity;
            set => _builder.IntegratedSecurity = value;
        }

        public SqlAuthenticationMethod Authentication
        {
            get => _builder.Authentication;
            set => _builder.Authentication = value;
        }

        public SqlServerConnectionProperties(string server, string database, string username = null, string password = null, bool trustServerCertificate = true)
        {
            _builder = new SqlConnectionStringBuilder
            {
                DataSource = server,
                InitialCatalog = database,
                TrustServerCertificate = trustServerCertificate,
                Authentication = username == null && password == null ? SqlAuthenticationMethod.ActiveDirectoryDefault : SqlAuthenticationMethod.NotSpecified
            };

            if (username != null) _builder.UserID = username;
            if (password != null) _builder.Password = password;
        }

        public SqlServerConnectionProperties(SqlConnectionStringBuilder builder) => _builder = builder;

        public SqlServerConnectionProperties(string connectionString) => _builder = new SqlConnectionStringBuilder(connectionString);

        public string ConnectionString => _builder.ConnectionString;
    }
}
