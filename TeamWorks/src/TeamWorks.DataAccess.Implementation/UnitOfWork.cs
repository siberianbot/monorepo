using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TeamWorks.Common.Extensions;

namespace TeamWorks.DataAccess.Implementation
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal sealed class UnitOfWork : IUnitOfWork
    {
        #region Constructor and private fields

        private readonly IDbContextFactory _dbContextFactory;

        public UnitOfWork(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #endregion

        public async Task CommitAsync()
        {
            await _dbContextFactory.GetContext().SaveChangesAsync();
        }

        public Task RollbackAsync()
        {
            DbContext context = _dbContextFactory.GetContext();
            IEnumerable<EntityEntry> changedEntries = context.ChangeTracker.Entries().Where(entry => entry.State.IsIn(EntityState.Added, EntityState.Modified, EntityState.Deleted));

            foreach (EntityEntry entityEntry in changedEntries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        entityEntry.State = EntityState.Detached;
                        break;

                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entityEntry.CurrentValues.SetValues(entityEntry.OriginalValues);
                        entityEntry.State = EntityState.Unchanged;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(entityEntry.State), "Incompatible entity entry state.");
                }
            }
            
            context.Database.RollbackTransaction();

            return Task.CompletedTask;
        }
    }
}