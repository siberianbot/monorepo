using System.Linq;
using System.Threading.Tasks;
using TeamWorks.DomainModel;

namespace TeamWorks.Services.Query
{
    public interface IQueryService<in TKey, TEntity>
        where TEntity : Entity<TKey>
    {
        IQueryable<TEntity> GetAll();

        ValueTask<TEntity> GetByIdAsync(TKey id);
    }
}