using System.Threading.Tasks;
using TeamWorks.DependencyInjection;

namespace TeamWorks.DataAccess
{
    public interface IUnitOfWork : IDependency
    {
        Task CommitAsync();

        Task RollbackAsync();
    }
}