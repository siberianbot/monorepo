using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ToDoList.Common.Helpers;

namespace ToDoList.DataAccess.Implementation
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ContextFactory _contextFactory;

        public UnitOfWork(ContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CommitAsync()
        {
            await _contextFactory.GetContext().SaveChangesAsync();
        }

        public Task RollbackAsync()
        {
            ChangeTracker changeTracker = _contextFactory.GetContext().ChangeTracker;

            while (changeTracker.HasChanges())
            {
                IEnumerable<EntityEntry> entries = changeTracker.Entries()
                    .Where(entry => entry.State.IsIn(EntityState.Added, EntityState.Modified, EntityState.Deleted));

                foreach (EntityEntry entry in entries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;

                        case EntityState.Modified:
                        case EntityState.Deleted:
                            entry.State = EntityState.Unchanged;
                            entry.CurrentValues.SetValues(entry.OriginalValues);
                            break;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(entry));
                    }
                }

                changeTracker.DetectChanges();
            }

            return Task.CompletedTask;
        }
    }
}