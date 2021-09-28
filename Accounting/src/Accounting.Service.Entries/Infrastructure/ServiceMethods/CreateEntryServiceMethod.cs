using System.Threading.Tasks;
using Accounting.DataAccess;
using Accounting.Service.Entries.DomainModel;
using Accounting.Service.Entries.Models.CreateEntry;
using Accounting.Service.Infrastructure;

namespace Accounting.Service.Entries.Infrastructure.ServiceMethods
{
    internal sealed class CreateEntryServiceMethod : IServiceMethod<CreateEntryModel, CreateEntryResult>
    {
        private readonly IWriteRepository<Entry> _entryWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEntryServiceMethod(
            IWriteRepository<Entry> entryWriteRepository,
            IUnitOfWork unitOfWork)
        {
            _entryWriteRepository = entryWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateEntryResult> ExecuteAsync(CreateEntryModel model)
        {
            Entry entity = new Entry
            {
                Date = model.EntryDate,
                Description = model.Description,
                Amount = model.Amount
            };

            entity.SetEntryIndicator(model.EntryIndicator!.Value);

            await _entryWriteRepository.CreateAsync(entity);
            await _unitOfWork.CommitAsync();

            return new CreateEntryResult();
        }
    }
}