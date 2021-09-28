using System;
using System.ComponentModel.DataAnnotations;
using Accounting.Service.Entries.DomainModel;

namespace Accounting.Service.Entries.Models.CreateEntry
{
    public sealed class CreateEntryModel
    {
        [Required]
        public DateTime? EntryDate { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        
        [Required]
        public decimal? Amount { get; set; }
        
        [Required]
        public EntryIndicator? EntryIndicator { get; set; }
    }
}