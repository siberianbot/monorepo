using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.DataAccess.Implementation
{
    internal sealed class EFContext : DbContext
    {
        private readonly DbConnection _dbConnection;

        public EFContext(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public DbSet<WorkItem> WorkItem { get; set; }
        public DbSet<WorkItemPriority> WorkItemPriority { get; set; }
        public DbSet<WorkItemType> WorkItemType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbConnection, options =>
            {
                options.MigrationsAssembly("ToDoList.DataAccess.Migrations");
            });
        }
    }
}