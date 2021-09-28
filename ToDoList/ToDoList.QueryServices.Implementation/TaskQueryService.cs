using System.Linq;
using JetBrains.Annotations;
using ToDoList.DataAccess;
using ToDoList.Models;

namespace ToDoList.QueryServices.Implementation
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal sealed class TaskQueryService : ITaskQueryService
    {
        private readonly IReadRepository<Task> _readRepository;

        public TaskQueryService(IReadRepository<Task> readRepository)
        {
            _readRepository = readRepository;
        }

        public IQueryable<Task> GetAll()
        {
            return _readRepository.GetAll();
        }

        public IQueryable<Task> GetAllByParentTask(long? parentTaskId)
        {
            return _readRepository.GetAll().Where(task => task.ParentTaskId == parentTaskId);
        }

        public async System.Threading.Tasks.Task<Task> GetByIdAsync(long id)
        {
            return await _readRepository.GetByIdAsync(id);
        }
    }
}