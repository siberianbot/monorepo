using System.ComponentModel.DataAnnotations;

namespace CryptoQuest.Models
{
    public class Player : Entity
    {
        [Required]
        [StringLength(36)]
        public virtual string Cookie { get; set; }
        
        [Required]
        public virtual long? CurrentLocationId { get; set; }

        #region Navigation properties

        public virtual Location CurrentLocation { get; set; }

        #endregion
    }
}