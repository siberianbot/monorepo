using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.DataAccess.Implementation.SqlServer
{
    internal sealed class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
            //
        }

        public DbSet<Task> Task { get; set; }

        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task>()
                .HasMany(x => x.ChildTasks)
                .WithOne(x => x.ParentTask);
        }
    }
}