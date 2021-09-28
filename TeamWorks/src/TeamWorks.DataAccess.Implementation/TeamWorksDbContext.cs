using Microsoft.EntityFrameworkCore;
using TeamWorks.DomainModel;

namespace TeamWorks.DataAccess.Implementation
{
    internal class TeamWorksDbContext : DbContext, IDbContextFactory
    {
        public DbSet<Scope> Scope { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<WorkItem> WorkItem { get; set; }
        
        public DbContext GetContext()
        {
            // TODO: factory class
            return this;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=TeamWorks;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Scope>()
                .HasOne(x => x.ParentScope)
                .WithMany(x => x.ChildScopes)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}