using System;
using System.Threading;
using JetBrains.Annotations;
using ToDoList.Models;
using Task = System.Threading.Tasks.Task;

namespace ToDoList.DataAccess.Implementation
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal sealed class WriteRepository<TEntity> : IWriteRepository<TEntity>
        where TEntity : Entity, new()
    {
        private readonly ContextFactory _contextFactory;
        private long _id = Int64.MinValue;

        public WriteRepository(ContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public TEntity New()
        {
            return new()
            {
                Id = Interlocked.Increment(ref _id)
            };
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _contextFactory.GetContext().AddAsync(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
            _contextFactory.GetContext().Update(entity);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity)
        {
            _contextFactory.GetContext().Remove(entity);
            
            return Task.CompletedTask;
        }
    }
}