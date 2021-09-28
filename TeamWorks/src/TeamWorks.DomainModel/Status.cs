using System.ComponentModel.DataAnnotations;

namespace TeamWorks.DomainModel
{
    public class Status : Entity<long>
    {
        [Required]
        [StringLength(20)]
        public string Code { get; set; }
    }
}