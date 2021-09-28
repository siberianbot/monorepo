using System.ComponentModel.DataAnnotations;

namespace CryptoQuest.Models
{
    public class PlayerLocationHistory
    {
        [Required]
        public virtual long? PlayerId { get; set; }

        [Required]
        public virtual long? LocationId { get; set; }
        
        #region Navigation properties

        public virtual Player Player { get; set; }
        
        public virtual Location Location { get; set; }

        #endregion
    }
}