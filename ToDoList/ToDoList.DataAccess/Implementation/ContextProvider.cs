using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ToDoList.DataAccess.Implementation
{
    internal sealed class ContextProvider : IContextProvider
    {
        private readonly IOptions<DatabaseOptions> _databaseOptions;

        private DbContext _context;

        public ContextProvider(IOptions<DatabaseOptions> databaseOptions)
        {
            _databaseOptions = databaseOptions;
        }

        public DbContext GetContext()
        {
            if (_context == null)
            {
                DbConnection connection = new SqlConnection(_databaseOptions.Value.ConnectionString);

                _context = new EFContext(connection);
            }
            
            return _context;
        }
    }
}