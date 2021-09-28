using System;
using System.ComponentModel.DataAnnotations;
using Accounting.Common.DomainModel;

namespace Accounting.Service.Entries.DomainModel
{
    public class Entry : Entity<long>
    {
        [Required]
        public virtual DateTime? Date { get; set; }

        [Required]
        [StringLength(4000)]
        public virtual string Description { get; set; }

        [Required]
        public virtual decimal? Amount { get; set; }

        [Required]
        public virtual long? EntryIndicatorId { get; set; }

        public void SetEntryIndicator(EntryIndicator value)
        {
            EntryIndicatorId = (long) value;
        }

        public EntryIndicator GetEntryIndicator()
        {
            return (EntryIndicator) EntryIndicatorId!.Value;
        }
    }
}