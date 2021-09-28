using System.Threading.Tasks;

namespace ToDoList.DataAccess
{
    public interface IWriteRepository<in TEntity>
    {
        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}