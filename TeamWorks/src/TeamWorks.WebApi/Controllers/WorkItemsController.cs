using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamWorks.Services.Query;

namespace TeamWorks.WebApi.Controllers
{
    /// <summary>
    /// API-WorkItems - Work items
    /// </summary>
    [Route("workitems")]
    public class WorkItemsController : TeamWorksController
    {
        #region Constructor and private fields

        private readonly IWorkItemQueryService _workItemQueryService;

        public WorkItemsController(IWorkItemQueryService workItemQueryService)
        {
            _workItemQueryService = workItemQueryService;
        }

        #endregion
        
        /// <summary>
        /// API-WI-1 - Get All
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok();
        }
    }
}