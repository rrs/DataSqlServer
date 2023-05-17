using Microsoft.Data.SqlClient;

namespace Rrs.Data.SqlServer
{
    public class SqlServerConnectionProperties : IConnectionProperties
    {
        private readonly SqlConnectionStringBuilder _builder;

        public string Server => _builder.DataSource;
        public string Database => _builder.InitialCatalog;
        public string Username => _builder.UserID;

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

        public SqlServerConnectionProperties(string server, string database, string username = null, string password = null, bool trustServerCertificate = true, string language = null, string applicationName = null)
        {
            _builder = new SqlConnectionStringBuilder
            {
                DataSource = server,
                InitialCatalog = database,
                TrustServerCertificate = trustServerCertificate,
                Authentication = username == null && password == null ? SqlAuthenticationMethod.ActiveDirectoryDefault : SqlAuthenticationMethod.NotSpecified,
                UserID = username,
                Password = password,
                CurrentLanguage = language,
                ApplicationName = applicationName
            };
        }

        public SqlServerConnectionProperties(SqlConnectionStringBuilder builder) => _builder = builder;

        public SqlServerConnectionProperties(string connectionString) => _builder = new SqlConnectionStringBuilder(connectionString);

        public string ConnectionString => _builder.ConnectionString;
    }
}
