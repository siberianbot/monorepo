using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.DataAccess.Implementation
{
    internal sealed class ReadRepository<TEntity> : IReadRepository<TEntity>
        where TEntity : class
    {
        private readonly IContextProvider _contextProvider;

        public ReadRepository(IContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _contextProvider.GetContext().Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _contextProvider.GetContext().FindAsync<TEntity>(id);
        }
    }
}