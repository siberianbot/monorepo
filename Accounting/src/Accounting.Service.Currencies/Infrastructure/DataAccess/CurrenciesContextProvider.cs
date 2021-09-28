using Accounting.DataAccess.Implementation;
using Microsoft.Extensions.Options;

namespace Accounting.Service.Currencies.Infrastructure.DataAccess
{
    internal sealed class CurrenciesContextProvider : DbContextProvider<CurrenciesContext>
    {
        public CurrenciesContextProvider(IOptions<DatabaseOptions> databaseOptions) 
            : base(databaseOptions, options => new CurrenciesContext(options))
        {
            //
        }
    }
}