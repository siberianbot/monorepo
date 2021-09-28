using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public abstract class Entity
    {
        [Key]
        [Required]
        public virtual long Id { get; set; }
    }
}