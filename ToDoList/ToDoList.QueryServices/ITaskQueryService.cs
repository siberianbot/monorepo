using System.Linq;
using System.Threading.Tasks;
using Task = ToDoList.Models.Task;

namespace ToDoList.QueryServices
{
    public interface ITaskQueryService
    {
        IQueryable<Task> GetAll();

        IQueryable<Task> GetAllByParentTask(long? parentTaskId);
            
        Task<Task> GetByIdAsync(long id);
    }
}