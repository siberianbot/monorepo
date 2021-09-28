using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Web.Controllers
{
    public sealed class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("_Layout");
        }
    }
}