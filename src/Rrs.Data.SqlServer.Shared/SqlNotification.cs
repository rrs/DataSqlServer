using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

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

        //public static void Execute<T>(IDbConnection c, Func<IDbConnection, T> command, Action<T> onChangeCallback, Action<string> onError, TimeSpan retryInterval)
        //{
        //    void restart()
        //    {
        //        Timer timer = null;
        //        timer = new Timer(_ =>
        //        {
        //            timer.Dispose();
        //            try
        //            {
        //                SqlDependency.Stop(c.ConnectionString);
        //                SqlDependency.Start(c.ConnectionString);
        //                monitor();
        //            }
        //            catch (Exception e)
        //            {
        //                onError(e.Message);
        //                restart();
        //            }
        //        });

        //        timer.Change(Math.Max((int)retryInterval.TotalMilliseconds, 0), Timeout.Infinite);
        //    }

        //    void onSqlDependencyError(SqlNotificationInfo info)
        //    {
        //        try
        //        {
        //            onError(info.ToString());
        //            restart();
        //        }
        //        catch (Exception e)
        //        {
        //            onError(e.Message);
        //        }
        //    }

        //    void monitor()
        //    {
        //        try
        //        {
        //            using (var connection = SetupSqlDependency(c, monitor, onSqlDependencyError))
        //            {
        //                var result = command(connection);
        //                onChangeCallback(result);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            onError(e.Message);
        //            restart();
        //        }
        //    }

        //    monitor();
        //}

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
