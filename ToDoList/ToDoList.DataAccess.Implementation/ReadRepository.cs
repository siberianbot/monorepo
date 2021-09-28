using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using ToDoList.Models;

namespace ToDoList.DataAccess.Implementation
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal sealed class ReadRepository<TEntity> : IReadRepository<TEntity>
        where TEntity : Entity
    {
        private readonly ContextFactory _contextFactory;

        public ReadRepository(ContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _contextFactory.GetContext().Set<TEntity>();
        }

        public ValueTask<TEntity> GetByIdAsync(long id)
        {
            return _contextFactory.GetContext().FindAsync<TEntity>(id);
        }
    }
}