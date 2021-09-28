using System.Linq;
using System.Threading.Tasks;
using Accounting.Common.DomainModel;

namespace Accounting.DataAccess.Implementation.Internal
{
    internal sealed class ReadRepository<TKey, TEntity> : IReadRepository<TKey, TEntity>
        where TEntity : class, IEntity
    {
        private readonly IDbContextProvider _contextProvider;

        public ReadRepository(IDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }
        
        public IQueryable<TEntity> GetAll()
        {
            return _contextProvider.GetContext().Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(TKey key)
        {
            return await _contextProvider.GetContext().FindAsync<TEntity>(key);
        }
    }
}