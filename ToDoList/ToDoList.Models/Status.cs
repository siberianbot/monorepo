using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Status : Entity
    {
        [Required]
        [StringLength(10)]
        public virtual string Code { get; set; }
    }
}