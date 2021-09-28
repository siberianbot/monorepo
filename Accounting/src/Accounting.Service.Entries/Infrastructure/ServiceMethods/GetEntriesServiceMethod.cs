using System.Linq;
using System.Threading.Tasks;
using Accounting.DataAccess;
using Accounting.Service.Entries.DomainModel;
using Accounting.Service.Entries.Models;
using Accounting.Service.Entries.Models.GetEntries;
using Accounting.Service.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Service.Entries.Infrastructure.ServiceMethods
{
    internal sealed class GetEntriesServiceMethod : IServiceMethod<GetEntriesModel, GetEntriesResult>
    {
        private readonly IReadRepository<long, Entry> _entryReadRepository;

        public GetEntriesServiceMethod(IReadRepository<long, Entry> entryReadRepository)
        {
            _entryReadRepository = entryReadRepository;
        }

        public async Task<GetEntriesResult> ExecuteAsync(GetEntriesModel model)
        {
            IQueryable<Entry> query = _entryReadRepository.GetAll();

            if (model.EntryDateTop != null)
            {
                query = query.Where(entry => entry.Date <= model.EntryDateTop);
            }

            if (model.EntryDateBottom != null)
            {
                query = query.Where(entry => entry.Date >= model.EntryDateBottom);
            }

            if (model.Offset != null)
            {
                query = query.Skip(model.Offset.Value);
            }

            if (model.Count != null)
            {
                query = query.Take(model.Count.Value);
            }

            return new GetEntriesResult
            {
                Entries = await query
                    .Select(entry => new EntryViewModel
                    {
                        Date = entry.Date.Value,
                        Amount = entry.Amount.Value,
                        Description = entry.Description,
                        EntryIndicator = entry.GetEntryIndicator()
                    })
                    .ToArrayAsync()
            };
        }
    }
}