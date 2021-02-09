using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Rrs.Data.SqlServer
{
    class SqlConnectionWithDependency : DbConnection
    {
        private readonly SqlConnection _sqlConnection;
        private readonly SqlDependency _sqlDependency;

        public SqlConnectionWithDependency(SqlConnection sqlConnection, SqlDependency sqlDependency)
        {
            _sqlConnection = sqlConnection;
            _sqlDependency = sqlDependency;
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return _sqlConnection.BeginTransaction(isolationLevel);
        }

        public override void Close()
        {
            _sqlConnection.Close();
        }

        public override void ChangeDatabase(string databaseName)
        {
            _sqlConnection.ChangeDatabase(databaseName);
        }

        public override void Open()
        {
            _sqlConnection.Open();
        }

        public override string ConnectionString
        {
            get => _sqlConnection.ConnectionString;
            set => _sqlConnection.ConnectionString = value;
        }

        public override string Database => _sqlConnection.Database;

        public override ConnectionState State => _sqlConnection.State;

        public override string DataSource => _sqlConnection.DataSource;

        public override string ServerVersion => _sqlConnection.ServerVersion;

        protected override DbCommand CreateDbCommand()
        {
            var command = _sqlConnection.CreateCommand();
            _sqlDependency.AddCommandDependency(command);
            return command;
        }
    }

}
