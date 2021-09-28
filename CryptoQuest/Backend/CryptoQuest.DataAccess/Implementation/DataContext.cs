using CryptoQuest.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoQuest.DataAccess.Implementation
{
    internal sealed class DataContext : DbContext
    {
        public DbSet<Player> Player { get; set; }
        
        public DbSet<Location> Location { get; set; }
        
        public DbSet<PlayerLocationHistory> PlayerLocationHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}