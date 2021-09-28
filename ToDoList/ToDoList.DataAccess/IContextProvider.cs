using Microsoft.EntityFrameworkCore;

namespace ToDoList.DataAccess
{
    public interface IContextProvider
    {
        DbContext GetContext();
    }
}