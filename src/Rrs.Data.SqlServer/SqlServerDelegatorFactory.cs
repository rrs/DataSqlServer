namespace Rrs.Data.SqlServer
{
    public static class SqlServerDelegatorFactory
    {
        public static DbDelegator Create(string connectionString, IDataBus dataBus = null)
        {
            var f = new SqlServerConnectionFactory(connectionString);
            return new DbDelegator(f, dataBus);
        }
    }
}
