using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services.Command
{
    public interface IWorkItemCommandService
    {
        Task CreateAsync(WorkItem entity);

        Task UpdateAsync(WorkItem entity);

        Task DeleteAsync(WorkItem entity);
    }
}