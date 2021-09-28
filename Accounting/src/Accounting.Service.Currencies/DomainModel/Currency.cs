using System.ComponentModel.DataAnnotations;
using Accounting.Common.DomainModel;

namespace Accounting.Service.Currencies.DomainModel
{
    public class Currency : Entity<long>
    {
        [Required]
        [StringLength(3)]
        public virtual string Code { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string Name { get; set; }
    }
}