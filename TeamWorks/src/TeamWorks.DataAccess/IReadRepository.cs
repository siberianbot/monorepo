using System.Linq;
using System.Threading.Tasks;
using TeamWorks.DependencyInjection;
using TeamWorks.DomainModel;

namespace TeamWorks.DataAccess
{
    public interface IReadRepository<in TKey, TEntity> : IDependency
        where TEntity : Entity<TKey>
    {
        IQueryable<TEntity> GetAll();

        ValueTask<TEntity> GetByIdAsync(TKey key);
    }
}