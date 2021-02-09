namespace Rrs.Data.SqlServer
{
    public static class SqlServerDelegatorFactory
    {
        public static DbDelegator Create(string connectionString, IDelegatorBus dataBus = null)
        {
            var f = new SqlServerConnectionFactory(connectionString);
            return new DbDelegator(f, dataBus);
        }

        public static DbDelegator Create(IConnectionProperties connectionProperties, IDelegatorBus dataBus = null)
        {
            var f = new SqlServerConnectionFactory(connectionProperties);
            return new DbDelegator(f, dataBus);
        }
    }
}
