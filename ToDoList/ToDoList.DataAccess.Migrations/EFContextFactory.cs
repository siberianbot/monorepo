using System.Data.Common;
using JetBrains.Annotations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ToDoList.DataAccess.Implementation;

namespace ToDoList.DataAccess.Migrations
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
    public sealed class EFContextFactory : IDesignTimeDbContextFactory<DbContext>
    {
        private const string ConnectionString = "Server=localhost;Database=ToDoList;Integrated Security=True;";

        public DbContext CreateDbContext(string[] args)
        {
            DbConnection connection = new SqlConnection(ConnectionString);

            return new EFContext(connection);
        }
    }
}