using ToDoList.Models;

namespace ToDoList.CommandServices
{
    public interface ITaskCommandService
    {
        Task New();

        System.Threading.Tasks.Task CreateAsync(Task entity);

        System.Threading.Tasks.Task UpdateAsync(Task entity);

        System.Threading.Tasks.Task DeleteAsync(Task entity);
    }
}