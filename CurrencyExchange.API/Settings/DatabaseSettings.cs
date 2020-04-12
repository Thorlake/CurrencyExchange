namespace CurrencyExchange.API.Settings
{
    using System;

    public class DatabaseSettings
    {
        public const string MsSql = "mssql";
        public const string MySql = "mysql";
        public const string PgSql = "pgsql";

        public string Provider { get; set; }

        public T MatchProvider<T>(
            Func<T> msSql,
            Func<T> mySql,
            Func<T> pgSql)
        {
            var provider = string.IsNullOrEmpty(Provider)
                ? MsSql
                : Provider.ToLowerInvariant();

            switch (provider)
            {
                case MsSql: return msSql.Invoke();
                case MySql: return mySql.Invoke();
                case PgSql: return pgSql.Invoke();
            }

            throw new InvalidOperationException($"Database provider '{Provider}' is not supported");
        }
    }
}
