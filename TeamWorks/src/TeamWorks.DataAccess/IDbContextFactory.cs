using Microsoft.EntityFrameworkCore;
using TeamWorks.DependencyInjection;

namespace TeamWorks.DataAccess
{
    public interface IDbContextFactory : IDependency
    {
        DbContext GetContext();
    }
}