using System.ComponentModel.DataAnnotations;
using ToDoList.Models;
using ToDoList.Web.Resources;

namespace ToDoList.Web.ViewModels
{
    public sealed class TaskItemViewModel
    {
        public long Id { get; set; }
        
        [Display(Name = "Title", ResourceType = typeof(Fields))]
        public string Title { get; set; }
        
        [Display(Name = "Status", ResourceType = typeof(Fields))]
        public TaskStatus Status { get; set; }
    }
}