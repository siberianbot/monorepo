using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ToDoList.Common.Extensions;

namespace ToDoList.DataAccess.Implementation
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IContextProvider _contextProvider;

        public UnitOfWork(IContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public async Task CommitAsync()
        {
            DbContext context = _contextProvider.GetContext();

            while (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }

        public Task RollbackAsync()
        {
            ChangeTracker changeTracker = _contextProvider.GetContext().ChangeTracker;

            while (changeTracker.HasChanges())
            {
                IEnumerable<EntityEntry> changedEntries = changeTracker.Entries().Where(entry => entry.State.IsIn(EntityState.Added, EntityState.Deleted, EntityState.Modified));

                foreach (EntityEntry entry in changedEntries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;

                        case EntityState.Modified:
                        case EntityState.Deleted:
                            entry.CurrentValues.SetValues(entry.OriginalValues);
                            entry.State = EntityState.Unchanged;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}