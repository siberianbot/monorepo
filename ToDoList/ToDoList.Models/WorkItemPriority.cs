using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class WorkItemPriority
    {
        [Key]
        public virtual long Id { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string Name { get; set; }
    }
}