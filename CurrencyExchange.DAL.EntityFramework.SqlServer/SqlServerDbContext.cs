namespace CurrencyExchange.DAL.EntityFramework.SqlServer
{
    using Microsoft.EntityFrameworkCore;

    public class SqlServerDbContext : EfDbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
            : base(options)
        {
        }
    }
}