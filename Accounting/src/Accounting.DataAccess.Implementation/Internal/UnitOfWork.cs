using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Accounting.DataAccess.Implementation.Internal
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContextProvider _contextProvider;

        public UnitOfWork(IDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public async Task CommitAsync()
        {
            await _contextProvider.GetContext().SaveChangesAsync();
        }

        public Task RollbackAsync()
        {
            ChangeTracker changeTracker = _contextProvider.GetContext().ChangeTracker;

            while (changeTracker.HasChanges())
            {
                IEnumerable<EntityEntry> modifiedEntries = changeTracker.Entries()
                    .Where(entry => entry.State.IsIn(EntityState.Added, EntityState.Modified, EntityState.Deleted));

                foreach (EntityEntry modifiedEntry in modifiedEntries)
                {
                    switch (modifiedEntry.State)
                    {
                        case EntityState.Added:
                            modifiedEntry.State = EntityState.Detached;
                            break;

                        case EntityState.Modified:
                        case EntityState.Deleted:
                            modifiedEntry.CurrentValues.SetValues(modifiedEntry.OriginalValues);
                            modifiedEntry.State = EntityState.Unchanged;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(modifiedEntry.State));
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}