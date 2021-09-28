using System.Threading.Tasks;
using TeamWorks.DependencyInjection;
using TeamWorks.DomainModel.DataContracts;

namespace TeamWorks.DataAccess
{
    public interface IWriteRepository<TEntity> : IDependency
        where TEntity : IEntity
    {
        TEntity New();

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}