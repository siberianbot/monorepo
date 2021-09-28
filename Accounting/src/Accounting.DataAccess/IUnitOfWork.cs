using System.Threading.Tasks;

namespace Accounting.DataAccess
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        Task RollbackAsync();
    }
}