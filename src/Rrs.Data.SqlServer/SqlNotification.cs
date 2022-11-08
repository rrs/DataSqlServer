using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Rrs.Data.SqlServer
{
    static class SqlNotification
    {
        public static void Execute(IDbConnection c, Action<IDbConnection> command, Action onChangeCallback, Action<SqlNotificationInfo> onError)
        {
            using (var connection = SetupSqlDependency(c, onChangeCallback, onError))
            {
                command(connection);
            }
        }

        public static void Execute<T>(IDbConnection c, Action<IDbConnection, T> command, T parameter, Action onChangeCallback, Action<SqlNotificationInfo> onError)
        {
            using (var connection = SetupSqlDependency(c, onChangeCallback, onError))
            {
                command(connection, parameter);
            }
        }

        public static T Execute<T>(IDbConnection c, Func<IDbConnection, T> command, Action onChangeCallback, Action<SqlNotificationInfo> onError)
        {
            using (var connection = SetupSqlDependency(c, onChangeCallback, onError))
            {
                return command(connection);
            }
        }

        public static TOut Execute<TIn, TOut>(IDbConnection c, Func<IDbConnection, TIn, TOut> command, TIn parameter, Action onChangeCallback, Action<SqlNotificationInfo> onError)
        {
            using (var connection = SetupSqlDependency(c, onChangeCallback, onError))
            {
                return command(connection, parameter);
            }
        }
        
        private static SqlConnectionWithDependency SetupSqlDependency(IDbConnection c, Action onChangeCallback, Action<SqlNotificationInfo> onError)
        {
            var dependency = new SqlDependency();

            void dependencyCallback(object o, SqlNotificationEventArgs e)
            {
                dependency.OnChange -= dependencyCallback;

                if (e.Type == SqlNotificationType.Subscribe || e.Info == SqlNotificationInfo.Error)
                {
                    onError?.Invoke(e.Info);
                }
                else
                {
                    onChangeCallback();
                }
            }

            dependency.OnChange += dependencyCallback;

            return new SqlConnectionWithDependency((SqlConnection)c, dependency);
        }
    }
}
