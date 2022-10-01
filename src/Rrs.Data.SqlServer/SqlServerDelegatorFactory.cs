namespace Rrs.Data.SqlServer
{
    public static class SqlServerDelegatorFactory
    {
        public static DbDelegator Create(string connectionString)
        {
            var f = new SqlServerConnectionFactory(connectionString);
            return new DbDelegator(f);
        }

        public static DbDelegator Create(IConnectionProperties connectionProperties)
        {
            var f = new SqlServerConnectionFactory(connectionProperties);
            return new DbDelegator(f);
        }
    }
}
