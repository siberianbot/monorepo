using Accounting.DataAccess.Design;
using Accounting.DataAccess.Implementation;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;

namespace Accounting.Service.Entries.DataAccess
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
    public sealed class EntriesContextDesignTimeFactory : DbContextDesignTimeFactory<EntriesContext>
    {
        public EntriesContextDesignTimeFactory() : base(options => new EntriesContextProvider(options))
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