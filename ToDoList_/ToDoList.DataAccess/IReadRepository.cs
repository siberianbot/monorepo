using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.DataAccess
{
    public interface IReadRepository<TEntity>
        where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();

        ValueTask<TEntity> GetByIdAsync(long id);
    }
}