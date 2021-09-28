using Accounting.DataAccess.Extensions.Lookup;

namespace Accounting.Service.Entries.DomainModel
{
    public enum EntryIndicator : long
    {
        [Code("CREDIT")]
        Credit = 10,

        [Code("DEBIT")]
        Debit = 20
    }
}