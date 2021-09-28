using Accounting.DataAccess.Implementation;
using Microsoft.Extensions.Options;

namespace Accounting.Service.Entries.DataAccess
{
    internal sealed class EntriesContextProvider : DbContextProvider<EntriesContext>
    {
        public EntriesContextProvider(IOptions<DatabaseOptions> databaseOptions) : 
            base(databaseOptions, options => new EntriesContext(options))
        {
            //
        }
    }
}