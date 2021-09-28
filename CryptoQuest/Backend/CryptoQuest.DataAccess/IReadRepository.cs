using System.Linq;

namespace CryptoQuest.DataAccess
{
    public interface IReadRepository<out TEntity>
    {
        IQueryable<TEntity> GetAll();
    }
}