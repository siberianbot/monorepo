using System.Threading.Tasks;
using ToDoList.DataAccess;
using ToDoList.Models;

namespace ToDoList.Services.Command.Implementation
{
    internal sealed class WorkItemCommandService : IWorkItemCommandService
    {
        private readonly IWriteRepository<WorkItem> _writeRepository;

        public WorkItemCommandService(IWriteRepository<WorkItem> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public Task CreateAsync(WorkItem entity)
        {
            return _writeRepository.CreateAsync(entity);
        }

        public Task UpdateAsync(WorkItem entity)
        {
            return _writeRepository.UpdateAsync(entity);
        }

        public Task DeleteAsync(WorkItem entity)
        {
            return _writeRepository.DeleteAsync(entity);
        }
    }
}