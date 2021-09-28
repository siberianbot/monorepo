using Accounting.Service.Currencies.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Service.Currencies.Infrastructure.DataAccess
{
    public class CurrenciesContext : DbContext
    {
        public CurrenciesContext(DbContextOptions<CurrenciesContext> options) : base(options)
        {
            //
        }

        public DbSet<Currency> Currency { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Currencies");
        }
    }
}