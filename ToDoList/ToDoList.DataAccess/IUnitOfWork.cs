using System.Threading.Tasks;

namespace ToDoList.DataAccess
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        Task RollbackAsync();
    }
}