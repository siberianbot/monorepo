using System.Threading.Tasks;
using Accounting.Common.DomainModel;

namespace Accounting.DataAccess
{
    public interface IWriteRepository<in TEntity>
        where TEntity : class, IEntity
    {
        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}