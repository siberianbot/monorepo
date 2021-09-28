using System;
using Accounting.DataAccess.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Accounting.DataAccess.Design
{
    public abstract class DbContextDesignTimeFactory<TContext> : IDesignTimeDbContextFactory<TContext>
        where TContext : DbContext
    {
        private readonly Func<IOptions<DatabaseOptions>, IDbContextProvider> _contextProviderFactory;

        protected DbContextDesignTimeFactory(Func<IOptions<DatabaseOptions>, IDbContextProvider> contextProviderFactory)
        {
            _contextProviderFactory = contextProviderFactory;
        }

        #region IDesignTimeDbContextFactory<TContext>

        TContext IDesignTimeDbContextFactory<TContext>.CreateDbContext(string[] args)
        {
            IConfiguration configuration = CreateConfiguration(args);
            DatabaseOptions databaseOptions = ConfigureDatabaseOptions(configuration);
            IOptions<DatabaseOptions> databaseOptionsWrapper = new OptionsWrapper<DatabaseOptions>(databaseOptions);

            return (TContext) _contextProviderFactory(databaseOptionsWrapper).GetContext();
        }

        #endregion

        protected virtual void ConfigureAppConfiguration(ConfigurationBuilder configurationBuilder)
        {
            //
        }

        protected abstract DatabaseOptions ConfigureDatabaseOptions(IConfiguration configuration);

        private IConfiguration CreateConfiguration(string[] args)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            configurationBuilder.AddCommandLine(args);

            ConfigureAppConfiguration(configurationBuilder);

            return configurationBuilder.Build();
        }
    }
}