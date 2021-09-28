using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.DataAccess
{
    public interface IReadRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(long id);
    }
}