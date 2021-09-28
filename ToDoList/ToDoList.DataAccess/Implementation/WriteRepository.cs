using System.Threading.Tasks;

namespace ToDoList.DataAccess.Implementation
{
    internal sealed class WriteRepository<TEntity> : IWriteRepository<TEntity>
    {
        private readonly IContextProvider _contextProvider;

        public WriteRepository(IContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _contextProvider.GetContext().AddAsync(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
            _contextProvider.GetContext().Update(entity);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity)
        {
            _contextProvider.GetContext().Remove(entity);

            return Task.CompletedTask;
        }
    }
}