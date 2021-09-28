using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using TeamWorks.DomainModel;

namespace TeamWorks.DataAccess.Implementation
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal sealed class ReadRepository<TKey, TEntity> : IReadRepository<TKey, TEntity>
        where TEntity : Entity<TKey>
    {
        #region Constructor and private fields

        private readonly DbContext _dbContextFactory;

        public ReadRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory.GetContext();
        }

        #endregion

        public IQueryable<TEntity> GetAll()
        {
            return _dbContextFactory.Set<TEntity>();
        }

        public ValueTask<TEntity> GetByIdAsync(TKey key)
        {
            return _dbContextFactory.FindAsync<TEntity>(key);
        }
    }
}