using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ToDoList.DataAccess.Implementation.SqlServer;
using ToDoList.DataAccess.Models;

namespace ToDoList.DataAccess.Implementation
{
    internal sealed class DesignTimeEFContextFactory : IDesignTimeDbContextFactory<EFContext>
    {
        public EFContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

            DatabaseOptions databaseOptions = configuration.GetSection("database").Get<DatabaseOptions>();

            return (EFContext) new ContextFactory(new OptionsWrapper<DatabaseOptions>(databaseOptions)).GetContext();
        }
    }
}