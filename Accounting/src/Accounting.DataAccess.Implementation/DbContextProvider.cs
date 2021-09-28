using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Accounting.DataAccess.Implementation
{
    public abstract class DbContextProvider<TContext> : IDbContextProvider
        where TContext : DbContext
    {
        private readonly IOptions<DatabaseOptions> _databaseOptions;
        private readonly Func<DbContextOptions<TContext>, TContext> _contextFactory;

        private TContext _context;

        protected DbContextProvider(
            IOptions<DatabaseOptions> databaseOptions,
            Func<DbContextOptions<TContext>, TContext> contextFactory)
        {
            _databaseOptions = databaseOptions;
            _contextFactory = contextFactory;
        }

        public DbContext GetContext()
        {
            if (_context != null)
            {
                return _context;
            }

            DbContextOptionsBuilder<TContext> optionsBuilder = new DbContextOptionsBuilder<TContext>();

            ConfigureContext(optionsBuilder);

            _context = _contextFactory(optionsBuilder.Options);

            return _context;
        }

        protected virtual void ConfigureContext(DbContextOptionsBuilder<TContext> optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_databaseOptions.Value.ConnectionString);
        }
    }
}