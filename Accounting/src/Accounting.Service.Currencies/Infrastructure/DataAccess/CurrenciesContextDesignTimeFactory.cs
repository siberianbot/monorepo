using Accounting.DataAccess.Design;
using Accounting.DataAccess.Implementation;
using Microsoft.Extensions.Configuration;

namespace Accounting.Service.Currencies.Infrastructure.DataAccess
{
    public sealed class CurrenciesContextDesignTimeFactory : DbContextDesignTimeFactory<CurrenciesContext>
    {
        public CurrenciesContextDesignTimeFactory() : base(options => new CurrenciesContextProvider(options))
        {
            //
        }
        
        protected override DatabaseOptions ConfigureDatabaseOptions(IConfiguration configuration)
        {
            return configuration.GetSection("database").Get<DatabaseOptions>();
        }

        protected override void ConfigureAppConfiguration(ConfigurationBuilder configurationBuilder)
        {
            base.ConfigureAppConfiguration(configurationBuilder);
            
            configurationBuilder.AddJsonFile($"appsettings.json");
        }
    }
}