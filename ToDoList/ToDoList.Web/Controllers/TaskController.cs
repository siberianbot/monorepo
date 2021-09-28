using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using ToDoList.QueryServices;
using ToDoList.Web.ViewModels;
using Task = ToDoList.Models.Task;
using TaskStatus = ToDoList.Models.TaskStatus;

namespace ToDoList.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskQueryService _taskQueryService;

        public TaskController(ITaskQueryService taskQueryService)
        {
            _taskQueryService = taskQueryService;
        }

        public async Task<IActionResult> GetTasks(long? parentTaskId)
        {
            TaskItemViewModel[] tasks = await _taskQueryService
                .GetAllByParentTask(parentTaskId)
                .Select(task => new TaskItemViewModel
                {
                    Id = task.Id,
                    Title = task.Title,
                    Status = (TaskStatus) task.StatusId.Value
                })
                .ToArrayAsync();

            return Json(tasks);
        }

        public async Task<IActionResult> GetTask(long taskId)
        {
            Task task = await _taskQueryService.GetByIdAsync(taskId);

            if (task == null)
            {
                return BadRequest();
            }

            TaskViewModel viewModel = new TaskViewModel
            {
                
            };

            return ;
        }
    }
}