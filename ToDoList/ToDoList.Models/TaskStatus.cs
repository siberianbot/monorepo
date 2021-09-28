using System.ComponentModel.DataAnnotations;
using ToDoList.Models.Resources;

namespace ToDoList.Models
{
    public enum TaskStatus : long
    {
        [Display(ResourceType = typeof(Enums), Name = "TaskStatus_New")]
        New = 10,

        [Display(ResourceType = typeof(Enums), Name = "TaskStatus_InProgress")]
        InProgress = 20,

        [Display(ResourceType = typeof(Enums), Name = "TaskStatus_Canceled")]
        Canceled = 30,

        [Display(ResourceType = typeof(Enums), Name = "TaskStatus_Completed")]
        Completed = 40
    }
}