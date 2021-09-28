using System.Threading.Tasks;
using Accounting.Common.DomainModel;

namespace Accounting.DataAccess.Implementation.Internal
{
    internal sealed class WriteRepository<TEntity> : IWriteRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IDbContextProvider _contextProvider;

        public WriteRepository(IDbContextProvider contextProvider)
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