using System.Threading.Tasks;

namespace CryptoQuest.DataAccess
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        Task RollbackAsync();
    }
}