using System.Linq;
using System.Threading.Tasks;
using Accounting.Common.DomainModel;

namespace Accounting.DataAccess
{
    public interface IReadRepository<in TKey, TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(TKey key);
    }
}