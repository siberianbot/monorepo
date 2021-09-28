using ToDoList.Models;
using Task = System.Threading.Tasks.Task;

namespace ToDoList.DataAccess
{
    public interface IWriteRepository<TEntity>
        where TEntity : Entity
    {
        TEntity New();

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}