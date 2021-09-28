using System.Linq;
using System.Threading.Tasks;
using ToDoList.DataAccess;
using ToDoList.Models;

namespace ToDoList.Services.Query.Implementation
{
    internal sealed class WorkItemQueryService : IWorkItemQueryService
    {
        private readonly IReadRepository<WorkItem> _readRepository;

        public WorkItemQueryService(IReadRepository<WorkItem> readRepository)
        {
            _readRepository = readRepository;
        }

        public IQueryable<WorkItem> GetAll()
        {
            return _readRepository.GetAll();
        }

        public Task<WorkItem> GetByIdAsync(long id)
        {
            return _readRepository.GetByIdAsync(id);
        }
    }
}