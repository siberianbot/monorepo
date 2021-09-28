using Microsoft.AspNetCore.Mvc;
using ToDoList.Web.ActionFilters;

namespace ToDoList.Web.Controllers
{
    [ServiceFilter(typeof(KnownExceptionFilter))]
    public abstract class ApiControllerBase : ControllerBase
    {
        //
    }
}