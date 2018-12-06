namespace Rrs.Data.SqlServer
{
    public class SqlServerDbConnectionProperties
    {
        public string Server { get; }
        public string Database { get; }
        public string Username { get; }
        public string Password { get; }

        public SqlServerDbConnectionProperties(string server, string database, string username = null, string password = null)
        {
            Server = server;
            Database = database;
            Username = username;
            Password = password;
        }

        public string ConnectionString
        {
            get
            {
                if (Username == null || Password == null) return $"Data Source={Server};Initial Catalog={Database};Integrated Security=SSPI;";
                return $"Data Source={Server};Initial Catalog={Database};UID={Username};pwd={Password}";
            }
        }
    }
}
