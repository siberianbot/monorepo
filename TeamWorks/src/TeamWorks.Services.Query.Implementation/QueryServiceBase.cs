using System.Linq;
using System.Threading.Tasks;
using TeamWorks.DataAccess;
using TeamWorks.DomainModel;

namespace TeamWorks.Services.Query.Implementation
{
    internal abstract class QueryServiceBase<TKey, TEntity> : IQueryService<TKey, TEntity>
        where TEntity : Entity<TKey>
    {
        #region Constructor and private fields

        private readonly IReadRepository<TKey, TEntity> _readRepository;

        protected QueryServiceBase(IReadRepository<TKey, TEntity> readRepository)
        {
            _readRepository = readRepository;
        }

        #endregion

        public IQueryable<TEntity> GetAll()
        {
            return _readRepository.GetAll();
        }

        public ValueTask<TEntity> GetByIdAsync(TKey id)
        {
            return _readRepository.GetByIdAsync(id);
        }
    }
}