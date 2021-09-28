using Accounting.DataAccess.Extensions;
using Accounting.Service.Entries.DomainModel;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Accounting.Service.Entries.DataAccess
{
    public class EntriesContext : DbContext
    {
        public EntriesContext(DbContextOptions<EntriesContext> options) : base(options)
        {
            //
        }

        public DbSet<Entry> Entry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .HasDefaultSchema("Entries")
                .CodeLookupEntity<EntryIndicator>();
            
            modelBuilder
                .Entity<Entry>()
                .HasIndex(x => x.Date)
                .HasSortOrder(SortOrder.Ascending);
        }
    }
}