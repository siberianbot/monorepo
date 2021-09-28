using JetBrains.Annotations;
using ToDoList.DataAccess;
using ToDoList.Models;

namespace ToDoList.CommandServices.Implementation
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal sealed class TaskCommandService : ITaskCommandService
    {
        private readonly IWriteRepository<Task> _writeRepository;

        public TaskCommandService(IWriteRepository<Task> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public Task New()
        {
            return _writeRepository.New();
        }

        public async System.Threading.Tasks.Task CreateAsync(Task entity)
        {
            await _writeRepository.CreateAsync(entity);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Task entity)
        {
            await _writeRepository.UpdateAsync(entity);
        }

        public async System.Threading.Tasks.Task DeleteAsync(Task entity)
        {
            await _writeRepository.DeleteAsync(entity);
        }
    }
}