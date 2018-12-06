namespace Rrs.Data.SqlServer
{
    public static class SqlServerDbDelegatorFactory
    {
        public static DbDelegator Create(string connectionString, IDataBus dataBus = null)
        {
            var f = new SqlServerDbConnectionFactory(connectionString);
            return new DbDelegator(f, dataBus);
        }
    }
}
