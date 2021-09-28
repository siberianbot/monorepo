using System.Threading.Tasks;
using TeamWorks.DomainModel.DataContracts;

namespace TeamWorks.Services.Command
{
    public interface ICommandService<TEntity>
        where TEntity : IEntity
    {
        TEntity New();

        Task CreateAsync(TEntity entity);
        
        Task UpdateAsync(TEntity entity);
        
        Task DeleteAsync(TEntity entity);
    }
}