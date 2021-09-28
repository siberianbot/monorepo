using System.ComponentModel.DataAnnotations;

namespace Accounting.DataAccess.Extensions.Internal
{
    public class CodeLookupModel
    {
        [Key]
        public virtual long Id { get; set; }
        
        [StringLength(20)]
        public virtual string Code { get; set; }
    }
}