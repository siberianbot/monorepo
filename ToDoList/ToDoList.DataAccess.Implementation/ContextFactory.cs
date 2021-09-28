using System.Data.Common;
using JetBrains.Annotations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToDoList.DataAccess.Implementation.SqlServer;
using ToDoList.DataAccess.Models;

namespace ToDoList.DataAccess.Implementation
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal sealed class ContextFactory
    {
        private readonly DbConnection _connection;
        private DbContext _context;

        public ContextFactory(IOptions<DatabaseOptions> databaseOptions)
        {
            _connection = new SqlConnection(databaseOptions.Value.ConnectionString);
        }

        public DbContext GetContext()
        {
            if (_context == null)
            {
                DbContextOptionsBuilder<EFContext> builder = new();

                builder.UseSqlServer(_connection);

                _context = new EFContext(builder.Options);
            }

            return _context;
        }
    }
}