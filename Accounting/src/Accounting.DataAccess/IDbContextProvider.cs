using Microsoft.EntityFrameworkCore;

namespace Accounting.DataAccess
{
    public interface IDbContextProvider
    {
        DbContext GetContext();
    }
}