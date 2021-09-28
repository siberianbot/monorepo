using System.Threading.Tasks;
using TeamWorks.DependencyInjection;
using TeamWorks.DomainModel.DataContracts;

namespace TeamWorks.DataAccess
{
    public interface IWriteRepositoryHook<in TEntity> : IDependency
        where TEntity : IEntity
    {
        Task OnBeforeCreateAsync(TEntity entity);

        Task OnAfterCreateAsync(TEntity entity);

        Task OnBeforeUpdateAsync(TEntity entity);

        Task OnAfterUpdateAsync(TEntity entity);
    }
}