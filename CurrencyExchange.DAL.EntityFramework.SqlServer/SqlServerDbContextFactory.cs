namespace CurrencyExchange.DAL.EntityFramework.SqlServer
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class SqlServerDbContextFactory : IDesignTimeDbContextFactory<SqlServerDbContext>
    {
        public SqlServerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqlServerDbContext>();
            optionsBuilder.UseSqlServer(EfDbContext.DefaultConnectionStringName);
            return new SqlServerDbContext(optionsBuilder.Options);
        }
    }
}