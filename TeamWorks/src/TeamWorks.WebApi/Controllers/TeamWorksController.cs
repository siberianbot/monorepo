using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeamWorks.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public abstract class TeamWorksController : Controller
    {
        //
    }
}