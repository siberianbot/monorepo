using System.ComponentModel.DataAnnotations;

namespace CryptoQuest.Models
{
    public abstract class Entity
    {
        [Key]
        public virtual long Id { get; set; }
    }
}