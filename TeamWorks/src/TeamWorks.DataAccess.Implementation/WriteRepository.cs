using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using TeamWorks.Common.Extensions;
using TeamWorks.DomainModel.DataContracts;

namespace TeamWorks.DataAccess.Implementation
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal sealed class WriteRepository<TEntity> : IWriteRepository<TEntity>
        where TEntity : IEntity, new()
    {
        #region Constructor and private fields

        private readonly DbContext _dbContext;
        private readonly IEnumerable<IWriteRepositoryHook<TEntity>> _hooks;

        public WriteRepository(
            IDbContextFactory dbContextFactory,
            IEnumerable<IWriteRepositoryHook<TEntity>> hooks)
        {
            _dbContext = dbContextFactory.GetContext();
            _hooks = hooks ?? Array.Empty<IWriteRepositoryHook<TEntity>>();
        }

        #endregion

        public TEntity New()
        {
            return new TEntity();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _hooks.ForEachAsync(hook => hook.OnBeforeCreateAsync(entity));

            await _dbContext.AddAsync(entity);

            await _hooks.ForEachAsync(hook => hook.OnAfterCreateAsync(entity));
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _hooks.ForEachAsync(hook => hook.OnBeforeUpdateAsync(entity));

            _dbContext.Update(entity);

            await _hooks.ForEachAsync(hook => hook.OnAfterUpdateAsync(entity));
        }

        public Task DeleteAsync(TEntity entity)
        {
            _dbContext.Remove(entity);

            return Task.CompletedTask;
        }
    }
}