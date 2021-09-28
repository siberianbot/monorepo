using System.ComponentModel.DataAnnotations;

namespace CryptoQuest.Models
{
    public class Location : Entity
    {
        [Required]
        public virtual string Link { get; set; }
    }
}