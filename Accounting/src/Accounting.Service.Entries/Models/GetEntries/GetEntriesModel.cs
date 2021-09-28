using System;

namespace Accounting.Service.Entries.Models.GetEntries
{
    public sealed class GetEntriesModel
    {
        public int? Count { get; set; }

        public int? Offset { get; set; }

        public DateTime? EntryDateBottom { get; set; }

        public DateTime? EntryDateTop { get; set; }
    }
}