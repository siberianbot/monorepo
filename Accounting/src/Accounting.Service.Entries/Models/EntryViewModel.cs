using System;
using Accounting.Service.Entries.DomainModel;

namespace Accounting.Service.Entries.Models
{
    public class EntryViewModel
    {
        public DateTime Date { get; set; }
        
        public decimal Amount { get; set; }
        
        public string Description { get; set; }
        
        public EntryIndicator EntryIndicator { get; set; }
    }
}