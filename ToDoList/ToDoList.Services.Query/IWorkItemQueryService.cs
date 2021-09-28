using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services.Query
{
    public interface IWorkItemQueryService
    {
        IQueryable<WorkItem> GetAll();

        Task<WorkItem> GetByIdAsync(long id);
    }
}