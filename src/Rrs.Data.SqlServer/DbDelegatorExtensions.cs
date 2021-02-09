using System;
using System.Data;
using System.Data.SqlClient;

namespace Rrs.Data.SqlServer
{
    public static class DbDelegatorExtensions
    {
        public static void Execute(this IDbNonTransactionalDelegator db, Action<IDbConnection> command, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            db.Execute(SqlNotification.Execute, command, onChangeCallback, onError);
        }

        public static void Execute<T>(this IDbNonTransactionalDelegator db, Action<IDbConnection, T> command, T parameter, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            db.Execute(SqlNotification.Execute, command, parameter, onChangeCallback, onError);
        }

        public static T Execute<T>(this IDbNonTransactionalDelegator db, Func<IDbConnection, T> command, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            return db.Execute(SqlNotification.Execute, command, onChangeCallback, onError);
        }

        public static TOut Execute<TIn, TOut>(this IDbNonTransactionalDelegator db, Func<IDbConnection, TIn, TOut> command, TIn parameter, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            return db.Execute(SqlNotification.Execute, command, parameter, onChangeCallback, onError);
        }

        // 2
        public static void Execute<T1, T2>(this IDbNonTransactionalDelegator dbDelegator, Action<IDbConnection, T1, T2> command, T1 parameter1, T2 parameter2, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2), new Tuple<T1, T2>(parameter1, parameter2), onChangeCallback, onError);
        }

        public static TOut Execute<TIn1, TIn2, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TOut> command, TIn1 parameter1, TIn2 parameter2, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2), new Tuple<TIn1, TIn2>(parameter1, parameter2), onChangeCallback, onError);
        }

        // 3
        public static void Execute<T1, T2, T3>(this IDbNonTransactionalDelegator dbDelegator, Action<IDbConnection, T1, T2, T3> command, T1 parameter1, T2 parameter2, T3 parameter3, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3), new Tuple<T1, T2, T3>(parameter1, parameter2, parameter3), onChangeCallback, onError);
        }

        public static TOut Execute<TIn1, TIn2, TIn3, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3), new Tuple<TIn1, TIn2, TIn3>(parameter1, parameter2, parameter3), onChangeCallback, onError);
        }

        // 4
        public static void Execute<T1, T2, T3, T4>(this IDbNonTransactionalDelegator dbDelegator, Action<IDbConnection, T1, T2, T3, T4> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4), new Tuple<T1, T2, T3, T4>(parameter1, parameter2, parameter3, parameter4), onChangeCallback, onError);
        }

        public static TOut Execute<TIn1, TIn2, TIn3, TIn4, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4), new Tuple<TIn1, TIn2, TIn3, TIn4>(parameter1, parameter2, parameter3, parameter4), onChangeCallback, onError);
        }

        // 5
        public static void Execute<T1, T2, T3, T4, T5>(this IDbNonTransactionalDelegator dbDelegator, Action<IDbConnection, T1, T2, T3, T4, T5> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5), new Tuple<T1, T2, T3, T4, T5>(parameter1, parameter2, parameter3, parameter4, parameter5), onChangeCallback, onError);
        }

        public static TOut Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5), new Tuple<TIn1, TIn2, TIn3, TIn4, TIn5>(parameter1, parameter2, parameter3, parameter4, parameter5), onChangeCallback, onError);
        }

        // 6
        public static void Execute<T1, T2, T3, T4, T5, T6>(this IDbNonTransactionalDelegator dbDelegator, Action<IDbConnection, T1, T2, T3, T4, T5, T6> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6), new Tuple<T1, T2, T3, T4, T5, T6>(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6), onChangeCallback, onError);
        }

        public static TOut Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6), new Tuple<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6), onChangeCallback, onError);
        }

        // 7
        public static void Execute<T1, T2, T3, T4, T5, T6, T7>(this IDbNonTransactionalDelegator dbDelegator, Action<IDbConnection, T1, T2, T3, T4, T5, T6, T7> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6, o.Item7), new Tuple<T1, T2, T3, T4, T5, T6, T7>(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7), onChangeCallback, onError);
        }

        public static TOut Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, Action onChangeCallback, Action<SqlNotificationInfo> onError = null)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6, o.Item7), new Tuple<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7), onChangeCallback, onError);
        }
    }
}